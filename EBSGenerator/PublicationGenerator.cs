using System;
using System.Collections.Generic;

namespace EBSGenerator
{
    internal class PublicationGenerator
    {
        private List<Publication> publications;
        private readonly Random rnd = new Random(); 

        public List<Publication> Generate(PublicationConfiguration publicationConfiguration, int noOfMessages)
        {
            publications = new List<Publication>();

            for (var i = 0; i < noOfMessages; i++)
            {
                var numberOfDaysInDateInterval = (publicationConfiguration.MaxDateValue - publicationConfiguration.MinDateValue).Days;

                var publication = new Publication
                {
                    PatientName = publicationConfiguration.PatientNames[rnd.Next(publicationConfiguration.PatientNames.Count)],
                    EyeColor = publicationConfiguration.EyeColors[rnd.Next(publicationConfiguration.EyeColors.Count)],
                    DateOfBirth = publicationConfiguration.MinDateValue.AddDays(rnd.Next(0, numberOfDaysInDateInterval)),
                    Height = Random(publicationConfiguration.MinHeightValue, publicationConfiguration.MaxHeightValue),
                    HeartRate = Random(publicationConfiguration.MinHeartRateValue, publicationConfiguration.MaxHeartRateValue)
                };

                publications.Add(publication);
            }

            return publications;
        }

        private int Random(int min, int max)
        {
            return rnd.Next(min, max);
        }

        private double Random(double min, double max)
        {
            return Math.Round(rnd.NextDouble() * (max - min) + min, 2);
        }
    }
}