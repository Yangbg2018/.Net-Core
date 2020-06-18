using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstApp.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public Gender gender { get; set; }
    }
}
