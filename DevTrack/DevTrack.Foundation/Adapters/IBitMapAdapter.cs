namespace DevTrack.Foundation.Adapters
{
    public interface IBitMapAdapter
    {
        (ISnapShotAdapter image, string fileLoaction) GenerateSnapshot();
    }
}