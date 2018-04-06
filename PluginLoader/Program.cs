using System;

namespace PluginLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prepare to fight");
            var loader = new PluginManager();
            foreach (var plug in loader.GetPlugins())
                plug.DoSeriousBusiness("kek");
            Console.ReadLine();
        }
    }
}
