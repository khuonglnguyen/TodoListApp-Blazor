using Microsoft.AspNetCore.Components;
using TodoList.Models;
using TodoListApp.Services;

namespace TodoListApp.Pages
{
    public partial class TodoList
    {
        [Inject] private ITaskApiClient taskApiClient { get; set; }
        private List<TaskDto> Tasks;

        protected async override Task OnInitializedAsync()
        {
            Tasks = await taskApiClient.GetTaskList();
        }
    }
}
