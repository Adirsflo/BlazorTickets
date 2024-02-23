using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", options =>
	{
		options.AllowAnyHeader();
		options.AllowAnyMethod();
		options.AllowAnyOrigin();
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

app.Run();

public class MyDb
{
	private readonly IConfiguration _configuration;

	public MyDb(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public void MyMethod()
	{
		string connectionString = _configuration.GetConnectionString("MyDatabase");
	}
}

public class DbController : Controller
{
	private readonly IConfiguration _configuration;

	public DbController(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public IActionResult Index()
	{
		string connectionString = _configuration.GetConnectionString("MyDatabase");

		return View();
	}
}
