namespace CarsDemo.Models
{
    public class CarsResponse
    {
        public  int CarId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public CarsResponse()
        {
            this.Name = string.Empty;
            this.Model = string.Empty;
        }
    }
}
