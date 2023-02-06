using System.Collections.Generic;
using Npgsql;

namespace MBTI
{
    public class Person
    {
        public Dictionary<string, int> Answers;
        static public string Login;

        static public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=admin;Database=MBTI");
        }
    }
}
