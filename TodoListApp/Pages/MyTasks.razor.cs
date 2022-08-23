using Microsoft.AspNetCore.Components;
using TodoList.Models;
using TodoList.Models.SeedWork;
using TodoListApp.Components;
using TodoListApp.Pages.Components;
using TodoListApp.Services;
using TodoListApp.Shared;

namespace TodoListApp.Pages
{
    public partial class MyTasks
    {
        [Inject] private ITaskApiClient TaskApiClient { set; get; }

        protected Confirmation DeleteConfirmation { set; get; }
        protected AssignTask AssignTaskDialog { set; get; }

        private Guid DeleteId { set; get; }
        private List<TaskDto> Tasks;
        public MetaData MetaData { get; set; } = new MetaData();

        private TaskListSearch TaskListSearch = new TaskListSearch();

        [CascadingParameter]
        private Error Error { set; get; }

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
            try
            {
                var pagingResponse = await TaskApiClient.GetMyTasks(TaskListSearch);
                Tasks = pagingResponse.Items;
                MetaData = pagingResponse.MetaData;
            }
            catch (Exception ex)
            {
                Error.ProcessError(ex);
            }

        }

        private async Task SelectedPage(int page)
        {
            TaskListSearch.PageNumber = page;
            await GetTasks();
        }
    }


}