using SmartBuildingServer.Application.Services;
using System.Security.Cryptography;

namespace SmartBuildingServer.Infrastructure.Services;
internal class Generate : IGenerate
{
    public string GenerateSecretKey()
    {
        using (var hmac = new HMACSHA256())
        {
            var key = Convert.ToBase64String(hmac.Key);
            return key.Replace("+", "").Replace("/", "").Replace("=", "");
        }
    }
}
