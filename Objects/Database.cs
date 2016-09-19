// Creating our database class with this file , will allow us too manage our database in our/this application

using System.Data;
using System.Data.SqlClient;

namespace ToDoList
{
  public class DB
  {
    public static SqlConnection Connection()
    {
      // creates a new SqlConnection object named Conn (we put in our Startup file) used too tell our app were to find the database.
      SqlConnection conn = new SqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }
  }
}
