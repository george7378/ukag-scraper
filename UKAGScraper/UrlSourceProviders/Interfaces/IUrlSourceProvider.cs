namespace UKAGScraper.UrlSourceProviders.Interfaces
{
    public interface IUrlSourceProvider<TInput>
    {
        public Task<string> GetSourceAsync(TInput input);
    }
}
