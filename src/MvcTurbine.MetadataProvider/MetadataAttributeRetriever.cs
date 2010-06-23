using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MvcTurbine.MetadataProvider
{
    public class MetadataAttributeRetriever
    {
        public IEnumerable<Type> GetAllValidatorTypes()
        {
            var list = new List<Type>();

            foreach (var assembly in GetAllAssemblies())
                list.AddRange(GetAllMetadataAttributeHandlers(assembly));

            return list;
        }

        private static IEnumerable<Type> GetAllMetadataAttributeHandlers(Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(x => ThisTypeImplementsAnInterface(x) && ThisTypeIsAMetadataAttributeHandler(x));
        }

        private static bool ThisTypeImplementsAnInterface(Type x)
        {
            return x.GetInterfaces() != null;
        }

        private static bool ThisTypeIsAMetadataAttributeHandler(Type x)
        {
            return x.GetInterfaces().Any(i => (i.FullName ?? string.Empty).StartsWith("MvcTurbine.MetadataProvider.IMetadataAttributeHandler`1"));
        }

        private static IEnumerable<Assembly> GetAllAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName.StartsWith("MvcTurbine.MetadataProvider.,") == false)
                .ToList();
        }
    }
}