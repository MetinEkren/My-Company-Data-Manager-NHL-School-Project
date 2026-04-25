using MySqlConnector;
using System;
using DataBaseProject.Code;

class Program
{
    public static MySqlConnection conn;
    static void Main()
    {
        string databasename = "webwinkel";
        string username     = "root";
        string password     = "3561";
        string server       = "localhost";
        string port         = "3306";
        string connectionString = $"Server={server};Port={port};Database={databasename};Uid={username};Pwd={password};";

        conn = new MySqlConnection(connectionString);
        conn.Open();

        MainMenu.HoofdMenu();
    }
}

// string klantId = reader.GetString("KlantID");
// string naam = reader.GetString("KlantNaam");
// Console.WriteLine("{0} = {1}", klantId, naam);

// conn.Open();
//
// MainMenu.HoofdMenu();
//
// conn.Close();
