using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBSGenerator
{
    internal class SubscriptionConfiguration
    {
        public int NoOfMessages = 100;

        public List<string> PatientNames { get; set; } = new List<string>()
        {
            "Mary Ann", "Jim Smith", "John Doe", "Joe Smith"
        };

        public List<string> EyeColors { get; set; } = new List<string>()
        {
            "Blue", "Green", "Black", "Brown"
        };

        public double MinHeightValue { get; set; } = 0.2; // meters

        public double MaxHeightValue { get; set; } = 2.5; // meters

        public int MinHeartRateValue { get; set; } = 50;

        public int MaxHeartRateValue { get; set; } = 180;

        public DateTime MinDateValue { get; set; } = DateTime.Parse("01.01.1900");

        public DateTime MaxDateValue { get; set; } = DateTime.Today;

        public double HeightFrequency { get; set; } = 90;
    }
}
