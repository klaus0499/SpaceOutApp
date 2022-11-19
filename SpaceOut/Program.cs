using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpaceOut.BusinessLogicLayer.Services;
using SpaceOut.DataAccessLayer.Repositories;
using SpaceOut.UI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<NasaService>();
builder.Services.AddHttpClient<NasaRepository>();

builder.Services.AddAutoMapper(typeof(SpaceOut.BusinessLogicLayer.AutoMapperManagement));

await builder.Build().RunAsync();
