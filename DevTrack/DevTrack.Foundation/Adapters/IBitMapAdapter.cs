namespace DevTrack.Foundation.Services.Adapters
{
    public interface IBitMapAdapter
    {
        (ISnapShotAdapter image, string fileLoaction) GenerateSnapshot();
    }
}