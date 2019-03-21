using System;
using System.Collections.Generic;
using System.Globalization;

namespace EBSGenerator
{
    internal class SubscriptionGenerator
    {
        private List<Subscription> subscriptions;
        private readonly Random rnd = new Random();

        private MinNumbers minNumbers = new MinNumbers();
        private MinNumbers currentMinNumbers;

        private MinEqualNumbers minEqualNumbers = new MinEqualNumbers();
        private MinEqualNumbers currentMinEqualNumbers;

        private readonly List<string> operators = new List<string> { "<", "<=", ">", ">=" };
        private const string equalOperator = "=";

        public List<Subscription> Generate(SubscriptionConfiguration subscriptionconfiguration, int noOfMessages)
        {
            MinNumbers currentMinNumbers = new MinNumbers()
            {
                PatientNameMinNumber = 0,
                EyeColorMinNumber = 0,
                DateOfBirthMinNumber = 0,
                HeightMinNumber = 0,
                HeartRateMinNumber = 0
            };

            MinEqualNumbers currentMinEqualNumbers = new MinEqualNumbers()
            {
                MinDateOfBirthEquals = 0,
                MinHeartRateEquals = 0,
                MinHeightEquals = 0
            };

            subscriptions = new List<Subscription>();

            for (var i = 0; i < noOfMessages; i++)
            {
                string patientName = "", eyeColor = "";
                DateTime? dateOfBirth = DateTime.Parse("01.01.1900");
                double? height = 0;
                int? heartRate = 0;
                Option dateOfBirthOption = new Option(), heightOption = new Option(), heartRateOption = new Option();

                #region Generate subscription with the required occurence percentage for each field 

                var numberOfDaysInDateInterval = (subscriptionconfiguration.MaxDateValue - subscriptionconfiguration.MinDateValue).Days;

                if (minNumbers.PatientNameMinNumber > currentMinNumbers.PatientNameMinNumber)
                {
                    // Generate subscription with field "PatientName"
                    patientName = subscriptionconfiguration.PatientNames[rnd.Next(subscriptionconfiguration.PatientNames.Count)];

                    currentMinNumbers.PatientNameMinNumber++;
                }
                if (minNumbers.EyeColorMinNumber > currentMinNumbers.EyeColorMinNumber)
                {
                    // Generate subscription with field "EyeColor"
                    eyeColor = subscriptionconfiguration.EyeColors[rnd.Next(subscriptionconfiguration.EyeColors.Count)];

                    currentMinNumbers.EyeColorMinNumber++;
                }
                if (minNumbers.DateOfBirthMinNumber > currentMinNumbers.DateOfBirthMinNumber)
                {
                    // Generate subscription with field "DateOfBirth"
                    dateOfBirth = subscriptionconfiguration.MinDateValue.AddDays(rnd.Next(0, numberOfDaysInDateInterval));

                    currentMinNumbers.DateOfBirthMinNumber++;
                }
                if (minNumbers.HeightMinNumber > currentMinNumbers.HeightMinNumber)
                {
                    // Generate subscription with field "Height"
                    height = Random(subscriptionconfiguration.MinHeightValue, subscriptionconfiguration.MaxHeightValue);

                    currentMinNumbers.HeightMinNumber++;
                }
                if (minNumbers.HeartRateMinNumber > currentMinNumbers.HeartRateMinNumber)
                {
                    // Generate subscription with field "HeartRate"
                    heartRate = Random(subscriptionconfiguration.MinHeartRateValue, subscriptionconfiguration.MaxHeartRateValue);

                    currentMinNumbers.HeartRateMinNumber++;
                }

                #endregion Generate subscription with the required occurence percentage for each field 

                #region Generate subscription with the required occurence percentage of operator "="

                if (minEqualNumbers.MinDateOfBirthEquals > currentMinEqualNumbers.MinDateOfBirthEquals)
                {
                    // Generate subcription with option "DateOfBirth","=","..."
                    if (dateOfBirth != DateTime.Parse("01.01.1900"))
                    {
                        dateOfBirthOption = new Option
                        {
                            Field = "DateOfBirth",
                            Op = equalOperator,
                            Value = dateOfBirth.ToString()
                        };

                        currentMinEqualNumbers.MinDateOfBirthEquals++;
                    }
                    else
                    {
                        dateOfBirthOption = new Option
                        {
                            Field = "DateOfBirth",
                            Op = operators[rnd.Next(operators.Count)],
                            Value = dateOfBirth.ToString()
                        };
                    }
                }
                if (minEqualNumbers.MinHeightEquals > currentMinEqualNumbers.MinHeightEquals)
                {
                    // Generate subcription with option "Height","=","..."
                    if (height != 0)
                    {
                        heightOption = new Option
                        {
                            Field = "Height",
                            Op = equalOperator,
                            Value = height.ToString()
                        };

                        currentMinEqualNumbers.MinHeightEquals++;
                    }
                    else
                    {
                        heightOption = new Option
                        {
                            Field = "Height",
                            Op = operators[rnd.Next(operators.Count)],
                            Value = height.ToString()
                        };
                    }
                }
                if (minEqualNumbers.MinHeartRateEquals > currentMinEqualNumbers.MinHeartRateEquals)
                {
                    // Generate subcription with option "HeartRate","=","..."
                    if (height != 0)
                    {
                        heartRateOption = new Option
                        {
                            Field = "HeartRate",
                            Op = equalOperator,
                            Value = heartRate.ToString()
                        };

                        currentMinEqualNumbers.MinHeartRateEquals++;
                    }
                    else
                    {
                        heartRateOption = new Option
                        {
                            Field = "HeartRate",
                            Op = operators[rnd.Next(operators.Count)],
                            Value = heartRate.ToString()
                        };
                    }
                }

                #endregion Generate subscription with the required occurence percentage of operator "="

                var subscription = new Subscription
                {
                    PatientName = subscriptionconfiguration.PatientNames[rnd.Next(subscriptionconfiguration.PatientNames.Count)],

                    EyeColor = subscriptionconfiguration.EyeColors[rnd.Next(subscriptionconfiguration.EyeColors.Count)],

                    DateOfBirth = dateOfBirthOption,

                    Height = heightOption,

                    HeartRate = heartRateOption
                };

                subscriptions.Add(subscription);
            }

            return subscriptions;
        }

        private double Random(double min, double max)
        {
            return Math.Round(rnd.NextDouble() * (max - min) + min, 2);
        }

        private int Random(int min, int max)
        {
            return rnd.Next(min, max);
        }
    }
}