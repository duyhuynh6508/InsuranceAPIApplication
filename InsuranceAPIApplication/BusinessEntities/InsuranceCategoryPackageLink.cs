using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InsuranceAPIApplication.BusinessEntities
{
    public class InsuranceCategoryPackageLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InsuranceCategoryPackageLinkGuid { get; set; }

        [Column("InsuranceCategoryGuid")]
        public Guid InsuranceCategoryGuid { get; set; }

        [Column("InsuranceCategoryPackageGuid")]
        public Guid InsuranceCategoryPackageGuid { get; set; }

        [ForeignKey("InsuranceCategoryGuid")]
        public virtual InsuranceCategory InsuranceCategory { get; set; }

        [ForeignKey("InsuranceCategoryPackageGuid")]
        public virtual InsuranceCategoryPackage InsuranceCategoryPackage { get; set; }
    }
}