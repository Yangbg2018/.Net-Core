using firstApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstApp.Services
{
    public class Respository:IRespository<Student>
    {
        private List<Student> _students;
        public Respository() 
        {
            _students= new List<Student>()
            {
                new Student()
                {
                    Id=1,
                    FirstName="yang",
                    LastName="hh",
                    Birthday=new DateTime(1985,4,7),
                    gender=Gender.男
                },
                new Student()
                {
                    Id=2,
                    FirstName="bing",
                    LastName="bb",
                    Birthday=new DateTime(1990,3,27),
                    gender=Gender.女
                },
                new Student()
                {
                    Id=3,
                    FirstName="geng",
                    LastName="gg",
                    Birthday=new DateTime(2010,2,17),
                    gender=Gender.其他
                }
            };
        }
        public IEnumerable<Student> GetAll()
        {
            return _students;
        }
        public Student Detail(int id)
        {
            return _students.FirstOrDefault(s =>
                    s.Id == id);
        }

        public Student Add(Student newStuModel)
        {
            _students.Add(newStuModel);
            var maxId = _students.Max(s => s.Id);
            newStuModel.Id = maxId + 1;
            return newStuModel;
        }
    }
}
