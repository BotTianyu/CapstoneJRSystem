namespace JRSystem.Models
{
    public class Referral
    {
        public string ReferralId { get; set; } 
        public string ReferralName { get; set; }
        public DateTime? ReferralDate { get; set; }
        public DateTime deadline { get; set; }
        public string JobTitle { get; set; }

    }
}
