namespace API.Extensions;

public static class DateTimeExtensions
{
    public static int CalculateAge(this DateOnly dob)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        var age = today.Year - dob.Year;

        // didnt have birtdhay yet
        if (dob > today.AddYears(-age))
        {
            age--;
        }
        // leap year not handled
        return age;
    }
}
