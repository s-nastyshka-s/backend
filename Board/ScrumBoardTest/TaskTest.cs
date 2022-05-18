using Xunit;
using ScrumBoard.Task;

namespace ScrumBoardTest
{
    public class TaskTest
    {
        [Fact]
        public void CreateTask_WithProperties()
        {
            //подготовка
            string taskName = "Задача";
            string taskDescription = "Описание задачи";
            //действие
            ITask task = new Task(taskName, taskDescription, TaskPriority.Medium);
            //проверка
            Assert.False(string.IsNullOrEmpty(task.GUID));
            Assert.Equal(taskName, task.Name);
            Assert.Equal(taskDescription, task.Description);
            Assert.Equal(TaskPriority.Medium, task.Priority);
        }

        [Fact]
        public void ChangeTaskName_NameWillChange()
        {
            //подготовка
            string newTaskName = "Новое название задачи";
            ITask task = new Task("Задача", "Описание задачи", TaskPriority.Medium);
            //действие
            task.Name = newTaskName;
            //проверка
            Assert.Equal(newTaskName, task.Name);
        }

        [Fact]
        public void ChangeTaskDescription_DescriptionWillChange()
        {
            //подготовка
            string newTaskDescription = "Новое описание задачи";
            ITask task = new Task("Задача", "Описание задачи", TaskPriority.Medium);
            //действие
            task.Description = newTaskDescription;
            //проверка
            Assert.Equal(newTaskDescription, task.Description);
        }

        [Fact]
        public void ChangeTaskPriority_PriorityWillChange()
        {
            //подготовка
            ITask task = new Task("Задача", "Описание задачи", TaskPriority.Medium);
            //действие
            task.Priority = TaskPriority.Low;
            //проверка
            Assert.Equal(TaskPriority.Low, task.Priority);
        }
    }
}