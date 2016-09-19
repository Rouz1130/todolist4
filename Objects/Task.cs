using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace ToDoList
{
  public class Task
  {
    private int _id;
    private string _description;

    public Task(string Description, int Id = 0)
    {
      _id = Id;
      _description = Description;
    }
    // we need this method to save too database
    // public override bool Equals(System.Object otherTask)
    // {
    //     if (!(otherTask is Task))
    //     {
    //       return false;
    //     }
    //     else
    //     {
    //       Task newTask = (Task) otherTask;
    //       bool DescriptionEquality = (this.GetDescription() == newTask.GetDescription());
    //       return (descriptionEquality);
    //     }
    // }

    public int GetId()
    {
      return _id;
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public static List<Task> GetAll()
    {
      List<Task> allTasks = new List<Task>{};
      // SqlConnection object instanitate an SqlConnection named conn
      // set the Connection string as DB.Connection()
      SqlConnection conn = DB.Connection();
      conn.Open();
      // we open the connection to the database by calling open() on conn above line
      // important to open database conn before using it.

      // instanitate SqlCommand object named cmd. these objects are used to send SQL statments to database.
      // taking in two arguemnts SELECT FROM TASKS (what we want to exucute) and conn.
      SqlCommand cmd = new SqlCommand("SELECT * FROM tasks;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();


      // while loop reads first column of each row and saves it too taskId
      // then reads second column of each row and saves it too taskDescription
      // then uses these values too create a new Task and adds it to all tasks.
      while(rdr.Read())
      {
        int taskId = rdr.GetInt32(0);
        string taskDescription = rdr.GetString(1);
        Task newTask = new Task(taskDescription, taskId);
        allTasks.Add(newTask);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allTasks;
    }
  }
}
