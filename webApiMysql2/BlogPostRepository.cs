using System.Data.Common;
using MySqlConnector;
namespace BlogPostApi;
public class BlogPostRepository(MySqlDataSource database)
{
    public async Task<BlogPost?> FindOneAsync(int id)
    {
        using var connection = await database.OpenConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = @"SELECT `Id`, `Title`, `Content` FROM `BlogPost` WHERE `Id` = @id";
        command.Parameters.AddWithValue("@id", id);
        var result = await ReadAllAsync(await command.ExecuteReaderAsync()); return result.FirstOrDefault();
    }
    public async Task<IReadOnlyList<BlogPost>> LatestPostsAsync()
    {
        using var connection = await database.OpenConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = @"SELECT `Id`, `Title`, `Content` FROM `BlogPost` ORDER BY `Id` DESC LIMIT 10;";
        return await ReadAllAsync(await command.ExecuteReaderAsync());
    }
    public async Task DeleteAllAsync()
    {
        using var connection = await database.OpenConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = @"DELETE FROM `BlogPost`";
        await command.ExecuteNonQueryAsync();
    }
    public async Task InsertAsync(BlogPost blogPost)
    {
        using var connection = await database.OpenConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = @"INSERT INTO `BlogPost` (`Title`, `Content`) VALUES (@title, @content);";
        BindParams(command, blogPost);
        await command.ExecuteNonQueryAsync();
        blogPost.Id = (int)command.LastInsertedId;
    }
   
    public async Task UpdateAsync(BlogPost blogPost)
    {
        using var connection = await database.OpenConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = @"UPDATE `BlogPost` SET `Title` = @title, `Content` = @content WHERE `Id` = @id;";
        BindParams(command, blogPost);
        BindId(command, blogPost);
        await command.ExecuteNonQueryAsync();
    }
    public async Task DeleteAsync(BlogPost blogPost)
    {
        using var connection = await database.OpenConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = @"DELETE FROM `BlogPost` WHERE `Id` = @id;"; BindId(command, blogPost);
        await command.ExecuteNonQueryAsync();
    }
    private async Task<IReadOnlyList<BlogPost>> ReadAllAsync(DbDataReader reader)
    {
        var posts = new List<BlogPost>();
        using (reader)
        {
            while (await reader.ReadAsync())
            {
                var post = new BlogPost
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Content = reader.GetString(2),
                };
                posts.Add(post);
            }
        }
        return posts;
    }
    private static void BindId(MySqlCommand cmd, BlogPost blogPost)
    {
        cmd.Parameters.AddWithValue("@id", blogPost.Id);
    }
    private static void BindParams(MySqlCommand cmd, BlogPost blogPost)
    {
        cmd.Parameters.AddWithValue("@title", blogPost.Title); cmd.Parameters.AddWithValue("@content", blogPost.Content);
    }

    internal async Task InsertAsync2(List<BlogPost> body)
    {
        // var objects = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BlogPost>>(lista);
        using var connection = await database.OpenConnectionAsync();
        using (var command = connection.CreateCommand())
            {
            command.CommandText = @"INSERT INTO `BlogPost` (`Title`, `Content`) VALUES (@title, @content);";
            foreach (BlogPost obj in body)
            {
                command.Parameters.AddWithValue("@title", obj.Title);
                command.Parameters.AddWithValue("@content", obj.Content);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
        }
    }
}