using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace schoolManagementsystem.Models
{
    [Table("leave_details")]
    public partial class LeaveDetail
    {
        [Key]
        [Column("leave_id")]
        public int LeaveId { get; set; }
        [Required]
        [Column("reason")]
        public string Reason { get; set; }
        [Column("applied_by")]
        public int AppliedBy { get; set; }
        [Column("is_approved")]
        public int IsApproved { get; set; }

        [ForeignKey(nameof(AppliedBy))]
        [InverseProperty(nameof(LoginDetail.LeaveDetails))]
        public virtual LoginDetail AppliedByNavigation { get; set; }
    }
}
