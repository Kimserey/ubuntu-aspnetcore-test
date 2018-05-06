# ASP NET Core behind nginx on Ubuntu

This is a project used to test the funtionalities of nginx on Ubuntu.

## SSH to instance

```
ssh -i key.pem ubuntu@[IP]
```

## Copy to instance

```
scp -r -i key.pem /mnt/c/Projects/UbuntuTest/UbuntuTest/bin/Release/PublishOutput/* ubuntu@[IP]:/home/ubuntu
```

## Systemd

Check logs

```
journalctl -f
```

If we have created a service `app-web.service`.

```
In /etc/systemd/system/app-web.service

[Unit]
Description=Test WEB dotnet

[Service]
WorkingDirectory=/app/web
ExecStart=/usr/bin/dotnet /app/web/UbuntuTestWeb.dll
Restart=always
RestartSec=10
SyslogIdentifier=app-web
User=www-data
Environment=ASPNETCORE_ENVIRONMENT=Production

[Install]
WantedBy=multi-user.target
```

Start service

```
sudo systemctl start app-web
```

Stop service

```
sudo systemctl stop app-web
```

Status service

```
sudo systemctl status app-web
```