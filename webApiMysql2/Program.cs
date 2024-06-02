using BlogPostApi;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using WebApplicationToken.Controllers;
using WebApplicationSock;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMySqlDataSource(builder.Configuration.GetConnectionString("Default")!);
builder.Services.AddWebSocketManager();

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

// Configure WebSocket server
var webSocketPort = builder.Configuration.GetValue<int>("WebSocketServer:Port");
app.UseWebSockets();
app.MapWebSocketManager("/ws", new WebSocketHandler());

// Configure the HTTP API endpoints
app.MapGet("/api/blog", async ([FromServices] MySqlDataSource db, string token) =>
{
    var repository = new BlogPostRepository(db);
    return await repository.LatestPostsAsync(token);
});

app.MapGet("/api/blog/{id}", async ([FromServices] MySqlDataSource db, int id, string token) =>
{
    var repository = new BlogPostRepository(db);
    var result = await repository.FindOneAsync(id, token);
    return result is null ? Results.NotFound() : Results.Ok(result);
});

app.MapGet("/api/blog/csv", async ([FromServices] MySqlDataSource db, string token) =>
{
    var repository = new BlogPostRepository(db);
    return await repository.transCsv(token);
});

app.MapGet("/api/blog/csv/{id}", async ([FromServices] MySqlDataSource db, int id, string token) =>
{
    var repository = new BlogPostRepository(db);
    var result = await repository.transCsvId(id, token);
    return result is null ? Results.NotFound() : Results.Ok(result);
});

app.MapPost("/api/blog", async ([FromServices] MySqlDataSource db, [FromBody] List<BlogPost> body, string token) =>
{
    var repository = new BlogPostRepository(db);
    await repository.InsertAsync2(body, token);
    return body;
});

app.MapPut("/api/blog/{id}", async (int id, [FromServices] MySqlDataSource db, [FromBody] BlogPost body, string token) =>
{
    var repository = new BlogPostRepository(db);
    var result = await repository.FindOneAsync(id, token);
    if (result is null)
        return Results.NotFound();
    result.Title = body.Title;
    result.Content = body.Content;
    await repository.UpdateAsync(result);
    return Results.Ok(result);
});

app.MapDelete("/api/blog/{id}", async ([FromServices] MySqlDataSource db, int id, string token) =>
{
    var repository = new BlogPostRepository(db);
    var result = await repository.FindOneAsync(id, token);
    if (result is null)
        return Results.NotFound();
    await repository.DeleteAsync(result, token);
    return Results.NoContent();
});

app.MapDelete("/api/blog", async ([FromServices] MySqlDataSource db, string token) =>
{
    var repository = new BlogPostRepository(db);
    await repository.DeleteAllAsync(token);
    return Results.NoContent();
});

// Start the app
app.Run($"http://localhost:{webSocketPort}");
