using BlogPostApi;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at
//https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMySqlDataSource(builder.Configuration.GetConnectionString("Default")!);
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

// GET api/blog
app.MapGet("/api/blog", async ([FromServices] MySqlDataSource db) =>
{
    var repository = new BlogPostRepository(db);
    return await repository.LatestPostsAsync();
});

// GET api/blog/5
app.MapGet("/api/blog/{id}", async ([FromServices] MySqlDataSource db, int id) =>
{
    var repository = new BlogPostRepository(db);
    var result = await repository.FindOneAsync(id);
    return result is null ? Results.NotFound() : Results.Ok(result);
});

app.MapGet("/api/blog/csv", async ([FromServices] MySqlDataSource db) =>
{
    var repository = new BlogPostRepository(db);
    return await repository.transCsv();
});

app.MapGet("/api/blog/csv/{id}", async ([FromServices] MySqlDataSource db, int id) =>
{
    var repository = new BlogPostRepository(db);
    var result = await repository.transCsvId(id);
    return result is null ? Results.NotFound() : Results.Ok(result);
});



// POST api/blog
app.MapPost("/api/blog", async ([FromServices] MySqlDataSource db, [FromBody] List<BlogPost> body) =>
{
    var repository = new BlogPostRepository(db);
    await repository.InsertAsync2(body);
      return body;
});

// PUT api/blog/5
app.MapPut("/api/blog/{id}", async (int id, [FromServices] MySqlDataSource db, [FromBody] BlogPost body) =>
{
    var repository = new BlogPostRepository(db);
    var result = await repository.FindOneAsync(id);
    if (result is null)
        return Results.NotFound();
    result.Title = body.Title;
    result.Content = body.Content;
    await repository.UpdateAsync(result);
    return Results.Ok(result);
});

// DELETE api/blog/5
app.MapDelete("/api/blog/{id}", async ([FromServices] MySqlDataSource db, int id) =>
{
    var repository = new BlogPostRepository(db);
    var result = await repository.FindOneAsync(id);
    if (result is null)
        return Results.NotFound();
    await repository.DeleteAsync(result);
    return Results.NoContent();
});

// DELETE api/blog
app.MapDelete("/api/blog", async ([FromServices] MySqlDataSource db) =>
{
    var repository = new BlogPostRepository(db);
    await repository.DeleteAllAsync();
    return Results.NoContent();
});
app.Run();
