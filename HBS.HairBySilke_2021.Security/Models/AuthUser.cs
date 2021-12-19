namespace HBS.HairBySilke_2021.Security.Models
{
    public class AuthUser
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? HashedPassword { get; set; }
        public byte[]? Salt { get; set; }
    }
}