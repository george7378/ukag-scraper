namespace UKAGScraper.Entities
{
    public class PositionEntity
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public PositionEntity(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
