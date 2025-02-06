# Estágio de build
FROM node:22.13.1-alpine AS build

# Instalar Python3 e pip (necessário para o http.server)
RUN apk add --no-cache python3 py3-pip

# Definir o diretório de trabalho
WORKDIR /app

# Copiar o package.json e package-lock.json
COPY package.json package-lock.json ./

# Instalar as dependências do projeto
RUN npm install --frozen-lockfile

# Copiar o restante do código
COPY . .

# Rodar o build do Vite
RUN npm run build

# Estágio de runtime
FROM alpine:latest AS runtime

# Instalar Python3 para rodar o http.server
RUN apk add --no-cache python3

# Definir o diretório de trabalho
WORKDIR /app

# Copiar os arquivos gerados no build
COPY --from=build /app/dist /app

# Comando para rodar o servidor HTTP com Python
CMD ["sh", "-c", "python3 -m http.server 5173"]
