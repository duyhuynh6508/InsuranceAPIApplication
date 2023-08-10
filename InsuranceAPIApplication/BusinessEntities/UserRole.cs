using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceAPIApplication.BusinessEntities
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime ArchivedDate { get; set; }
        public Guid ArchivedBy { get; set; }
        public virtual List<User> Users { get; set; }
    }
}