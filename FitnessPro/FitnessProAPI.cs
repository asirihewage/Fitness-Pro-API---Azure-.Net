using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.WebJobs.Host;

namespace FitnessPro
{
    public static class FitnessProAPI
    {
        private static readonly string connectionString;

        static FitnessProAPI()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            connectionString = config.GetConnectionString("AzureSQLConnection");
        }

        private static string GetConnectionString()
        {
            return connectionString;
        }

        [FunctionName("GetUsers")]
        [Obsolete]
        public static IActionResult GetUsers(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users")] HttpRequest req,
            TraceWriter log)
        {
            log.Info("GetUsers function called.");

            try
            {
                var users = new List<User>();

                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM [User]", connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User
                            {
                                UserID = (int)reader["UserID"],
                                Name = (string)reader["Name"],
                                Email = (string)reader["Email"],
                                Password = (string)reader["Password"]
                            };
                            users.Add(user);
                        }
                    }
                }
                return new OkObjectResult(users);
            }
            catch (Exception ex)
            {
                log.Error($"Error occurred: {ex.Message}");
                return new OkObjectResult($"Error occurred: {ex.Message}");
            }
        }
    }
}
