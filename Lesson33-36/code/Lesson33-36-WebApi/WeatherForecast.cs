using System;

namespace Lesson30_WebApi
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public interface IUser 
    {
        string GetFullName();

        string SetFullName(string fullName);
    }

    public class User : IUser
    {
        public string Name { get; set; }

        public string GetFullName()
        {
            return "Filakes Filankesov";
        }

        public string SetFullName(string fullName)
        {
            Name = fullName;

            return Name;
        }
    }
}
