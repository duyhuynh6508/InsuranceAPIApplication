using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InsuranceAPIApplication.BusinessEntities
{
    public class InsuranceClaim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InsuranceClaimGuid { get; set; }
        public string ClaimNumber { get; set; }
        public DateTime ServiceDateFrom { get; set; }
        public DateTime ServiceDateTo { get; set; }
        public DateTime CreatedBy { get; set; }
        public InsuranceClaimStatusEnum Status { get; set; }
        public Guid? OnHoldBy { get; set; }
        public DateTime? TakenDate { get; set; }
        public DateTime? ClaimedDate { get; set; }
        public Guid? ClaimedTo { get; set; }
        public DateTime? ArchivedDate { get; set; }
        public Guid? ArchivedBy { get; set; }
        public string Note { get; set; }
    }
}