# Kingdom.Castle.Extensions

This project provides basic integration with the ASP.NET Web API framework.

Bootstrapping with your project is as simple as the following lines of code:

```C#
var config = new HttpConfiguration();
WindsorBootstrapper.Register(config);
```

If you desire more control over the Windsor Container, then this is for you:

```C#
WindsorBootstrapper.Register(config
    , () => new WindsorContainer()
    );
```

Finally, if you also need more control over the ``IDependencyResolver`` itself, then perform the following.

```C#
WindsorBootstrapper.Register(config
    , () => new WindsorContainer()
    , container => new WindsorDependencyResolver(container)
    );
```

Out of the box, I provide a ```WindsorDependencyResolver``` for you. You may derive from it if you so desire, or simply use it as-is out of the box.

That's it. Enjoy!
