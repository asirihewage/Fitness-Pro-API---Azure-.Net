using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FitnessPro
{
    public class DataAccessLayer
    {
        private readonly string connectionString;

        public DataAccessLayer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [User] (Name, Email, Password) VALUES (@Name, @Email, @Password)", connection);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.ExecuteNonQuery();
            }
        }

        public User GetUserById(int userID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM [User] WHERE UserID = @UserID", connection);
                command.Parameters.AddWithValue("@UserID", userID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserID = (int)reader["UserID"],
                            Name = (string)reader["Name"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"]
                        };
                    }
                }
            }

            return null;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM [User]", connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            UserID = (int)reader["UserID"],
                            Name = (string)reader["Name"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"]
                        });
                    }
                }
            }

            return users;
        }

        public void UpdateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE [User] SET Name = @Name, Email = @Email, Password = @Password WHERE UserID = @UserID", connection);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@UserID", user.UserID);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteUser(int userID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM [User] WHERE UserID = @UserID", connection);
                command.Parameters.AddWithValue("@UserID", userID);
                command.ExecuteNonQuery();
            }
        }

        public void AddWeight(Weight weight)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Weight (UserID, Date, WeightValue) VALUES (@UserID, @Date, @WeightValue)", connection);
                command.Parameters.AddWithValue("@UserID", weight.UserID);
                command.Parameters.AddWithValue("@Date", weight.Date);
                command.Parameters.AddWithValue("@WeightValue", weight.WeightValue);
                command.ExecuteNonQuery();
            }
        }

        public List<Weight> GetWeightsByUserId(int userID)
        {
            List<Weight> weights = new List<Weight>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Weight WHERE UserID = @UserID", connection);
                command.Parameters.AddWithValue("@UserID", userID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        weights.Add(new Weight
                        {
                            WeightID = (int)reader["WeightID"],
                            UserID = (int)reader["UserID"],
                            Date = (DateTime)reader["Date"],
                            WeightValue = (float)reader["WeightValue"]
                        });
                    }
                }
            }

            return weights;
        }

        public void UpdateWeight(Weight weight)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Weight SET Date = @Date, WeightValue = @WeightValue WHERE WeightID = @WeightID", connection);
                command.Parameters.AddWithValue("@Date", weight.Date);
                command.Parameters.AddWithValue("@WeightValue", weight.WeightValue);
                command.Parameters.AddWithValue("@WeightID", weight.WeightID);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteWeight(int weightID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Weight WHERE WeightID = @WeightID", connection);
                command.Parameters.AddWithValue("@WeightID", weightID);
                command.ExecuteNonQuery();
            }
        }

        public Weight GetWeightById(int weightID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Weight WHERE WeightID = @WeightID", connection);
                command.Parameters.AddWithValue("@WeightID", weightID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Weight
                        {
                            WeightID = (int)reader["WeightID"],
                            UserID = (int)reader["UserID"],
                            Date = (DateTime)reader["Date"],
                            WeightValue = (float)reader["WeightValue"]
                        };
                    }
                }
            }

            return null;
        }

        public void AddReport(Report report)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Report (UserID, StartDate, EndDate, WorkoutSummary, CheatMealSummary, FitnessPredictions, WeightPredictions) " +
                                                    "VALUES (@UserID, @StartDate, @EndDate, @WorkoutSummary, @CheatMealSummary, @FitnessPredictions, @WeightPredictions)", connection);
                command.Parameters.AddWithValue("@UserID", report.UserID);
                command.Parameters.AddWithValue("@StartDate", report.StartDate);
                command.Parameters.AddWithValue("@EndDate", report.EndDate);
                command.Parameters.AddWithValue("@WorkoutSummary", report.WorkoutSummary);
                command.Parameters.AddWithValue("@CheatMealSummary", report.CheatMealSummary);
                command.Parameters.AddWithValue("@FitnessPredictions", report.FitnessPredictions);
                command.Parameters.AddWithValue("@WeightPredictions", report.WeightPredictions);
                command.ExecuteNonQuery();
            }
        }

        public Report GetReportById(int reportID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Report WHERE ReportID = @ReportID", connection);
                command.Parameters.AddWithValue("@ReportID", reportID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Report
                        {
                            ReportID = (int)reader["ReportID"],
                            UserID = (int)reader["UserID"],
                            StartDate = (DateTime)reader["StartDate"],
                            EndDate = (DateTime)reader["EndDate"],
                            WorkoutSummary = (string)reader["WorkoutSummary"],
                            CheatMealSummary = (string)reader["CheatMealSummary"],
                            FitnessPredictions = (string)reader["FitnessPredictions"],
                            WeightPredictions = (string)reader["WeightPredictions"]
                        };
                    }
                }
            }

            return null;
        }

        public void UpdateReport(Report report)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Report SET UserID = @UserID, StartDate = @StartDate, EndDate = @EndDate, " +
                                                    "WorkoutSummary = @WorkoutSummary, CheatMealSummary = @CheatMealSummary, " +
                                                    "FitnessPredictions = @FitnessPredictions, WeightPredictions = @WeightPredictions " +
                                                    "WHERE ReportID = @ReportID", connection);
                command.Parameters.AddWithValue("@UserID", report.UserID);
                command.Parameters.AddWithValue("@StartDate", report.StartDate);
                command.Parameters.AddWithValue("@EndDate", report.EndDate);
                command.Parameters.AddWithValue("@WorkoutSummary", report.WorkoutSummary);
                command.Parameters.AddWithValue("@CheatMealSummary", report.CheatMealSummary);
                command.Parameters.AddWithValue("@FitnessPredictions", report.FitnessPredictions);
                command.Parameters.AddWithValue("@WeightPredictions", report.WeightPredictions);
                command.Parameters.AddWithValue("@ReportID", report.ReportID);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteReport(int reportID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Report WHERE ReportID = @ReportID", connection);
                command.Parameters.AddWithValue("@ReportID", reportID);
                command.ExecuteNonQuery();
            }
        }
    }
}
