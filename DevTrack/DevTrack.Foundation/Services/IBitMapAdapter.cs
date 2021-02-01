namespace DevTrack.Foundation.Services
{
    public interface IBitMapAdapter
    {
        (IAdapter image, string fileLoaction) GenerateSnapshot2();
    }
}