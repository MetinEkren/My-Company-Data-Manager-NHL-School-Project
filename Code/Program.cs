using MySqlConnector;
using System;
string Databasename = "company";
string Username = "root";
string Password = "3561";
string Server = "localhost";
string Port = "3306";
string ConnectionString = $"Server={Server};Port={Port};Database={Databasename};Uid={Username};Pwd={Password};";

MySqlConnection conn = new MySqlConnection(ConnectionString);

conn.Open();

// string sql = "SELECT name, description FROM department;";

// using (MySqlCommand cmd = new MySqlCommand(sql, conn))
// {
//     MySqlDataReader reader = cmd.ExecuteReader();
//     
//     while (reader.Read())
//     {
//         string name = reader.GetString("name");
//         string description = reader.GetString("description");
//         Console.WriteLine("{0} = {1}", name, description);
//     }
//     
//     reader.Close();
// }
// string sql2 = "SELECT name,description " +
//               " FROM department " +
//               " WHERE name=@depname;";
//
// using (MySqlCommand cmd = new MySqlCommand(sql2, conn))
// {
//     cmd.Parameters.AddWithValue("@depname", "Sales");
//     MySqlDataReader reader = cmd.ExecuteReader();
//     while (reader.Read())
//     {
//         string name = reader.GetString("name");
//         string description = reader.GetString("description");
//         Console.WriteLine("{0} = {1}", name, description);
//     }
//     reader.Close();
// }

// Console.Write("Afdelingsnaam: "); // geeft NULL terug als geen antwoord
// string? keuze = Console.ReadLine();
//
// if (keuze != null)
// {
//     string sql3 = " SELECT name, description " +
//                   " FROM department " +
//                   " WHERE name LIKE '%' @depname '%';";
//     using (MySqlCommand cmd = new MySqlCommand(sql3, conn))
//     {
//         cmd.Parameters.AddWithValue("@depname", keuze);
//         MySqlDataReader reader = cmd.ExecuteReader();
//         while (reader.Read())
//         {
//             string name = reader.GetString("name");
//             string description = reader.GetString("description");
//             Console.WriteLine("{0} = {1}", name, description);
//         }
//         reader.Close();
//     }
// }

// string sql4 = " INSERT INTO department (name, description) VALUES(@name, @description)";
// using (MySqlCommand cmd = new MySqlCommand(sql4, conn))
// {
//     cmd.Parameters.AddWithValue("@name", "Research");
//     cmd.Parameters.AddWithValue("@description", "The Research and Development department");
//     try
//     {
//         int rowsAffected = cmd.ExecuteNonQuery();
//         long newPrimaryKeyValue = cmd.LastInsertedId;
//         Console.WriteLine("De nieuwe unieke id is {0}", newPrimaryKeyValue);
//         Console.WriteLine("{0} records toegevoegd", rowsAffected);
//     }
//     catch (MySqlException ex)
//     {
//         Console.WriteLine("{0}", ex.Message);
//     }
// }

string sql5 = "SELECT d.idDepartment as id, d.name as Name, e.firstname as Firstname, e.lastname as Lastname, e.middlename as Middlename FROM department as d JOIN employees as e ON idDepartment = fk_idDepartment ORDER BY Name, Lastname, Firstname";
using (MySqlCommand cmd = new MySqlCommand(sql5, conn))
{
    // MySqlDataReader reader = cmd.ExecuteReader();
    
    // while (reader.Read()) 
    // {
    //      string name = reader.GetString("name");
    //      string description = reader.GetString("description");
    //      Console.WriteLine("{0} = {1}", name, description);
    // }
     
    // reader.Close();
}

conn.Close();
