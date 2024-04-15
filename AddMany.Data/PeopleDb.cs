using System.Data.SqlClient;

namespace AddMany.Data
{
    public class PeopleDb
    {
        private string _connectionString { get; set; }

        public PeopleDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Person> GetPeople()
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM People";
            connection.Open();
            var reader = cmd.ExecuteReader();

            var people = new List<Person>();

            while (reader.Read())
            {
                people.Add(new()
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            return people;
        }
        public void AddPerson(Person p)
        {
            var connection = new SqlConnection(_connectionString);
            var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO People(FirstName,LastName,Age)" +
                " VALUES(@firstName, @lastName, @age)";
            cmd.Parameters.AddWithValue("@firstName", p.FirstName);
            cmd.Parameters.AddWithValue("@lastName", p.LastName);
            cmd.Parameters.AddWithValue("@age", p.Age);
            connection.Open();
            cmd.ExecuteNonQuery();
        }
        public void AddMany(List<Person> people)
        {
            foreach (var p in people)
            {

                AddPerson(p);
            }

        }

    }
}