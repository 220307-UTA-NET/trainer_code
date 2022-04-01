using Xunit;
using Moq;
using School.DataInfrastructure;
using School.Logic;
using School.App;

namespace School.Test
{
    public class StudentTests
    {
        [Fact]
        public void Student_CreateStudentObject_ValidStudent()
        {
            // Arrange
            Student expected = new Student(01, "Kevin");

            // Act

            Student actual = new Student(01, "Kevin");
            
            // Assert

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void School_GetStudent_ValidStudent()
        {
            // the test that i'm writing should NOT involve calling the SqlRepository class. 
            //      A unit test should DEFINITELY not involve the database, and above all,
            //      it should not involve the PRODUCTION database

            // arrange
            Student expected = new Student(4, "Francis");
            Mock<IRepository> mockRepo = new();

            // lamda expression syntax: like an anonymous classless method (delegate)
            // the Mock class sets up its inner object using these methods calls (Setup, Returns) **Reflection
            mockRepo.Setup(x => x.GetStudentName(4)).Returns("Francis");
            //IRepository repo = new SqlRepository(connectionString);

            var school = new App.School((IRepository)mockRepo);


            // act
            Student actual = school.GetStudent(4);


            // assert
            Assert.Equal(expected, actual);
        }
    }
}