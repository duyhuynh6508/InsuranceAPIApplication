using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InsuranceAPIApplication.BusinessEntities
{
    public class InsuranceInvoiceClaimLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InsuranceInvoiceClaimLinkGuid { get; set; }

        [Column("InsuranceInvoiceGuid")]
        public Guid InsuranceInvoiceGuid { get; set; }

        [Column("InsuranceClaimGuid")]
        public Guid InsuranceClaimGuid { get; set; }

        [ForeignKey("InsuranceInvoiceGuid")]
        public virtual InsuranceInvoice InsuranceInvoice { get; set; }

        [ForeignKey("InsuranceClaimGuid")]
        public virtual InsuranceClaim InsuranceClaim { get; set; }
    }
}