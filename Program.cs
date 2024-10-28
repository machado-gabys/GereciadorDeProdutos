using GerenciadorDeProdutos.Repository.Interface;
using GerenciadorDeProdutos.Repository;
using GerenciadorDeProdutos.Service.Interface;
using GerenciadorDeProdutos.Service;
using System.Data;
using GerenciadorDeProdutos.ConexãoDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDbConnection>(sp =>
{
    var dbInitializer = new InicializadorDB();
    return dbInitializer.GetConnection();
});

builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IProdutoService, ProdutoService>();

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
