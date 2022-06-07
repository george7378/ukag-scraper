using UKAGScraper.Entities;
using UKAGScraper.Transformers;
using UKAGScraper.UrlSourceProviders;

namespace UKAGScraper.Scrapers
{
    public class AirfieldIndexEntitiesScraper : Scraper<string, List<AirfieldIndexEntity>>
    {
        private readonly WebAddressUrlSourceProvider _sourceProvider;

        private readonly IndexPageSourceToAirfieldIndexEntitiesTransformer _transformer;

        public AirfieldIndexEntitiesScraper(WebAddressUrlSourceProvider sourceProvider, IndexPageSourceToAirfieldIndexEntitiesTransformer transformer)
        {
            _sourceProvider = sourceProvider;
            _transformer = transformer;
        }

        public override async Task<List<AirfieldIndexEntity>> ScrapeAsync(string url)
        {
            string urlSource = await _sourceProvider.GetSourceAsync(url);

            List<AirfieldIndexEntity> airfieldIndexEntities = await _transformer.TransformAsync(urlSource);

            return airfieldIndexEntities;
        }
    }
}
