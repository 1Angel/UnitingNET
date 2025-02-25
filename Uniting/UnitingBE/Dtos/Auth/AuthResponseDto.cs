namespace UnitingBE.Dtos.Auth
{
    public class AuthResponseDto
    {
        public AuthResponseDto(string useId, string email, string access_Token)
        {
            UseId = useId;
            Email = email;
            this.access_Token = access_Token;
        }

        public string UseId { get;set; }
        public string Email { get; set; }
        public string access_Token { get; set; }


    }
}
