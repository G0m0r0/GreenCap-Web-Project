namespace GreenCap.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CurrentYearMaxValueAttribute : ValidationAttribute
    {
        public CurrentYearMaxValueAttribute(int minYear)
        {
            this.MinYear = minYear;
            this.ErrorMessage = $"Value should be between {minYear} and {DateTime.UtcNow.Year}.";
        }

        public int MinYear { get; }

        public override bool IsValid(object value)
        {
            if (value is int intValue
                && intValue <= DateTime.UtcNow.Year
                && intValue >= this.MinYear)
            {
                return true;
            }

            return false;
        }
    }
}
