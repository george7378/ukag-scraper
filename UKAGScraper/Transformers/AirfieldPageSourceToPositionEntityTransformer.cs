using System.Text.RegularExpressions;
using UKAGScraper.Constants;
using UKAGScraper.Entities;
using UKAGScraper.Transformers.Interfaces;

namespace UKAGScraper.Transformers
{
    public class AirfieldPageSourceToPositionEntityTransformer : ITransformer<string, PositionEntity>
    {
        private readonly Regex _positionRegex;

        public AirfieldPageSourceToPositionEntityTransformer()
        {
            _positionRegex = new Regex(ConstantValues.AirfieldPagePositionRegexPattern);
        }

        public async Task<PositionEntity> TransformAsync(string airfieldPageSource)
        {
            PositionEntity result = null;

            await Task.Run(() =>
            {
                Match positionMatch = _positionRegex.Match(airfieldPageSource);
                if (positionMatch.Success)
                {
                    double latitude = double.Parse(positionMatch.Groups[1].Value);
                    double longitude = double.Parse(positionMatch.Groups[2].Value);

                    result = new PositionEntity(latitude, longitude);
                }
            });

            return result;
        }
    }
}
