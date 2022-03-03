using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class PurchaseRequestModel
    {
        public Guid? PurchaseNumber { get; set; } = Guid.NewGuid();
        public DateTime? PurchaseDateTime { get; set; } = DateTime.Now;
        public int MovieId { get; set; }
    }
}
