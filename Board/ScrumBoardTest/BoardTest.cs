using Xunit;
using System.Collections.Generic;
using ScrumBoard.Task;
using ScrumBoard.Column;
using ScrumBoard.Board;
using ScrumBoard.Exception;

namespace ScrumBoardTest
{
    public class BoardTest
    {
        [Fact]
        public void CreateBoard_WithProperties()
        {
            //подготовка
            string boardName = "Название доски";
            //действие
            IBoard board = new Board(boardName);
            //проверка
            Assert.Equal(boardName, board.Name);
            Assert.Empty(board.GetAllColumn());
        }

        [Fact]
        public void AddColumn_InBoard_ColumnWillBeAdded()
        {
            //подготовка
            IColumn column = new Column("Название колонки");
            IBoard board = new Board("Название доски");
            //действие
            board.AddColumn(column);
            //проверка
            Assert.Equal(column, board.GetAllColumn()[0]);
        }

        [Fact]
        public void AddExistColumn_InBoard_ReturnExeption()
        {
            //подготовка
            IColumn column = new Column("Название колонки");
            IBoard board = new Board("Название доски");
            board.AddColumn(column);
            //действие/проверка
            Assert.Throws<ColumnExistException>(() => board.AddColumn(column));
        }

        [Fact]
        public void AddExtraColumn_InBoard_ReturnExeption()
        {
            //подготовка
            IBoard board = new Board("Название доски");
            for (int i = 1; i <= 10; i++)
            {
                board.AddColumn(new Column("Название колонки" + i));
            }
            //действие/проверка
            Assert.Throws<ColumnsOverflowLimitException>(
                () => board.AddColumn(new Column("Название колонки 11"))
            );
        }

        [Fact]
        public void EditColumnName_InBoard_ColumnNameWillChange()
        {
            //подготовка
            string newColumnName = "Новое название колонки";
            IColumn column = new Column("Название колонки");
            IBoard board = new Board("Название доски");
            board.AddColumn(column);
            //действие
            board.EditColumnName(column.GUID, newColumnName);
            //проверка
            Assert.Equal(newColumnName, column.Name);
        }

        [Fact]
        public void EditNotExistColumnName_InBoard_ReturnExeption()
        {
            //подготовка
            IBoard board = new Board("Название доски");
            //действие/проверка
            Assert.Throws<ColumnNotFoundException>(() => board.EditColumnName("", "Новое название колонки"));
        }

        [Fact]
        public void AddTask_OnBoardInDefaultColumn_TaskWillBeAdded()
        {
            //подготовка
            ITask task = new Task("Задача", "Описание задачи", TaskPriority.Medium);
            IColumn column = new Column("Название колонки");
            IBoard board = new Board("Название доски");
            board.AddColumn(column);
            //действие
            board.AddTask(task);
            //проверка
            Assert.Equal(task, column.GetAllTask()[0]);
        }

        [Fact]
        public void AddTask_OnBoardInSpecificColumn_TaskWillBeAdded()
        {
            //подготовка
            ITask task = new Task("Задача", "Описание задачи", TaskPriority.Medium);
            IColumn column1 = new Column("Название колонки1");
            IColumn column2 = new Column("Название колонки2");
            IBoard board = new Board("Название доски");
            board.AddColumn(column1);
            board.AddColumn(column2);
            //действие
            board.AddTask(task, 1);
            //проверка
            Assert.Equal(task, column2.GetAllTask()[0]);
        }

        [Fact]
        public void AddTask_OnBoardInNotExistColumn_ReturnExeption()
        {
            //подготовка
            ITask task = new Task("Задача", "Описание задачи", TaskPriority.Medium);
            IBoard board = new Board("Название доски");
            //действие/проверка
            Assert.Throws<ColumnNotFoundException>(() => board.AddTask(task, 5));
        }

        [Fact]
        public void GetTask_FromBoard_ReturnTask()
        {
            //подготовка
            ITask task = new Task("Задача", "Описание задачи", TaskPriority.Medium);
            IColumn column = new Column("Название колонки");
            IBoard board = new Board("Название доски");
            board.AddColumn(column);
            board.AddTask(task);
            //действие
            ITask retTask = board.GetTask(task.GUID);
            //проверка
            Assert.Equal(task, retTask);
        }

        [Fact]
        public void GetNotExistTask_FromBoard_ReturnExeption()
        {
            //подготовка
            IBoard board = new Board("Название доски");
            //действие/проверка
            Assert.Throws<TaskNotFoundException>(() => board.GetTask(""));
        }

        [Fact]
        public void GetColumn_FromBoard_ReturnColumn()
        {
            //подготовка
            IColumn column = new Column("Название колонки");
            IBoard board = new Board("Название доски");
            board.AddColumn(column);
            //действие
            IColumn retColumn = board.GetColumn(column.GUID);
            //проверка
            Assert.Equal(column, retColumn);
        }

        [Fact]
        public void GetNotExistColumn_FromBoard_ReturnExeption()
        {
            //подготовка
            IBoard board = new Board("Название доски");
            //действие/проверка
            Assert.Throws<ColumnNotFoundException>(() => board.GetColumn(""));
        }

        [Fact]
        public void GetAllColumn_FromBoard_ReturnAllColumn()
        {
            //подготовка
            IColumn column1 = new Column("Название колонки1");
            IColumn column2 = new Column("Название колонки2");
            IColumn column3 = new Column("Название колонки3");
            IBoard board = new Board("Название доски");
            board.AddColumn(column1);
            board.AddColumn(column2);
            board.AddColumn(column3);
            //действие
            List<IColumn> columnList = board.GetAllColumn();
            //проверка
            Assert.Equal(new List<IColumn>() { column1, column2, column3 }, columnList);
        }

        [Fact]
        public void EditTask_OnBoard_TaskWillChange()
        {
            //подготовка
            string newTaskName = "Новая задача";
            string newTaskDescription = "Новое описание задачи";
            ITask task = new Task("Задача", "Описание задачи", TaskPriority.Medium);
            IColumn column = new Column("Название колонки");
            IBoard board = new Board("Название доски");
            column.AddTask(task);
            board.AddColumn(column);
            //действие
            board.EditTask(task.GUID, newTaskName, newTaskDescription, TaskPriority.High);
            //проверка
            ITask retTask = board.GetTask(task.GUID);
            Assert.Equal(newTaskName, retTask.Name);
            Assert.Equal(newTaskDescription, retTask.Description);
            Assert.Equal(TaskPriority.High, retTask.Priority);
        }

        [Fact]
        public void EditNotExistTask_OnBoard_ReturnExeption()
        {
            //подготовка
            IBoard board = new Board("Название доски");
            //действие/проверка
            Assert.Throws<TaskNotFoundException>(() => board.EditTask("", "", "", TaskPriority.High));
        }

        [Fact]
        public void DeleteTask_OnBoard_TaskWillDelete()
        {
            //подготовка
            ITask task = new Task("Задача", "Описание задачи", TaskPriority.Medium);
            IColumn column = new Column("Название колонки");
            IBoard board = new Board("Название доски");
            column.AddTask(task);
            board.AddColumn(column);
            //действие
            board.DeleteTask(task.GUID);
            //проверка
            Assert.Throws<TaskNotFoundException>(() => board.GetTask(task.GUID));
        }

        [Fact]
        public void DeleteNotExistTask_OnBoard_ReturnExeption()
        {
            //подготовка
            IBoard board = new Board("Название доски");
            //действие/проверка
            Assert.Throws<TaskNotFoundException>(() => board.DeleteTask(""));
        }

        [Fact]
        public void DeleteColumn_OnBoard_ColumnWillDelete()
        {
            //подготовка
            IColumn column = new Column("Название колонки");
            IBoard board = new Board("Название доски");
            board.AddColumn(column);
            //действие
            board.DeleteColumn(column.GUID);
            //проверка
            Assert.Throws<ColumnNotFoundException>(() => board.GetColumn(column.GUID));
        }

        [Fact]
        public void DeleteNotExistColumn_OnBoard_ReturnExeption()
        {
            //подготовка
            IBoard board = new Board("Название доски");
            //действие/проверка
            Assert.Throws<ColumnNotFoundException>(() => board.DeleteColumn(""));
        }

        [Fact]
        public void TaskTransfer_OnBoard_ColumnWillDelete()
        {
            //подготовка
            ITask task = new Task("Задача", "Описание задачи", TaskPriority.Medium);
            IColumn column1 = new Column("Название колонки1");
            IColumn column2 = new Column("Название колонки2");
            IBoard board = new Board("Название доски");
            board.AddColumn(column1);
            board.AddColumn(column2);
            board.AddTask(task);
            //действие
            board.TaskTransfer(column2.GUID, task.GUID);
            //проверка
            Assert.Empty(board.GetColumn(column1.GUID).GetAllTask());
            Assert.Equal(task, board.GetColumn(column2.GUID).GetTask(task.GUID));
        }
    }
}