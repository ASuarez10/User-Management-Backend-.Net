using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Repositories;
using UserManagementAPI.UseCases;

namespace UserManagementAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddRouting(routing=>routing.LowercaseUrls = true);

        builder.Services.AddDbContext<UserManagementContext>(postgresqlBuilder =>
        {
            postgresqlBuilder.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection"));
        });

        builder.Services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();

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

        app.Run();
    }
}
