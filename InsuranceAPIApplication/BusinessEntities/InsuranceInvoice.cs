using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InsuranceAPIApplication.BusinessEntities
{
    public class InsuranceInvoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InsuranceInvoiceGuid { get; set; }

        [Column("CustomerGuid")]
        public Guid CustomerGuid { get; set; }

        [ForeignKey("CustomerGuid")]
        public virtual Customer Customer { get; set; }

        public string InvoiceNumber { get; set; }
        public DateTime InterventionDateFrom { get; set; }
        public DateTime InterventionDateTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public InsuranceInvoiceStatusEnum Status { get; set; }
        public Guid? OnHoldBy { get; set; }
        public DateTime? TakenDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public Guid? CompletedBy { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public DateTime? ArchivedDate { get; set; }
        public Guid? ArchivedBy { get; set; }
        public string Note { get; set; }
    }
}