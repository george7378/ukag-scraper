using SharpKml.Dom;
using SharpKml.Engine;
using UKAGScraper.Constants;
using UKAGScraper.Entities;
using UKAGScraper.Scrapers;
using UKAGScraper.Transformers;
using UKAGScraper.UrlSourceProviders;

namespace UKAGScraper
{
    internal class Program
    {
        private static int _airfieldsScraped;

        private static readonly object _progressChangedLockObject = new object();

        private static void Progress_ProgressChanged(object sender, int e)
        {
            lock (_progressChangedLockObject)
            {
                _airfieldsScraped += e;

                Console.SetCursorPosition(0, 3);
                Console.Write(string.Format("-> {0} airfields scraped", _airfieldsScraped));
            }
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Indexing airfields...");

            string[] airfieldIndexPageUrls = ConstantValues.Alphabet.Select(c => string.Format("{0}{1}{2}", ConstantValues.BaseUrl, ConstantValues.DatabaseUrlSuffix, c)).ToArray();

            AirfieldIndexEntitiesScraper airfieldIndexEntitiesScraper = new AirfieldIndexEntitiesScraper(new WebAddressUrlSourceProvider(new HttpClient()), new IndexPageSourceToAirfieldIndexEntitiesTransformer());
            List<List<AirfieldIndexEntity>> airfieldIndexEntities = await airfieldIndexEntitiesScraper.ScrapeAsync(airfieldIndexPageUrls);

            Console.WriteLine(string.Format("-> {0} airfields discovered", airfieldIndexEntities.Select(l => l.Count).Sum()));

            Console.WriteLine("Scraping airfields...");

            Progress<int> progress = new Progress<int>();
            progress.ProgressChanged += Progress_ProgressChanged;

            AirfieldEntitiesScraper airfieldEntitiesScraper = new AirfieldEntitiesScraper(new WebAddressUrlSourceProvider(new HttpClient()), new AirfieldPageSourceToPositionEntityTransformer(), ConstantValues.AirfieldScrapingDelayIntervalMs, progress);
            List<List<AirfieldEntity>> airfieldEntities = await airfieldEntitiesScraper.ScrapeAsync(airfieldIndexEntities.ToArray());

            Console.SetCursorPosition(0, 4);
            Console.Write("Saving KML...");

            AirfieldEntitiesToKmlTransformer airfieldEntitiesToKmlTransformer = new AirfieldEntitiesToKmlTransformer();
            Kml ukagKml = await airfieldEntitiesToKmlTransformer.TransformAsync(airfieldEntities.SelectMany(l => l).ToList());

            using (FileStream fileStream = File.Create(ConstantValues.AirfieldsKmlOutputFileName))
            {
                KmlFile.Create(ukagKml, false).Save(fileStream);
            }

            Console.SetCursorPosition(0, 5);
            Console.WriteLine("Complete");

            Console.ReadLine();
        }
    }
}