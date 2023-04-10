using System;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public class BearerToken
{
    private const string _serverSecret = "local-token-key-1";
    private const string _issuer = "https://localhost:44399";
    private static readonly string[] _audiences = new string[]
    {
            "localhost:44398",
            "localhost:44399",
            "localhost:44395",
            "localhost:44397"
    };
    private readonly int expireMinutes = 60;
    private readonly ILogger<BearerToken> _logger;

    public BearerToken(ILogger<BearerToken> logger)
    {
        _logger = logger;
        string tokenExpireMinute = Environment.GetEnvironmentVariable("TOKEN_EXPIRE_MINUTES");
        if (!string.IsNullOrWhiteSpace(tokenExpireMinute))
        {
            _logger.LogInformation("Loaded environment variable TOKEN_EXPIRE_MINUTES with value: " + tokenExpireMinute);
            int.TryParse(tokenExpireMinute, out expireMinutes);
        }
    }

    public (string, string) CreateAsString(string soeid)
    {
        var claims = new Claim[2];
        claims[0] = new Claim(ClaimTypes.NameIdentifier, soeid);

        var utcNow = DateTime.UtcNow;
        var expireTime = utcNow.AddMinutes(expireMinutes).ToString();
        var tokenDescriptor = CreateSecurityTokenDescriptor(utcNow);
        claims[1] = new Claim(ClaimTypes.Expired, expireTime);
        tokenDescriptor.Subject = new ClaimsIdentity(claims);

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);


        return (tokenHandler.WriteToken(token), expireTime);
    }

    public SecurityTokenDescriptor CreateSecurityTokenDescriptor(DateTime utcNow)
    {
        var key = Encoding.UTF8.GetBytes(_serverSecret);
        return new SecurityTokenDescriptor
        {
            NotBefore = utcNow,
            IssuedAt = utcNow,
            Expires = utcNow.AddMinutes(expireMinutes),
            Issuer = _issuer,
            Audience = _audiences[0],
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
    }

    public static TokenValidationParameters CreateValidationParameters()
    {
        return new TokenValidationParameters
        {
            ValidIssuer = _issuer,
            ValidAudiences = _audiences,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_serverSecret)),
            ValidateLifetime = true,
            RequireExpirationTime = true,
            ClockSkew = TimeSpan.Zero,
        };
    }
}