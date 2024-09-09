#!/bin/bash

echo "Enter machine name in caps: "
read machineName
echo "Enter Client ID: "
read client_id
echo "Enter Client Secret: "
read client_secret
echo "Enter Secret Server Url: "
read url
echo "Enter TOTP Key: "
read totp_key
mkdir /opt/password
cp PasswordRetriever /opt/password/PasswordRetriever
cp libinfisical_c.so /opt/password/libinfisical_c.so
printf "TOTP_KEY=${totp_key}\nINFISICAL_CLIENT_ID=${client_id}\nINFISICAL_CLIENT_SECRET=${client_secret}\nINFISICAL_URL=${url}" > /opt/password/.env
mkdir /opt/password/bin
printf "#! /bin/bash \n\n/opt/password/PasswordRetriever ${machineName} /opt/password/.env" > /opt/password/bin/password
chmod +x /opt/password/bin/password
ln -sf /opt/password/bin/password /usr/bin/password
echo "Installation complete!"
echo "To retrieve password, run 'password' in terminal and enter the TOTP code when prompted."
echo