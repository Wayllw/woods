using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using MySqlConnector;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace WebApplicationToken.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class AuthController(MySqlDataSource database) : ControllerBase
    {
        private readonly string _secretKey = "SecretKeywqewqeqqqqqqqqqqqweeeeeeeeeeeeeeeeeeeqweqe";
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel model)
        {
            using (MySqlConnection connection = database.OpenConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT `username`, `password` FROM `usuarios` WHERE `username` = @nome AND `password` = @senha";
                    command.Parameters.AddWithValue("@nome", model.Username);
                    command.Parameters.AddWithValue("@senha", model.Password);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            var token = GenerateJwtToken(model.Username);
                            return Ok(new { token });

                        }
                        else
                        {
                            return Unauthorized("Invalid Credentials.");
                        }
                    }
                }
            }
        }
        private string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, username) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        [HttpGet]
        [Route("validate-token")]
        public IActionResult ValidateToken(string token)
        {
            Console.WriteLine("", token);
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("O token JWT não foi fornecido.");
            }
            try
            {
                var (subject, expiration) = ValidateJwtToken(token);
                return Ok(new
                {
                    Subject = subject,
                    Expiration = expiration
                });
            }
            catch (SecurityTokenException ex)
            {
                return Unauthorized("O token JWT é inválido.");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar o token JWT.");
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

        [HttpPost]
[Route("register")]
public async Task<IActionResult> Register(LoginModel model)
{
    if (model == null || string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.Password))
    {
        return BadRequest("Username and password must be provided.");
    }
    
    try
    {
        using (MySqlConnection connection = await database.OpenConnectionAsync())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO `usuarios` (`username`, `password`) VALUES (@username, @password);";
                command.Parameters.AddWithValue("@username", model.Username);
                command.Parameters.AddWithValue("@password", model.Password);

                await command.ExecuteNonQueryAsync();
            }
        }
        return Ok("User registered successfully.");
    }
    catch (Exception ex)
    {
        // Log the exception (logging mechanism not shown here)
        return StatusCode(500, "An error occurred while registering the user.");
    }
}

        /*
        
        private ClaimsPrincipal ValidateJwtToken0(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            //Extrai o token JWT da string JSON, se estiver presente
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
            SecurityToken validatedToken;
            return tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);
        }



        
                private async Task<IReadOnlyList<User>> ReadAllAsync(DbDataReader reader)
            {
                var posts = new List<User>();
                using (reader)
                {
                    while (await reader.ReadAsync())
                    {
                        var post = new User
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Password = reader.GetString(2),
                        };
                        posts.Add(post);
                    }
                }
                return posts;
            }    



                private string GenerateJwtToken(string username)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, username) }),
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return tokenHandler.WriteToken(token);
                }

                
                [HttpGet]
                [Route("api-keys")]
                public IActionResult ListApiKeys(string token)
                {
                    if (string.IsNullOrEmpty(token))
                    {
                        return BadRequest(new
                        {
                            message = "O token JWT não foi fornecido."
                        });
                    }
                    try
                    {
                        // Validar o token JWT
                        var validatedToken = ValidateJwtToken0(token);
                        if (validatedToken != null)
                        {
                            // Lógica para obter as chaves de API (exemplo simplificado)
                            List<string> apiKeys = new List<string>
                                {
                                "api_key_1",
                                "api_key_2",
                                "api_key_3"
                                };
                            return Ok(apiKeys);
                        }
                        return Unauthorized();
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(new
                        {
                            message = "Erro ao validar o token JWT: " +
                       ex.Message
                        });
                    }
                }

                
            }*/
        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
