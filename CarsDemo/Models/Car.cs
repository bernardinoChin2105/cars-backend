using Microsoft.EntityFrameworkCore;

namespace CarsDemo.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Car()
        {
            this.Name = string.Empty;
            this.Model = string.Empty;
        }
    }
}
