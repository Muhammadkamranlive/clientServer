using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.CustomValidators
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date > DateTime.Now;
            }

            return false; // Return false if the value is not a DateTime
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} must be a future date.";
        }
    }
}
