using School.Logic;
using System.Data.SqlClient;

namespace School.DataInfrastructure
{
    public class SqlRepository : IRepository
    {
        // will hold all of the communication to and from the database

        // Fields
        private readonly string _connectionString;

        // Constructor
        public SqlRepository (string connectionString)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        // Methods
        public IEnumerable<Teacher> GetAllTeachers()
        {
            List<Teacher> result = new();

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                "Select Teacher_ID, Name " +
                "FROM School.Teacher;", connection);

            // index     0     1     2     3
            // column   id    name
            // row 1    6     Tryg
            // row 2    7     Andrew

            using SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                string Name = reader.GetString(1);
                result.Add(new(ID, Name));
            }
            // reader.??? is parsing the response form the database to C# datatypes

            connection.Close();
            return result;
        }
    
    
        public Teacher CreateNewTeacher(string Name)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string cmdText =
                @"INSERT INTO School.Teacher (Name)
                VALUES
                (@name);";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@name", Name);

            cmd.ExecuteNonQuery();

            cmdText =
                @"SELECT Teacher_ID, Name
                FROM School.Teacher
                WHERE Name = @name;";

            using SqlCommand cmd2 = new SqlCommand(cmdText, connection);

            cmd2.Parameters.AddWithValue("@name", Name);

            using SqlDataReader reader = cmd2.ExecuteReader();

            Teacher tmpTeacher;
            while (reader.Read())
            {
                return tmpTeacher = new Teacher(reader.GetInt32(0), reader.GetString(1));
            }
            connection.Close();
            Teacher noTeacher = new();
            return noTeacher;
        }


        public string GetStudentName(int ID)
        {
            string? name = "";
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            string cmdText = @"SELECT Name
                FROM School.Student
                WHERE Student_ID = @ID;";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@ID", ID);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                name = reader.GetString(0);
            }

            connection.Close();

            if (name != null)
            { return name; }
            return null;
        }
    }
}