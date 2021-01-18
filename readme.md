## Использование

### Запуск MQTT-сервера
    
    PS> dotnet run --project .\InternetOfThings\ -- start-server --ip-address 127.0.0.1 --port 1883

| Параметр | Значение
|----------|---------
|ip-address| URL MQTT-сервера.
|port      | Порт, прослушиваемый MQTT-сервером.
|i         | Идентфикаторы датчиков, перечисленные через пробел.

### Запуск mock-объекта

    PS> dotnet run --project .\InternetOfThings\ -- start-object -i "Датчик 1" "Датчик 2" "Датчик 3" --ip-address 127.0.0.1 --port 1883

| Параметр | Значение
|----------|---------
|ip-address| URL MQTT-сервера.
|port      | Порт, прослушиваемый MQTT-сервером.
|i         | Идентфикаторы датчиков, перечисленные через пробел.

