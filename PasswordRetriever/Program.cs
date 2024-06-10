// See https://aka.ms/new-console-template for more information

using System.Text;
using OtpNet;
using PasswordRetriever;

try
{
  var machineName = args[0] ?? throw new ArgumentNullException("machineName", "Machine name is required");
  if(!MachineName.IsValid(machineName))
  {
    Console.Error.WriteLine($"Invalid machine name: {machineName}");
    return;
  }
  var envPath = ".env";
  if (args.Length > 1)
  {
    envPath = args[1];
  }

  var envManager = new EnvManager(envPath);
  var secretClient = new SecretClient(envManager);

//TODO: show uri if generated
// var uriString = new OtpUri(OtpType.Totp, key, "sambobbarnes", "Server Pass Retriever").ToString();
// Console.WriteLine("The URI is: {0}", uriString);

  var totp = new Totp(envManager.Secrets.TotpKey);

  Console.WriteLine("Enter the TOTP: ");
  var input = Console.ReadLine();

  var valid = totp.VerifyTotp(input, out _);

  if (!valid)
    Console.WriteLine("The input: {0} is invalid", input);
  else
    secretClient.GetPassword(machineName);
}
catch (ArgumentNullException)
{
  EnvManager.HelpText();
}