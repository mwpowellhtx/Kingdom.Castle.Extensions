using System;
using System.Linq;

namespace Kingdom.Web.Mvc
{
    using EnvDTE;
    using EnvDTE80;
    using Microsoft.VisualStudio.Shell;
    using Xunit;

    /// <summary>
    /// This one was DoA; I would like to do in-process unit testing that starts a second project
    /// just prior to running the test. This means I would potentially require a VSIX in order to
    /// do so since running Xunit or NUnit tests run in a separate process.
    /// 
    /// Alternatively, what I really want to do is test ASP.NET MVC with an in-process,
    /// self-hosted server, as in for Web API. It is possible with Web API., but this has not
    /// translated into MVC yet.
    /// 
    /// That I know of, this is promised for the future with vNext and MVC Core re-factoring into
    /// MVC 6. However, that has been stuck in Release Candidate land for some time. Maybe set to
    /// be released in February 2017? Will believe it when I see it.
    /// </summary>
    public class MyPackage : Package
    {
        private readonly IServiceProvider _serviceProvider;

        public MyPackage()
        {
            _serviceProvider = this;
        }

        private T GetService<T>()
        {
            return (T) GetService(typeof(T));
        }

        protected DTE2 GetActiveDevEnv()
        {
            var sdte = GetService<Microsoft.VisualStudio.Shell.Interop.SDTE>();
            Assert.NotNull(sdte);
            var sdte2 = sdte as EnvDTE80.DTE2;
            Assert.NotNull(sdte2);

            var dte = Package.GetGlobalService(typeof(DTE));
            Assert.NotNull(dte);
            var dte2 = dte as DTE2;
            Assert.NotNull(dte2);
            return dte2;
        }

        public void Verify()
        {
            var projects = (from Project p in GetActiveDevEnv().Solution.Projects select p).ToArray();

            Assert.Collection(projects
                , p => { }
            );

            foreach (var project in projects)
            {
                Assert.NotNull(project);
            }
        }
    }
}
