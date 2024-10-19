namespace Bckend.Extensions;

public static class DateTimeExtension
{
    public static int CalculateAge(this DateOnly dot)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        
        var age = today.Year - dot.Year;

        if (dot> today.AddYears(-age))
        {
            age--;
        }

        return age;
    }
}