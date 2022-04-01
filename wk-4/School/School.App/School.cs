using School.DataInfrastructure;
using School.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.App
{
    public class School
    {
        // Fields
        IRepository repo;


        // Constructor

        public School(IRepository repo)
        {
            this.repo = repo;
        }



        // Methods
        public Student GetStudent(int ID)
        { 
            return new Student(ID, this.repo.GetStudentName(ID));
        }




    }
}
