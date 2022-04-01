using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Logic;

namespace School.DataInfrastructure
{
        // repository design pattern : implement basic CRUD operations
        //                          CRUD - Create, Read, Udate, Delete
        // operations that the rest of the app may need, but we can abstract the implementation details.
        // advantage: it makes the rest of the program more unit-testable

        // often repositories don't "save" imediately, instead using a special save method
        // to wrap all the changes into one transaction.

        // sometimes one repository per "entity", per type of thing we want to track in the DB
        // tansactions across multiple repositories/entities requires the "unit of work" design pattern
        // which mangaes multiple repositories, and saves the changes of all of them at once.
    public interface IRepository
    {
        // an interface is a contract, that defines a set of conditions. 
        // it can contain methods, properties, or events.
        // but it does not fully define them, only provides the signature
        //                          Access-Modifier Return-Type Method-Name (Parameter types/names)

        // in C#, we can use multiple Interfaces to simulate multiple-inheritance.

        IEnumerable<Teacher> GetAllTeachers();
        Teacher CreateNewTeacher(string Name);
        string GetStudentName(int ID);
    }
}
