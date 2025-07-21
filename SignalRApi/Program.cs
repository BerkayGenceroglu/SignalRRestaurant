using FluentValidation;
using FluentValidation.AspNetCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.BusinessLayer.Container;
using SignalR.BusinessLayer.ValidationRules.BookingValidations;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using SignalRApi.Hubs;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});

builder.Services.AddSignalR();

//Context
builder.Services.AddDbContext<SignalRContext>();
//AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());//	AutoMapper'ı projeye ekler
//----------------------------------

builder.Services.ContainerDependencies();
//----------------------------------
//FluentValidation
builder.Services.AddFluentValidationAutoValidation(config => config.DisableDataAnnotationsValidation=true);
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingValidation>();
//"CreateBookingValidation sınıfının bulunduğu projedeki tüm validator sınıflarını (AbstractValidator<T>) otomatik olarak bul ve sisteme tanıt.🧠 "Validasyon sınıflarını tek tek yazmadan, bir satırla projeye otomatik tanıttım.""
//----------------------------------
builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//--------------------------------
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");
//SignalRHub sınıfını /signalrhub URL’si ile ilişkilendirir.
//Yani istemciler bu adrese bağlanarak hub’a ulaşabilir.
app.Run();
