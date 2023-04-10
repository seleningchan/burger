# Burger

Burger is a backend API built with dotnet core 6.0 and Mongo 6 (ssr supported).

Context and container diagram

![ancorazor gif demostration](https://img2023.cnblogs.com/blog/780669/202304/780669-20230410203922788-1838631097.png)
![ancorazor gif demostration1](https://img2023.cnblogs.com/blog/780669/202304/780669-20230410203913440-1422799831.png)

## API Demostration

![ancorazor gif demostration](https://img2023.cnblogs.com/blog/780669/202304/780669-20230410202828515-1626686015.png)


## Getting start

### Requirements

Make sure your machine has these dependancies installed.

1. .NET Core 6.0 SDK
2. Mongo 6+

### Build

1. `git clone https://github.com/seleningchan/burger.git`
2. Replace connection string in `src/Conley.SocialPlatform.Bugers.API/appsettings.Development.json`(optional, depends on your use case)
3. `cd path-to-src/Conley.SocialPlatform.Bugers.API` then `dotnet watch run`
4. Open `localhost:8088`.

## Release(CI/CD)

Refer to [azure-pipelines.yml](https://github.com/seleningchan/burger/blob/main/azure-pipelines.yml).

