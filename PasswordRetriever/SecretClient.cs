using Infisical.Sdk;

namespace PasswordRetriever;

public class SecretClient
{
  private readonly InfisicalClient _client;

  public SecretClient(EnvManager envManager)
  {
    var envManager1 = envManager;
    var settings = new ClientSettings
    {
      SiteUrl = envManager1.Secrets.SiteUrl,
      Auth = new AuthenticationOptions
      {
        UniversalAuth = new UniversalAuthMethod
        {
          ClientId = envManager1.Secrets.ClientId,
          ClientSecret = envManager1.Secrets.ClientSecret,
        }
      }
    };
    _client = new InfisicalClient(settings);
  }
  
  public void GetPassword(string machineName)
  {
    if(!MachineName.IsValid(machineName))
    {
      Console.Error.WriteLine($"Invalid machine name: {machineName}");
      return;
    }
    
    var getSecretOptions = new GetSecretOptions
    {
      SecretName = machineName,
      ProjectId = "4fbd3fb6-5521-4ae8-8887-972a4f7c2acb",
      Environment = "pass",
    };
    Console.WriteLine(_client.GetSecret(getSecretOptions).SecretValue);
  }
}

public static class MachineName
{
  public const string Containerd = "CONTAINERD";
  public const string Immich = "IMMICH";
  public const string Mqtt = "MQTT";
  public const string WebHost = "WEB_HOST";
  
  public static bool IsValid(string machineName)
  {
    return machineName switch
    {
      Containerd => true,
      Immich => true,
      Mqtt => true,
      WebHost => true,
      _ => false
    };
  }
}