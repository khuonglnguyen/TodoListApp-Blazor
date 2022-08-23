using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TodoList.Models;
using TodoListApp.Components;
using TodoListApp.Pages.Components;
using TodoListApp.Services;

namespace TodoListApp.Pages
{
    public partial class TaskList
    {
        [Inject] private ITaskApiClient TaskApiClient { set; get; }

        private List<TaskDto> Tasks;

        private Guid DeleteId { get; set; }

        protected Confirmation DeleteConfirmation { get; set; }
        protected AssignTask AssignTaskDialog { get; set; }


        private TaskListSearch TaskListSearch = new TaskListSearch();

        protected override async Task OnInitializedAsync()
        {
            Tasks = await TaskApiClient.GetTaskList(TaskListSearch);
        }

        public async Task SearchTask(TaskListSearch taskListSearch)
        {
            TaskListSearch = taskListSearch;
            Tasks = await TaskApiClient.GetTaskList(TaskListSearch);
        }

        public void OnDeleteTask(Guid deleteId)
        {
            DeleteId = deleteId;
            DeleteConfirmation.Show();
        }

        public async Task OnConfirmDeleteTask(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await TaskApiClient.DeleteTask(DeleteId);
                Tasks = await TaskApiClient.GetTaskList(TaskListSearch);
            }
        }

        public void OpenAssignPopup(Guid id)
        {
            AssignTaskDialog.Show(id);
        }

        public async Task AssignTaskSuccess(bool result)
        {
            if (result)
            {
                Tasks = await TaskApiClient.GetTaskList(TaskListSearch);
            }
        }
    }

}
