using System;
using System.Linq;
using System.Reflection;
using MyMediator.Commands;
using MyMediator.Handlers;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace MyMediator
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyMediator(this IServiceCollection serviceCollection, IEnumerable<Assembly> commandHandlersAssemblies)
        {
            var commandHandlerBaseType = typeof(ICommandHandler<,>);

            var commandTypes = commandHandlersAssemblies
                .SelectMany(s => s.ExportedTypes)
                .Where(w => w.GetInterfaces().Any(a => a.IsGenericType && a.Name == commandHandlerBaseType.Name));

            foreach (var commandType in commandTypes)
            {
                var @interface = commandType.GetInterface(commandHandlerBaseType.Name);
                serviceCollection.AddTransient(@interface, commandType);
            }

            return serviceCollection;
        }

        public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            foreach (var it in interfaceTypes)
                if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
                    return true;

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;

            Type baseType = givenType.BaseType;
            if (baseType == null) return false;

            return IsAssignableToGenericType(baseType, genericType);
        }
    }
}
