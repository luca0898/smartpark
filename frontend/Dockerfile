FROM node:22.13.1-alpine AS build

WORKDIR /app
COPY package.json package-lock.json ./
RUN npm install --frozen-lockfile
# Instala o TypeScript globalmente (se necessário)
# RUN npm install -g typescript

COPY . .
RUN npm run build
FROM alpine:latest AS runtime

WORKDIR /app
COPY --from=build /app/dist /app
CMD ["sh", "-c", "python3 -m http.server 5173"]
