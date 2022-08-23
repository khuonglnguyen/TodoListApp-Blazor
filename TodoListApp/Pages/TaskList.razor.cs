using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TodoList.Models;
using TodoList.Models.SeedWork;
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
        public MetaData MetaData { get; set; } = new MetaData();


        private TaskListSearch TaskListSearch = new TaskListSearch();

        protected override async Task OnInitializedAsync()
        {
            await GetTasks();
        }

        public async Task SearchTask(TaskListSearch taskListSearch)
        {
            TaskListSearch = taskListSearch;
            await GetTasks();
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
                await GetTasks();
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
                await GetTasks();
            }
        }

        private async Task GetTasks()
        {
            var pagingResponse = await TaskApiClient.GetTaskList(TaskListSearch);
            Tasks = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }

        private async Task SelectedPage(int page)
        {
            TaskListSearch.PageNumber = page;
            await GetTasks();
        }
    }

}
