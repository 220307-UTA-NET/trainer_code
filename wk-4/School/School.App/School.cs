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

        public string IntroduceAllTeachers()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("********** Intoducing the Teachers of the School! ********\n");
            IEnumerable<Teacher> teachers = repo.GetAllTeachers();
            foreach (Teacher teacher in teachers)
            {
                sb.AppendLine(teacher.Introduce());
            }
            return sb.ToString();
        }




    }
}
