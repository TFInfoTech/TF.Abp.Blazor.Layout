using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace TF.Abp.Blazor.Layout.BlazoriseTheme.Demo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var application = builder.AddApplication<LayoutBlazorModule>(options =>
            {
                options.UseAutofac();
            });

            var host = builder.Build();

            await application.InitializeAsync(host.Services);

            await host.RunAsync();
        }
    }
}
