using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TodoListApp;
using TodoListApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BackendApiUrl"))});
builder.Services.AddTransient<ITaskApiClient, TaskApiClient>();
builder.Services.AddTransient<IUserApiClient, UserApiClient>();
builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();
