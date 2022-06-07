namespace UKAGScraper.Constants
{
    public static class ConstantValues
    {
        public const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public const int AirfieldScrapingDelayIntervalMs = 250; // Perhaps a good idea to throttle requests, preventing the server from flagging our scrapes as an attack!
        
        public const string BaseUrl = @"https://www.ukairfieldguide.net";

        public const string DatabaseUrlSuffix = @"/database.php?term=";

        public const string AirfieldIndexPageIndexNodeXPath = @"//section[@id='column2']//ul//a[@href]";

        public const string AirfieldIndexNodeNameSplitToken = " - ";

        public const string AirfieldIndexNodeUrlAttributeName = "href";

        public const string AirfieldPagePositionRegexPattern = @"position\s*:\s*{\s*lat\s*:\s*(\S*)\s*,\s*lng\s*:\s*(\S*)\s*}";

        public const string AirfieldsKmlFolderName = "Airfields";

        public const string AirfieldsKmlOutputFileName = @"ukag.kml";
    }
}
