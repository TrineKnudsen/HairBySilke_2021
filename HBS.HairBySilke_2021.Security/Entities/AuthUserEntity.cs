namespace HBS.HairBySilke_2021.Security.Entities
{
    public class AuthUserEntity
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? HashedPassword { get; set; }
        public string? Salt { get; set; }
    }
}