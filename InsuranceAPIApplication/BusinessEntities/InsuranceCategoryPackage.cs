using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InsuranceAPIApplication.BusinessEntities
{
    public class InsuranceCategoryPackage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InsuranceCategoryPackageGuid { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}