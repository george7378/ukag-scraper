namespace UKAGScraper.Scrapers
{
    public abstract class Scraper<TInput, TOutput>
    {
        public async Task<List<TOutput>> ScrapeAsync(TInput[] inputs)
        {
            List<Task<TOutput>> scrapingTasks = new List<Task<TOutput>>();
            foreach (TInput input in inputs)
            {
                scrapingTasks.Add(Task.Run(async () => await ScrapeAsync(input)));
            }

            var scrapingResults = await Task.WhenAll(scrapingTasks);

            return scrapingResults.ToList();
        }

        public abstract Task<TOutput> ScrapeAsync(TInput input);
    }
}
