using firstApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace firstApp.ViewModels
{
    public class CreateViewModel
    {
        [Display(Name = "名")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "姓"), Required, MaxLength(10)]
        public string LastName { get; set; }

        [Display(Name = "出生日期")]
        public DateTime BirthDay { get; set; }

        [Display(Name = "性别")]
        public Gender gender { get; set; }

    }
}
