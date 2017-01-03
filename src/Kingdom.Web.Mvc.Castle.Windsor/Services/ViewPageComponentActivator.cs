//using System;
//using Castle.Core;
//using Castle.MicroKernel;
//using Castle.MicroKernel.ComponentActivator;
//using Castle.MicroKernel.Context;

//namespace Kingdom.Web.Mvc
//{
//    public class ViewPageComponentActivator : DefaultComponentActivator
//    {
//        public ViewPageComponentActivator(ComponentModel model, IKernel kernel, ComponentInstanceDelegate onCreation, ComponentInstanceDelegate onDestruction)
//            : base(model, onCreation, onDestruction)
//        {
//        }

//        protected override object CreateInstance(CreationContext context, ConstructorCandidate constructor, object[] arguments)
//        {
//            // Do like the MVC framework.
//            var instance = Activator.CreateInstance(context.RequestedType);
//            return instance;
//        }
//    }
//}
