namespace Advertisement.Entites
{
    // User entity
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int CreditBalance { get; set; }
        public ICollection<UserVideo> UserVideos { get; set; }
    }

}
