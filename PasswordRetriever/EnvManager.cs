#nullable disable
using System.Text;

namespace PasswordRetriever;

public class EnvManager
{
  public Secrets Secrets { get; set; }

  public EnvManager(string envPath)
  {
    FileStream fileStream = new FileStream(envPath, FileMode.Open, FileAccess.Read);
    //TODO: if the file is empty, create a new key and write it to the file

    var stringSecrets = new Dictionary<string, string>();

    using StreamReader reader = new StreamReader(fileStream);
    var index = 0;
    var currentLine = "";
    try
    {
      while (!reader.EndOfStream)
      {
        currentLine = reader.ReadLine()!;
        if (String.IsNullOrWhiteSpace(currentLine))
          continue;
        stringSecrets.Add(currentLine.Split("=")[0], currentLine.Split("=")[1]);
        index++;
      }
    }
    catch (Exception)
    {
      Console.Error.WriteLine($"Error reading line {index}: {currentLine}");
    }
    finally
    {
      reader.Close();
    }
    
    ProcessSecrets(stringSecrets);
  }

  private void ProcessSecrets(Dictionary<string, string> stringSecrets)
  {
    try
    {
      var clientId = stringSecrets["INFISICAL_CLIENT_ID"] ?? throw new Exception("INFISICAL_CLIENT_ID not found");
      var clientSecret = stringSecrets["INFISICAL_CLIENT_SECRET"] ??
                         throw new Exception("INFISICAL_CLIENT_SECRET not found");
      var siteUrl = stringSecrets["INFISICAL_URL"] ?? throw new Exception("INFISICAL_URL not found");
      var totpKey = Encoding.ASCII.GetBytes(stringSecrets["TOTP_KEY"]) ?? throw new Exception("TOTP_KEY not found");
      Secrets = new Secrets
      {
        ClientId = clientId,
        ClientSecret = clientSecret,
        SiteUrl = siteUrl,
        TotpKey = totpKey
      };
    }
    catch (Exception e)
    {
      Console.Error.WriteLine(e.Message);
    }
  }
}