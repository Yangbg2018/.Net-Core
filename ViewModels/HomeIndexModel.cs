using firstApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstApp.ViewModels
{
    public class HomeIndexModel
    {
        public IEnumerable<StudentViewModel> Students{ get; set; }
        //public int Id { get; set; }
        //public string FullName{ get; set; }
        //public int Age { get; set; }
    }
}
