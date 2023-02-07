using System.ComponentModel.DataAnnotations;

namespace ClaimsAPI.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Address1 { get; set; } = string.Empty;
        public string? Address2 { get; set; } = string.Empty;
        public string? Address3 { get; set; } = string.Empty;
        public string? PostCode { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
        public bool Active
        {
            get
            {
                return (InsuranceEndDate >= DateTime.Now);
            }
            set { }
        }
        public DateTime InsuranceEndDate { get; set; }
    }
}
