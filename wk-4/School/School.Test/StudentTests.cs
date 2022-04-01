using Xunit;
using Moq;
using School.DataInfrastructure;
using School.Logic;
using School.App;
using System.Collections.Generic;
using System.Collections;

namespace School.Test
{
    public class StudentTests
    {
        [Fact]
        public void Student_CreateStudentObject_ValidStudent()
        {
            // Arrange
            Student test = new Student(01, "Kevin");

            // Act
            string actual = test.GetName();

            // Assert
            string expected = "Kevin";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void School_GetStudent_ValidStudent()
        {
            // the test that i'm writing should NOT involve calling the SqlRepository class. 
            //      A unit test should DEFINITELY not involve the database, and above all,
            //      it should not involve the PRODUCTION database
            // DONT DO THIS!!    ||
            //                  \\//
            //                   \/
            // IRepository repo = new SqlRepository(connectionString);
            
            // arrange
            Mock<IRepository> mockRepo = new();

            // lamda expression syntax: like an anonymous classless method (delegate)
            // the Mock class sets up its inner object using these methods calls (Setup, Returns) **Reflection
            mockRepo.Setup(x => x.GetStudentName(4)).Returns("Francis");
            var school = new App.School(mockRepo.Object);

            // act
            Student test = school.GetStudent(4);
            string actual = test.GetName();

            // assert
            string expected = "Francis";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void School_IntoduceAllTeachers_FormattedString()
        {
            // arrange
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.GetAllTeachers()).Returns(System.Array.Empty<Teacher>());
            var school = new App.School(mockRepo.Object);

            // act
            string actual = school.IntroduceAllTeachers();

            // assert
            string expected = "********** Intoducing the Teachers of the School! ********\n\r\n";
            Assert.Equal(expected, actual);
        }
    }
}