using MySqlConnector;
using DataBaseProject.Code;

internal static class Program
{
    public static MySqlConnection? Conn;
    static void Main()
    {
        //De parameters voor de database communicatie 
        string database = "webwinkel";
        string username     = "root";
        string password     = "3561";
        string server       = "localhost";
        string port         = "3306";
        string connectionString = $"Server={server};Port={port};Database={database};Uid={username};Pwd={password};";

        Conn = new MySqlConnection(connectionString);
        Conn.Open();

        MainMenu.HoofdMenu();
    }
}