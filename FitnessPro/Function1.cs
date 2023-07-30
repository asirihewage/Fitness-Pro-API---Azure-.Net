using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

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


        [FunctionName("GetUserById")]
        public static HttpResponseData GetUserById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users/{userID}")] HttpRequest req,
            int userID,
            FunctionContext context)
        {
            // Implement the GetUserById function here...
        }

        // Implement other CRUD functions for Create, Update, and Delete operations.

        // Helper method to get the database connection string from configuration.
        private static string GetConnectionString()
        {
            return connectionString;
        }
    }
}
