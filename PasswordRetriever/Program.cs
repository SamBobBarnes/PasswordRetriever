﻿// See https://aka.ms/new-console-template for more information

using System.Text;
using OtpNet;

var envPath = args[0] ?? ".env";

FileStream fileStream = new FileStream(envPath, FileMode.Open, FileAccess.Read);

using StreamReader reader = new StreamReader(fileStream);
var key = Encoding.ASCII.GetBytes(reader.ReadLine()!.Split("=")[1]);
reader.Close();

var totp = new Totp(key);

var uriString = new OtpUri(OtpType.Totp, key, "sambobbarnes", "Server Pass Retriever").ToString();
Console.WriteLine("The URI is: {0}", uriString);

Console.WriteLine("The current TOTP is: {0}", totp.ComputeTotp());
Console.WriteLine("Enter the TOTP: ");
var input = Console.ReadLine();

var valid = totp.VerifyTotp(input, out _);

Console.WriteLine("The input: {0} is {1}", input, valid ? "valid" : "invalid");