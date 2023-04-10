# Burger

---

Burger is a backend API built with dotnet core 6.0 and Mongo 6 (ssr supported).

## API Demostration

GIF 3M

![ancorazor gif demostration](https://s2.ax1x.com/2019/06/28/ZMxQs0.gif)


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

Refer to [azure-pipelines.yml](https://github.com/siegrainwong/ancorazor/blob/master/azure-pipelines.yml).

