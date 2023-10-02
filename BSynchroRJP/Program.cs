
using BSynchroRJP.Application.Accounts;
using BSynchroRJP.Application.Contracts.Accounts;
using BSynchroRJP.Application.Contracts.Customers;
using BSynchroRJP.Application.Customers;
using BSynchroRJP.Infrastructure.Customers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region DI Injection
builder.Services.AddTransient<ICustomerRepository,CustomerRepository>();
builder.Services.AddTransient<IAccountService,AccountService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
#endregion

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.Run();
