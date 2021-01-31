namespace DevTrack.DataAccessLayer
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
