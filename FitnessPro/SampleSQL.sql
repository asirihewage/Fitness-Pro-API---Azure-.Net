CREATE TABLE [User]
(
    UserID INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Password NVARCHAR(100) NOT NULL
);

CREATE TABLE Weight
(
    WeightID INT PRIMARY KEY,
    UserID INT NOT NULL,
    Date DATE NOT NULL,
    WeightValue FLOAT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);

CREATE TABLE Workout
(
    WorkoutID INT PRIMARY KEY,
    UserID INT NOT NULL,
    Date DATE NOT NULL,
    ExerciseType NVARCHAR(100) NOT NULL,
    Duration INT NOT NULL,
    Intensity NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(500),
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);

CREATE TABLE CheatMeal
(
    CheatMealID INT PRIMARY KEY,
    UserID INT NOT NULL,
    Date DATE NOT NULL,
    FoodType NVARCHAR(100) NOT NULL,
    Quantity NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(500),
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);

CREATE TABLE Report
(
    ReportID INT PRIMARY KEY,
    UserID INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    WorkoutSummary NVARCHAR(1000),
    CheatMealSummary NVARCHAR(1000),
    FitnessPredictions NVARCHAR(1000),
    WeightPredictions NVARCHAR(1000),
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);

INSERT INTO [User] (UserID, Name, Email, Password)
VALUES
    (1, 'John Doe', 'john.doe@example.com', 'password123'),
    (2, 'Jane Smith', 'jane.smith@example.com', 'securepwd!'),
    (3, 'Bob Johnson', 'bob.johnson@example.com', 'letmein');

INSERT INTO Weight (WeightID, UserID, Date, WeightValue)
VALUES
    (1, 1, '2023-07-01', 75.5),
    (2, 1, '2023-07-02', 74.8),
    (3, 2, '2023-07-01', 65.2),
    (4, 2, '2023-07-02', 64.9);

INSERT INTO Workout (WorkoutID, UserID, Date, ExerciseType, Duration, Intensity, Notes)
VALUES
    (1, 1, '2023-07-01', 'Running', 30, 'Moderate', 'Morning run in the park.'),
    (2, 1, '2023-07-02', 'Cycling', 45, 'High', 'Cycled on the trails.'),
    (3, 2, '2023-07-01', 'Yoga', 60, 'Low', 'Relaxing yoga session.'),
    (4, 2, '2023-07-02', 'Weightlifting', 60, 'High', 'Full-body workout at the gym.');

INSERT INTO CheatMeal (CheatMealID, UserID, Date, FoodType, Quantity, Notes)
VALUES
    (1, 1, '2023-07-01', 'Pizza', '2 slices', 'Cheated on the diet.'),
    (2, 1, '2023-07-02', 'Ice Cream', '1 cup', 'Indulged in some ice cream.'),
    (3, 2, '2023-07-01', 'Burger', '1', 'Enjoyed a burger.'),
    (4, 2, '2023-07-02', 'Fries', 'Medium', 'Had some fries.');

