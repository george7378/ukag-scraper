namespace UKAGScraper.Entities
{
    public class AirfieldEntity
    {
        public string Name { get; set; }

        public PositionEntity Position { get; set; }

        public string Url { get; set; }

        public AirfieldEntity(string name, PositionEntity position, string url)
        {
            Name = name;
            Position = position;
            Url = url;
        }
    }
}
