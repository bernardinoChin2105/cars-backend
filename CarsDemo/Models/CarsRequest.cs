namespace CarsDemo.Models
{
    public class CarsRequest
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public CarsRequest()
        {
            this.Name = string.Empty;
            this.Model = string.Empty;
        }
    }
}
