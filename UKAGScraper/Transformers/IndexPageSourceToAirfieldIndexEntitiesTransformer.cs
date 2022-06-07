using HtmlAgilityPack;
using UKAGScraper.Constants;
using UKAGScraper.Entities;
using UKAGScraper.Transformers.Interfaces;

namespace UKAGScraper.Transformers
{
    public class IndexPageSourceToAirfieldIndexEntitiesTransformer : ITransformer<string, List<AirfieldIndexEntity>>
    {
        public async Task<List<AirfieldIndexEntity>> TransformAsync(string indexPageSource)
        {
            List<AirfieldIndexEntity> result = new List<AirfieldIndexEntity>();

            await Task.Run(() =>
            {
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(indexPageSource);

                HtmlNodeCollection airfieldIndexNodes = htmlDocument.DocumentNode.SelectNodes(ConstantValues.AirfieldIndexPageIndexNodeXPath);
                if (airfieldIndexNodes != null)
                {
                    foreach (HtmlNode airfieldIndexNode in airfieldIndexNodes)
                    {
                        string name = airfieldIndexNode.InnerHtml.Split(ConstantValues.AirfieldIndexNodeNameSplitToken).ElementAt(0);
                        string url = string.Format("{0}{1}", ConstantValues.BaseUrl, airfieldIndexNode.Attributes[ConstantValues.AirfieldIndexNodeUrlAttributeName].Value);

                        result.Add(new AirfieldIndexEntity(name, url));
                    }
                }
            });

            return result;
        }
    }
}
