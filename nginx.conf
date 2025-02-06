# Redirecionamento HTTP para HTTPS
server {
  listen 80;
  server_name api.smartpark.local frontend.smartpark.local;

  location / {
    return 301 https://$host$request_uri;
  }
}

# Configuração para a API
server {
  listen 443 ssl;
  server_name api.smartpark.local;

  ssl_certificate /etc/ssl/certs/api.smartpark.local.pem;
  ssl_certificate_key /etc/ssl/certs/api.smartpark.local-key.pem;

  # Configurações de segurança para SSL
  ssl_protocols TLSv1.2 TLSv1.3;
  ssl_ciphers 'ECDHE-ECDSA-AES128-GCM-SHA256:ECDHE-RSA-AES128-GCM-SHA256:AES128-GCM-SHA256';
  ssl_prefer_server_ciphers off;
  ssl_dhparam /etc/nginx/dhparam.pem;

  location / {
    proxy_pass http://api:5001;  # Proxiar para a API na porta HTTPS
    proxy_set_header Host $host;
    proxy_set_header X-Real-IP $remote_addr;
    proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
    proxy_set_header X-Forwarded-Proto $scheme;
  }
}

# Configuração para o Frontend
server {
  listen 443 ssl;
  server_name frontend.smartpark.local;

  ssl_certificate /etc/ssl/certs/frontend.smartpark.local.pem;
  ssl_certificate_key /etc/ssl/certs/frontend.smartpark.local-key.pem;

  location / {
    proxy_pass http://frontend:5173;  # Proxiar para o frontend Vite
    proxy_set_header Host $host;
    proxy_set_header X-Real-IP $remote_addr;
    proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
    proxy_set_header X-Forwarded-Proto $scheme;
  }
}
