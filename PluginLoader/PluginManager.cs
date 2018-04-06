using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.ComponentModel;
using Autofac;
using PluginApi;
namespace PluginLoader
{
    public class PluginManager
    {
        public IEnumerable<IPlugin> GetPlugins()
        {
            var path = @"D:\PublishedProjects";
            var cb = new ContainerBuilder();

            foreach( var fl in Directory.EnumerateFiles(path, "*.dll", SearchOption.AllDirectories))
            {
                var ass = AssemblyLoadContext.Default.LoadFromAssemblyPath(fl);
                var types = ass.GetTypes().Where(x=>x.IsAssignableTo<IPlugin>() && !x.IsInterface);
                foreach(var t in types)
                {
                    var name = (DisplayNameAttribute)t.GetCustomAttribute(typeof(DisplayNameAttribute));
                    System.Console.WriteLine(name.DisplayName);
                    cb.RegisterType(t).Named<IPlugin>(name.DisplayName);
                }
                System.Console.WriteLine(fl);
            }
            var container = cb.Build();
            using(var scope = container.BeginLifetimeScope())
            {
                yield return scope.ResolveNamed<IPlugin>("logging");
            }
            //var ass = AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
            
        }
    }
}