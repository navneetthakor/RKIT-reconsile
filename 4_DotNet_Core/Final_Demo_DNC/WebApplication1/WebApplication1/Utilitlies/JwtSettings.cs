namespace WebApplication1.Utilitlies
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public int ExpiryInMinutes { get; set; }
    }

}
