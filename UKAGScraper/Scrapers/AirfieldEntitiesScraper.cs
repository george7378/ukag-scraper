using UKAGScraper.Entities;
using UKAGScraper.Transformers;
using UKAGScraper.UrlSourceProviders;

namespace UKAGScraper.Scrapers
{
    public class AirfieldEntitiesScraper : Scraper<List<AirfieldIndexEntity>, List<AirfieldEntity>>
    {
        private readonly WebAddressUrlSourceProvider _sourceProvider;

        private readonly AirfieldPageSourceToPositionEntityTransformer _transformer;

        private readonly int _delayIntervalMs;

        private readonly IProgress<int> _progress;

        public AirfieldEntitiesScraper(WebAddressUrlSourceProvider sourceProvider, AirfieldPageSourceToPositionEntityTransformer transformer, int delayIntervalMs, IProgress<int> progress)
        {
            _sourceProvider = sourceProvider;
            _transformer = transformer;
            _delayIntervalMs = delayIntervalMs;
            _progress = progress;
        }

        public override async Task<List<AirfieldEntity>> ScrapeAsync(List<AirfieldIndexEntity> airfieldIndexEntities)
        {
            List<AirfieldEntity> result = new List<AirfieldEntity>();

            foreach (AirfieldIndexEntity airfieldIndexEntity in airfieldIndexEntities)
            {
                string airfieldUrlSource = await _sourceProvider.GetSourceAsync(airfieldIndexEntity.Url);

                await Task.Delay(_delayIntervalMs);

                PositionEntity positionEntity = await _transformer.TransformAsync(airfieldUrlSource);

                result.Add(new AirfieldEntity(airfieldIndexEntity.Name, positionEntity, airfieldIndexEntity.Url));

                _progress.Report(1);
            }

            return result;
        }
    }
}
