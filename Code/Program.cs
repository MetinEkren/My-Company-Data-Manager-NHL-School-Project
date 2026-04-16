using MySqlConnector;
using System;
string Databasename = "webwinkel";
string Username = "root";
string Password = "3561";
string Server = "localhost";
string Port = "3306";
string ConnectionString = $"Server={Server};Port={Port};Database={Databasename};Uid={Username};Pwd={Password};";

MySqlConnection conn = new MySqlConnection(ConnectionString);

conn.Open();

conn.Close();
