using CV.Persistence;
using CV.Application;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddCors(o =>
//{
//    o.AddPolicy("CorsPolicy", b =>
//    b.AllowAnyOrigin()
//    .AllowAnyMethod()
//    .AllowAnyHeader()
//    );
//});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseCors("CorsPolicy");

//app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.MapControllers();

app.Run();
