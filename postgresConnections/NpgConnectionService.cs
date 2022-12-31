using Npgsql;
public class NpgConnection
{
    public static void Start()
    {
        var connection = new NpgsqlConnection(
            "host=localhost; port=5432; database=testdb; username=postgres; password=3321;"
        );
        connection.Open();

        var command = connection.CreateCommand();

        //create table query
        command.CommandText = "create table if not exists users(id serial , name text)";
        command.ExecuteNonQuery();

        //insert data
        command.CommandText = "insert into users(name) values('jeki'), ('koko')";
        command.ExecuteNonQuery();

        //delete date
        command.CommandText = "delete from users where id > 2";
        command.ExecuteNonQuery();

        //read data
        command.CommandText = "select * from users";
        var reader = command.ExecuteReader();

        Console.WriteLine($"\tid, \tname");

        while (reader.Read())
        {
            Console.WriteLine($"\t{reader["id"]} \t{reader["name"]} ");
        }

        reader.Close();
        connection.Close();
    }
}
