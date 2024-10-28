namespace Advertisement.Entites
{

    // UserVideo entity for tracking which videos a user has watched
    public class UserVideo
    {
        public int UserVideoId { get; set; }
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public DateTime WatchedOn { get; set; }
        public User? User { get; set; }
        public Video? Video { get; set; }
    }

}
