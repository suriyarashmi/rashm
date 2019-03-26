namespace WinterwoodTask.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Please enter FirstName")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Please enter LastName")]
        public string LastName { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Please enter username")]
        public string Username { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(50)]
        [Compare("Password",ErrorMessage = "Please enter confirm password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
