using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InsuranceAPIApplication.BusinessEntities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserGuid { get; set; }

        [Column("UserRoleId")]
        public int UserRoleId { get; set; }

        [ForeignKey("UserRoleId")]
        public virtual UserRole UserRole { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? ArchivedDate { get; set; }
        public Guid? ArchivedBy { get; set; }
    }
}