namespace Book.uz.Option;

public class JwtOption
{
    public required string SigningKey { get; set; }
    public required string ValidAudience { get; set; }
    public required string ValidIssuer { get; set; }
    public int ExpiresInMinutes { get; set; }
}