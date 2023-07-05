using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace JRSystem.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public DateTime? SetupTime { get; set; }
        public string Password { get; set; }

        public const string SessionKeyName = "_AccountID";
       

        private readonly ReferralDBContext _context;

        public Account()
        {
            
        }
        public Account(ReferralDBContext context)
        {
            _context = context;
            
        }

        public Dictionary<string,string> ExportToDictionary()
        {
            var dataDictionary = _context.AccountSets.ToDictionary(account => account.UserName, account => account.Password);
            return dataDictionary;
        }

    }
}
