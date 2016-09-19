using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ToDoList
{
  public class ToDoTest
  {
    // constructor for our test we set DBConfiguration.ConnectionString which overides the startup.cs
    public ToDoTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=todo_test;Integrated Security=SSPI";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      //arrange, act
      int result = Task.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }
}
}
//
//     [Fact]
//     public void Test_Equal_ReturnsTrueIfDescripitonAreTheSame()
//     {
//       //arrange, act
//       Task firsTask = new Task("Mow the Lawn");
//       Task secondTask = new Task("Mow the Lawn");
//
//       //assert
//       Assert.Equal(firstTask, secondTask);
//     }
//
//     [Fact]
//   public void Test_Save_SavesToDatabase()
//   {
//     //Arrange
//     Task testTask = new Task("Mow the lawn");
//
//     //Act
//     testTask.Save();
//     List<Task> result = Task.GetAll();
//     List<Task> testList = new List<Task>{testTask};
//
//     //Assert
//     Assert.Equal(testList, result);
//   }
//
//     public void Dispose()
//     {
//       Task.DeleteAll();
//     }
//   }
// }
