using Microsoft.EntityFrameworkCore;

namespace JRSystem.Models
{
    public class Account
    {
        public string AccountId { get; set; }
        public string UserName { get; set; }
        public DateTime? SetupTime { get; set; }
        public string Password { get; set; }


        private readonly ReferralDBContext _context;

        public Account()
        {
            // 无参数构造函数
        }
        public Account(ReferralDBContext context)
        {
            _context = context;
        }

        public List<string> Tolist()
        {
            var usernames = _context.AccountSets.Select(account => account.UserName).ToList();

            return usernames;

            // 进行进一步操作，如筛选、排序等
            // 例如：
            // var filteredAccounts = accounts.Where(a => a.UserName.StartsWith("John")).ToList();
        }

        public Dictionary<string,string> ExportToDictionary()
        {
            var dataDictionary = _context.AccountSets.ToDictionary(account => account.UserName, account => account.Password);

            //foreach (var kvp in dataDictionary)
            //{
            //    Console.WriteLine($"Username: {kvp.Key}, Password: {kvp.Value}");
            //}
            return dataDictionary;
        }

    }
}
