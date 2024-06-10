#!/bin/bash

echo "Enter machine name in caps: "
read machineName
mv PasswordRetriever /opt/password/PasswordRetriever
mv libinfisical_c.so /opt/password/libinfisical_c.so
printf "TOTP_KEY=\nINFISICAL_CLIENT_ID=\nINFISICAL_CLIENT_SECRET=\nINFISICAL_URL=" > /opt/password/.env
mkdir /opt/password/bin
printf "#! /bin/bash \n\n./PasswordRetriever ${machineName} ../.env" > /opt/password/bin/password
chmod +x /opt/password/bin/password