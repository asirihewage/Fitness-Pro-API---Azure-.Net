using System;

public class User
{
    public int UserID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
using System;

public class Weight
{
    public int WeightID { get; set; }
    public int UserID { get; set; }
    public DateTime Date { get; set; }
    public float WeightValue { get; set; }
}

public class Workout
{
    public int WorkoutID { get; set; }
    public int UserID { get; set; }
    public DateTime Date { get; set; }
    public string ExerciseType { get; set; }
    public int Duration { get; set; }
    public string Intensity { get; set; }
    public string Notes { get; set; }
}

public class CheatMeal
{
    public int CheatMealID { get; set; }
    public int UserID { get; set; }
    public DateTime Date { get; set; }
    public string FoodType { get; set; }
    public string Quantity { get; set; }
    public string Notes { get; set; }
}

public class Report
{
    public int ReportID { get; set; }
    public int UserID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string WorkoutSummary { get; set; }
    public string CheatMealSummary { get; set; }
    public string FitnessPredictions { get; set; }
    public string WeightPredictions { get; set; }
}