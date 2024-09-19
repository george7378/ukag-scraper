namespace UKAGScraper.Transformers.Interfaces
{
    public interface ITransformer<TInput, TOutput>
    {
        public Task<TOutput> TransformAsync(TInput input);
    }
}
