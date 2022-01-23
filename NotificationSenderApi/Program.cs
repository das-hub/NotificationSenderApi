using System.Text.Json.Serialization;
using NotificationSenderApi.DataAccess;
using NotificationSenderApi.Services.Notifications;
using NotificationSenderApi.Services.Notifications.Abstractions;
using NotificationSenderApi.Services.SendHandlers;
using NotificationSenderApi.Services.SendHandlers.Abstractions;
using NotificationSenderApi.Services.States;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(configure =>
{
    configure.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder => policyBuilder
        .SetIsOriginAllowed(_ => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});
builder.Services.AddLogging();

builder.Services.AddSingleton<IDbContext, DbContext>();
builder.Services.AddScoped<INotificationService, DefaultNotificationService>();
builder.Services.AddScoped<IStateService, DefaultStateService>();
builder.Services.AddScoped<ISendHandlerFactory, DefaultSendHandlerFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();