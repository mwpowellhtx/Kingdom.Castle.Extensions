# Overview

The most recent commitments have broken the interface a little bit, but not much.

## Usage

Usage is focused around [OWIN](http://www.nuget.org/packages/Owin/) self-hosting for the moment, starting from ``Kingdom.Web.Http.Startup`` which starts by configuring an instance of ``Castle.Windsor.IWindsorContainer``, immediately followed by configuring an instance of ``System.Web.Http.HttpConfiguration``. Finally the ``Owin.IAppBuilder`` is instructed to use the *config*.

## Step by step

### Configure the ``HttpConfiguration``

```C#
protected HttpConfiguration Config { get; }
// Ctor initialization assuming C# 6.0 language features
Config = new HttpConfiguration();
```

### Configure the ``IWindsorContainer``

```C#
protected IWindsorContainer Container { get; }
// Ctor initialization assuming C# 6.0 language features
Container = new WindsorContainer();
```

### Configure the ``IAppBuilder`` via your ``Startup.Configuration(IAppBuilder)`` method

```C#
// Configures the Container for use with Web API 2
Container.ConfigureApi<StartupFixture>(Config);
```

Then perform additional ``HttpConfiguration``.

```C#
// Configures the HttpConfiguration
Config.UseWindsorDependencyResolver(Container)
    .MapHttpAttributeRoutes()
    ;
```

Configuring ``MapHttpAttributeRoutes`` is fairly routine. The key here, however, is to invoke ``UseWindsorDependencyResolver`` in order to connect the dots.

```C#
Config.Routes.MapHttpRoute(
    "DefaultApi", "api/{controller}/{id}",
    new {id = RouteParameter.Optional});
```

Configuring your routes is also a fairly routine thing to want to do.

Finally, simply instruct the application to use the configuration.

```C#
app.UseWebApi(Config);
```

## Conclusion

That's it. Enjoy!
