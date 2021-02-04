namespace DevTrack.Foundation.Services
{
    public interface IBitMapAdapter
    {
        (ISnapShotAdapter image, string fileLoaction) GenerateSnapshot();
    }
}