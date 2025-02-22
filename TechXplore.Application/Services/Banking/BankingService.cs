using Mapster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Application.LimitModels;
using TechXplore.Application.Repositories;
using TechXplore.Application.TransactionModels;
using TechXplore.Application.UserModels;
using TechXplore.Domain.Categories;
using TechXplore.Domain.Companies;
using TechXplore.Domain.Limits;
using TechXplore.Domain.Rents;
using TechXplore.Domain.Transactions;
using TechXplore.Domain.Users;

namespace TechXplore.Application.Services.Banking
{
    public class BankingService : IBankingService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ILimitRepository _limitRepository;
        private readonly ICategoryRepository _categoryRepository;
        public BankingService(IUserRepository userRepository, ITransactionRepository transactionRepository, ICompanyRepository companyRepository, ILimitRepository limitRepository, ICategoryRepository categoryRepository)
        {
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
            _companyRepository = companyRepository;
            _limitRepository = limitRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> BuyAProduct(CancellationToken cancellationToken, UserRequestPostModel user, TransactionPostModel transaction)
        {
            if (user.Money < transaction.MoneySpent)
                return false;
            user.Money -= transaction.MoneySpent;
            Company comp = await _companyRepository.Get(cancellationToken, transaction.CompanyId);
            user.ESGScore += transaction.MoneySpent * comp.ESGCoefficient;
            User neededUser = user.Adapt<User>();
            neededUser.Id = 1;
            neededUser.Transactions = new List<Transaction>();
            neededUser.Rents = new List<Rent>();
            neededUser.Limits = new List<Limit>();
            Transaction neededTransaction = transaction.Adapt<Transaction>();
            neededTransaction.TransactionTime = DateTime.Now;
            await _transactionRepository.Create(cancellationToken, neededTransaction);
            _userRepository.DetachACertainUser(1);
            await _userRepository.Update(cancellationToken, neededUser);
            return true;
        }

        public async Task<decimal> GetLimitProcentage(CancellationToken cancellationToken, UserRequestPostModel user, int limitId)
        {
            LimitPostModel chosenLimit = user.Limits.SingleOrDefault(x => x.CategoryId == limitId);
            decimal spent = await GetMoneySpentInACertainCategory(cancellationToken, user, limitId);
            return Decimal.Round(((spent / chosenLimit.MoneyLimit) * 100), 2);
        }

        public async Task<decimal> GetLimitProcentage(CancellationToken cancellationToken, UserRequestPostModel user, string categoryName)
        {
            Category chosenCategory = await _categoryRepository.Get(cancellationToken, categoryName);
            LimitPostModel chosenLimit = user.Limits.SingleOrDefault(x => x.CategoryId == chosenCategory.Id);
            decimal spent = await GetMoneySpentInACertainCategory(cancellationToken, user, chosenCategory.Id);
            return Decimal.Round(((spent / chosenLimit.MoneyLimit) * 100), 2);
        }

        public async Task<decimal> GetMoneySpentInACertainCategory(CancellationToken cancellationToken, UserRequestPostModel user, int categoryId)
        {
            IEnumerable<Company> companies = await _companyRepository.GetAllAsync(cancellationToken);
            IEnumerable<Company> neededCompanies = companies.Where(x => x.CategoryId == categoryId);
            return neededCompanies.Aggregate(0M, (x, y) => x + y.Transactions.Aggregate(0M, (a, b) => a + b.MoneySpent));
        }

        public async Task<decimal> GetMoneySpentInACertainCategory(CancellationToken cancellationToken, UserRequestPostModel user, string categoryName)
        {
            IEnumerable<Company> companies = await _companyRepository.GetAllAsync(cancellationToken);
            int categoryId = (await _categoryRepository.Get(cancellationToken, categoryName)).Id;
            IEnumerable<Company> neededCompanies = companies.Where(x => x.CategoryId == categoryId);
            return neededCompanies.Aggregate(0M, (x, y) => x + y.Transactions.Aggregate(0M, (a, b) => a + b.MoneySpent));
        }

        public async Task SetLimit(CancellationToken cancellationToken, LimitPostModel limit)
        {
            Limit resLimit = limit.Adapt<Limit>();
            resLimit.UserId = 1;
            await _limitRepository.Create(cancellationToken, resLimit);
        }

        public async Task UpdateLimit(CancellationToken cancellationToken, LimitPostModel limit)
        {
            Limit resLimit = limit.Adapt<Limit>();
            resLimit.UserId = 1;
            await _limitRepository.Update(cancellationToken, resLimit);
        }

        
    }
}
