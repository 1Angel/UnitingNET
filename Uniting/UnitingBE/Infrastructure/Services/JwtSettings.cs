namespace UnitingBE.Infrastructure.Services
{
    public class JwtSettings
    {
        public const string SectionName = "jwtSettings";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string JwtKey { get; set; }
    }
}
