using SharpKml.Base;
using SharpKml.Dom;
using UKAGScraper.Constants;
using UKAGScraper.Entities;
using UKAGScraper.Transformers.Interfaces;

namespace UKAGScraper.Transformers
{
    public class AirfieldEntitiesToKmlTransformer : ITransformer<List<AirfieldEntity>, Kml>
    {
        public async Task<Kml> TransformAsync(List<AirfieldEntity> airfieldEntities)
        {
            Kml result = new Kml();

            await Task.Run(() =>
            {
                Folder folder = new Folder()
                {
                    Name = ConstantValues.AirfieldsKmlFolderName
                };

                foreach (AirfieldEntity airfieldEntity in airfieldEntities)
                {
                    if (airfieldEntity.Position != null)
                    {
                        Placemark placemark = new Placemark()
                        {
                            Name = airfieldEntity.Name,
                            Geometry = new Point()
                            {
                                Coordinate = new Vector(airfieldEntity.Position.Latitude, airfieldEntity.Position.Longitude)
                            },
                            Description = new Description()
                            {
                                Text = airfieldEntity.Url
                            }
                        };

                        folder.AddFeature(placemark);
                    }
                }

                result.Feature = folder;
            });

            return result;
        }
    }
}
