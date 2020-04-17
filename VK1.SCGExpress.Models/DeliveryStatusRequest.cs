using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VK1.SCGExpress.Models {
   public class DeliveryStatusRequest {
        [Required, StringLength(15)]
        public string QRCode { get; set; }

        [Required, StringLength(15)]
        public string Status { get; set; }

        [StringLength(255)]
        public string StatusText { get; set; }

        [Required, Column(TypeName = "datetime2")]
        public DateTime TransactionDate { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        [StringLength(15)]
        public string Category { get; set; }

        [StringLength(15)]
        public string ParcelType { get; set; }

        [StringLength(255)]
        public string Signature { get; set; }

        [StringLength(255)]
        public string ReceiveBy { get; set; }

        [StringLength(255)]
        public string Relationship { get; set; }

        [StringLength(255)]
        public string CustomerReference1 { get; set; }

        [StringLength(255)]
        public string CustomerReference2 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ReceiveDate { get; set; }

        public int NetAmount { get; set; }
    }
}
