using Xunit;
using System.Collections.Generic;
using ScrumBoard.Task;
using ScrumBoard.Column;

namespace ScrumBoardTest
{
    public class ColumnTest
    {
        [Fact]
        public void CreateColumn_WithProperties()
        {
            //подготовка
            string columnName = "Название колонки";
            //действие
            IColumn column = new Column(columnName);
            //проверка
            Assert.False(string.IsNullOrEmpty(column.GUID));
            Assert.Equal(columnName, column.Name);
            Assert.Empty(column.GetAllTask());
        }

        [Fact]
        public void ChangeColumnName_NameWillChange()
        {
            //подготовка
            string newColumnName = "Новое название колонки";
            IColumn column = new Column("Название колонки");
            //действие
            column.Name = newColumnName;
            //проверка
            Assert.Equal(newColumnName, column.Name);
        }

        [Fact]
        public void AddTask_InColumn_TaskWillBeAdded()
        {
            //подготовка
            string columnName = "Название колонки";
            ITask task = new Task("Задача", "Описание задачи", TaskPriority.Medium);
            IColumn column = new Column(columnName);
            //действие
            column.AddTask(task);
            //проверка
            Assert.Equal(task, column.GetAllTask()[0]);
        }

        [Fact]
        public void GetTask_FromColumn_ReturnTask()
        {
            //подготовка
            ITask task = new Task("Задача", "Описание задачи", TaskPriority.Medium);
            IColumn column = new Column("Название колонки");
            column.AddTask(task);
            //действие
            ITask? retTask = column.GetTask(task.GUID);
            //проверка
            Assert.Equal(task, retTask);
        }

        [Fact]
        public void EditTask_InColumn_TaskWillChange()
        {
            //подготовка
            string newTaskName = "Новая задача";
            string newTaskDescription = "Новое описание задачи";
            ITask task = new Task("Задача", "Описание задачи", TaskPriority.Medium);
            IColumn column = new Column("Название колонки");
            column.AddTask(task);
            //действие
            column.EditTask(task.GUID, newTaskName, newTaskDescription, TaskPriority.High);
            //проверка
            ITask? retTask = column.GetTask(task.GUID);
            Assert.NotNull(retTask);
            Assert.Equal(newTaskName, retTask.Name);
            Assert.Equal(newTaskDescription, retTask.Description);
            Assert.Equal(TaskPriority.High, retTask.Priority);
        }

        [Fact]
        public void DeleteTask_InColumn_TaskWillDelete()
        {
            //подготовка
            ITask task = new Task("Задача", "Описание задачи", TaskPriority.Medium);
            IColumn column = new Column("Название колонки");
            column.AddTask(task);
            //действие
            column.DeleteTask(task.GUID);
            //проверка
            Assert.Null(column.GetTask(task.GUID));
        }

        [Fact]
        public void GetAllTask_FromColumn_ReturnAllTask()
        {
            //подготовка
            ITask task1 = new Task("Задача1", "Описание задачи1", TaskPriority.Medium);
            ITask task2 = new Task("Задача2", "Описание задачи2", TaskPriority.Low);
            ITask task3 = new Task("Задача3", "Описание задачи3", TaskPriority.High);
            IColumn column = new Column("Название колонки");
            column.AddTask(task1);
            column.AddTask(task2);
            column.AddTask(task3);
            //действие
            List<ITask> taskList = column.GetAllTask();
            //проверка
            Assert.Equal(new List<ITask>() { task1, task2, task3 }, taskList);
        }
    }
}