using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Runtime;
using System.Xml.Xsl;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Schema;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;
using System.Text.Json;



using System.Data.Common;
using MySqlConnector;
using System.Text.RegularExpressions;
using WebApplicationToken.Controllers;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using WebApplicationSock;
namespace BlogPostApi;


public class BlogPostRepository(MySqlDataSource database)
{
    private readonly string _secretKey = "SecretKeywqewqeqqqqqqqqqqqweeeeeeeeeeeeeeeeeeeqweqe";

    public async Task<BlogPost?> FindOneAsync(int id, string token)
    {
        var (subject, expiration) = ValidateJwtToken(token);
        if (subject != null && expiration != null)
        {
            using var connection = await database.OpenConnectionAsync();
            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT `Id`, `Title`, `Content` FROM `BlogPost` WHERE `Id` = @id";
            command.Parameters.AddWithValue("@id", id);
            var result = await ReadAllAsync(await command.ExecuteReaderAsync());
            return result.FirstOrDefault();
        }
        else
        {
            return null;
        }


    }
    public async Task<IReadOnlyList<BlogPost>> LatestPostsAsync(string token)
    {

        var (subject, expiration) = ValidateJwtToken(token);
        if (subject != null && expiration != null)
        {
            using var connection = await database.OpenConnectionAsync();
            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT `Id`, `Title`, `Content` FROM `BlogPost` ORDER BY `Id` DESC;";
            return await ReadAllAsync(await command.ExecuteReaderAsync());
        }
        else
        {
            return null;
        }


    }

    public async Task<string> transCsv(string token)
    {

        var (subject, expiration) = ValidateJwtToken(token);
        if (subject != null && expiration != null)
        {
            using var connection = await database.OpenConnectionAsync();
            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT `Id`, `Title`, `Content` FROM `BlogPost` ORDER BY `Id` DESC;";
            IReadOnlyList<BlogPost> BlogP = await ReadAllAsync(await command.ExecuteReaderAsync());
            string jsonContent = JsonConvert.SerializeObject(BlogP);
            var data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonContent);
            string csv = ConvertToCSV(data);
            return csv;
        }
        else
        {
            return null;
        }
    }

    public async Task<string> transCsvId(int id, string token)
    {

        var (subject, expiration) = ValidateJwtToken(token);
        if (subject != null && expiration != null)
        {
            using var connection = await database.OpenConnectionAsync();
            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT `Id`, `Title`, `Content` FROM `BlogPost` WHERE `Id` = @id";
            command.Parameters.AddWithValue("@id", id);

            IReadOnlyList<BlogPost> BlogP = await ReadAllAsync(await command.ExecuteReaderAsync());
            string jsonContent = JsonConvert.SerializeObject(BlogP);
            var data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonContent);
            string csv = ConvertToCSV(data);
            return csv;
        }
        else
        {
            return null;
        }
    }

    static string ConvertToCSV(List<Dictionary<string, string>> data)
    {
        StringWriter biblioteca = new StringWriter();
        biblioteca.WriteLine(string.Join(",", data[0].Keys));
        foreach (Dictionary<string, string> item in data)
        {
            biblioteca.WriteLine(string.Join(",", item.Values));
        }
        return biblioteca.ToString();
    }

    public async Task DeleteAllAsync(string token)
    {

        var (subject, expiration) = ValidateJwtToken(token);
        if (subject != null && expiration != null)
        {
            using var connection = await database.OpenConnectionAsync();
            using var command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM `BlogPost`";
            await command.ExecuteNonQueryAsync();
        }
    }
    public async Task InsertAsync(BlogPost blogPost, string token)
    {
        var (subject, expiration) = ValidateJwtToken(token);
        if (subject != null && expiration != null)
        {
            using var connection = await database.OpenConnectionAsync();
            using var command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO `BlogPost` (`Title`, `Content`) VALUES (@title, @content);";
            BindParams(command, blogPost);
            await command.ExecuteNonQueryAsync();
            blogPost.Id = (int)command.LastInsertedId;
        }
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
    public async Task DeleteAsync(BlogPost blogPost, string token)
    {
        var (subject, expiration) = ValidateJwtToken(token);
        if (subject != null && expiration != null)
        {
            using var connection = await database.OpenConnectionAsync();
            using var command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM `BlogPost` WHERE `Id` = @id;"; BindId(command, blogPost);
            await command.ExecuteNonQueryAsync();
        }
        await NotifyPostDeletion(blogPost.Id);

    }
    private async Task NotifyPostDeletion(int postId)
    {
        // Construct a message indicating the deleted post's ID or any relevant data
        var message = $"{postId}";

        // Broadcast the message to all connected WebSocket clients
        await WebSocketHandler.SendToAllAsync(message);
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

    internal async Task InsertAsync2(List<BlogPost> body, string token)
    {
        var (subject, expiration) = ValidateJwtToken(token);
        if (subject != null && expiration != null)
        {
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

    private (string Subject, DateTime Expiration) ValidateJwtToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);
        // Extrai o token JWT da string JSON, se estiver presente
        var tokenParts = token.Split("\"");
        if (tokenParts.Length >= 3)
        {
            token = tokenParts[3];
        }
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
        if (validatedToken != null)
        {
            var subject = principal.Identity.Name;
            var expiration = validatedToken.ValidTo;
            return (subject, expiration);
        }
        else
        {
            throw new SecurityTokenException("Invalid JWT token."); // Or handle invalid tokens differently
        }
    }
}