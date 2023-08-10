using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InsuranceAPIApplication.BusinessEntities
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid NotificationGuid { get; set; }
        public NotificationTypeEnum NotificationTypeId { get; set; }
        public string Description { get; set; }
        public string ActionName { get; set; }
        public Guid ActionBy { get; set; }
        public Guid ActionTo { get; set; }
        public DateTime ActionDate { get; set; }
        public DateTime ArchivedDate { get; set; }
        public Guid ArchivedBy { get; set; }
    }
}