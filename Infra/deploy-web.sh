sudo mv ./PublishOutput/* /app/web/
sudo rm -r ./PublishOutput
sudo systemctl restart app-web
sudo systemctl status app-web