namespace UKAGScraper.Entities
{
    public class AirfieldIndexEntity
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public AirfieldIndexEntity(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}
