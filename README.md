# Футбольный Менеджер

Веб-приложение для управления футбольными командами и игроками. Проект состоит из backend API на .NET 10 и frontend части на HTML/JavaScript.

## Структура проекта

- **FootballApi/** - Backend часть на .NET 10
  - `Api/` - REST API контроллеры
  - `Application/` - Бизнес-логика и сервисы
  - `Domain/` - Доменные модели и интерфейсы
  - `Infrastructure/` - Работа с базой данных и внешними сервисами

- **Front/** - Frontend часть
  - `Create/` - Страница создания/редактирования
  - `View/` - Страница просмотра
  
- **DataBase/** - SQLite база данных

## Требования

- Docker
- Docker Compose

## Запуск приложения

1. Клонируйте репозиторий:
```bash
git clone git@github.com:flashikNet/FootballWeb.git
cd FootballWeb
```

2. Запустите приложение с помощью Docker Compose:
```bash
docker-compose up --build
```

3. После успешного запуска:
   - Проект доступен по адресу: http://localhost:80

## Особенности

- Backend построен на .NET 10 Preview
- Frontend использует чистый JavaScript без фреймворков
- Данные хранятся в SQLite
- Контейнеризация с помощью Docker
- Nginx используется как веб-сервер для frontend части

## Volumes

Проект использует Docker volumes для:
- Сохранения данных БД между перезапусками (`./DataBase:/DataBase`)
- Разработки frontend части в реальном времени (`./Front/Create:/usr/share/nginx/html/Create`, `./Front/View:/usr/share/nginx/html/View`)
