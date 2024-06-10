#!/bin/bash

echo "Enter machine name in caps: "
read machineName
mkdir /opt/password
cp PasswordRetriever /opt/password/PasswordRetriever
cp libinfisical_c.so /opt/password/libinfisical_c.so
printf "TOTP_KEY=\nINFISICAL_CLIENT_ID=\nINFISICAL_CLIENT_SECRET=\nINFISICAL_URL=" > /opt/password/.env
mkdir /opt/password/bin
printf "#! /bin/bash \n\nPasswordRetriever ${machineName} ../.env" > /opt/password/bin/password
chmod +x /opt/password/bin/password
ln -sf /opt/password/bin/password /usr/bin/password