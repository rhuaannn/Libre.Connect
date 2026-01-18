namespace Libre.Connect.Redis.Redis;

public class CacheSettings
{
    public int AbsoluteExpirationInMinutes { get; set; }
    public int SlidingExpirationInMinutes { get; set; }
}