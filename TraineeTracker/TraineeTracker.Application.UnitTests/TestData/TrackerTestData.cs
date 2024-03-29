﻿using TraineeTracker.Domain;

namespace TraineeTracker.Application.UnitTests.TestData
{
    public static class TrackerTestData
    {
        public static List<Tracker> trackers = new List<Tracker>
        {
            new Tracker
            {
                Id = 1,
                Start = "Studying every day",
                Stop = "Making silly mistakes",
                Continue = "Learning C#",
                StartDate = new DateTime(2022, 10, 12),
                CreatedDate = new DateTime(2022, 10, 12),
                TechnicalSkill = "Skilled",
                ConsultantSkill = "Partially Skilled",
                TraineeId = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d",
                CreatedBy = "Carl Angle"
            },
            new Tracker
            {
                Id = 2,
                Start = "Studying every day",
                Stop = "Making silly mistakes",
                Continue = "Learning C#",
                StartDate = new DateTime(2022, 11, 12),
                CreatedDate = new DateTime(2022, 10, 12),
                TechnicalSkill = "Skilled",
                ConsultantSkill = "Partially Skilled",
                TraineeId = "2cbdecbb-791e-45c0-93de-51abc9b71859",
                CreatedBy = "Kim Sale"
            }
        };

        public static IEnumerable<object[]> TestDataTrackers =>
            new[]
            {
                new object[] { "7e6adc8b-0a6e-4970-af0c-18f7fe18336d", new DateTime(2022, 10, 12), 0, 1 },
                new object[] { "2cbdecbb-791e-45c0-93de-51abc9b71859", new DateTime(2022, 11, 12), 1, 2 }
            };
    }
}
