# TestWebApp

1. Запустить docker-compose.yaml. `docker-compose -f docker.compose.yaml up -d`
2. Запустить миграцию. `update-database`
3. запускаем `dotnet run` заходим на сваггер `http://localhost:5050/swagger/index.html`
4. создаем пользователя `http://localhost:5050/api/Auth/CreateUser`
   ```
   body:{
     "userName": "string",
     "password": "string"
   }
   ```
5. запрашиваем токен `http://localhost:5050/api/Auth/Login?login=string&password=string`
6. используя токен, вызываем методы `CreateTask` и `GetTask`
