using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeAzureFunction.Models
{
    public class SalesData
    {
        public Guid Id { get; set; }
        [Required]
        public int BranchId { get; set; }
        [MaxLength(30)]
        [Required]
        public string TransactionId { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public float Amount { get; set; }
        [MaxLength(30)]
        public string LoyaltyCardNumber { get; set; }
    }
}
