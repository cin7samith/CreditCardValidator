using Autofac;
using Autofac.Builder;
using Autofac.Integration.WebApi;
using Autofac.Pooling;
using CreditCardValidator.API.Controllers;
using CreditCardValidator.Business;
using CreditCardValidator.Common.Interfaces;
using CreditCardValidator.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace CreditCardValidator.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            // Web API configuration and services
            var builder = new ContainerBuilder();

            // Web API routes
            config.MapHttpAttributeRoutes();

            //get card type info's
            List<ICardTypeInfo> cardTypeInfos = new CardTypeInfoRepository().GetAll();

            // You can register controllers all at once using assembly scanning...
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            foreach (var cardTypeInfo in cardTypeInfos) 
            {
                builder.RegisterInstance(cardTypeInfo).As<ICardTypeInfo>().SingleInstance();                    
            }

            builder.RegisterType<CardTypeInfoRepository>().As<ICardTypeInfoRepository>().InstancePerRequest();
            builder.RegisterType<ValidationLogRepository>().As<IValidationLogRepository>().InstancePerRequest();
            builder.RegisterType<CardValidationService>().As<ICardValidationService>().InstancePerRequest();



            builder.RegisterType<NotEmptyOrNullRule>().As<IValidationRule>().PooledInstancePerLifetimeScope(50);
            builder.RegisterType<AllNumbersRule>().As<IValidationRule>().PreserveExistingDefaults().PooledInstancePerLifetimeScope(50);
            builder.RegisterType<CorrectLengthRule>().As<IValidationRule>().PreserveExistingDefaults().PooledInstancePerLifetimeScope(50);
            builder.RegisterType<IdentifiableTypeRule>().As<IValidationRule>().PreserveExistingDefaults().PooledInstancePerLifetimeScope(50);
            builder.RegisterType<LuhnAlgorithmRule>().As<IValidationRule>().PreserveExistingDefaults().PooledInstancePerLifetimeScope(50);

            //builder.RegisterType<CardValidatorController>().InstancePerRequest();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
