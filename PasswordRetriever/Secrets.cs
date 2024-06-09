#nullable disable
namespace PasswordRetriever;

public class Secrets
{
  public string ClientId { get; init; }
  public string ClientSecret { get; init; }
  public byte[] TotpKey { get; init; }
  public string SiteUrl { get; init; }
}