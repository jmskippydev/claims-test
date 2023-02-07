using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClaimsAPI.Models
{
    public class Claim
    {
        [Key]
        public int UCR { get; set; }
        public int CompanyId { get; set; }
        public DateTime ClaimDate { get; set; }
        public DateTime LossDate { get; set; }
        public string AssuredName { get; set; } = string.Empty;
        public decimal IncurredLoss { get; set; }
        public bool Closed { get; set; }
        public int DaysAged
        {
            get
            {
                return (int)(DateTime.Now - ClaimDate).TotalDays;
            }
        }
    }
}
