using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace TTNtmp.Controllers.Resources
{
    public class EmployeeResource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required(ErrorMessage = "First Name is required.")]
        [StringLength(255)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Last Name is required.")]
        [StringLength(255)]
         [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Personal Phone is required.")]
        //[Range(1,10, ErrorMessage = "10 digits required")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonalPhone { get; set; }

        //[Required(ErrorMessage = "Marketing Phone is required.")]
        //[Range(1,10, ErrorMessage = "10 digits required")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MarketingPhone { get; set; }

        //[Required(ErrorMessage = "Personal Email is required.")]
        [EmailAddress]
         [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string PersonalEmail { get; set; }

       // [Required(ErrorMessage = "Marketing Email is required.")]
        [EmailAddress]
         [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MarketingEmail { get; set; }

        //[Required(ErrorMessage = "Status is required.")]
        [StringLength(255)]  
         [DatabaseGenerated(DatabaseGeneratedOption.None)]      
        public string Status { get; set; }
    }
}