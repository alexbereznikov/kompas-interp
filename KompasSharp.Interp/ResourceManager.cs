namespace KompasSharp.Interp
{
    using System;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Менеджер ресурсов
    /// </summary>
    public static class ResourceManager
    {
        private static readonly Assembly assembly;

        static ResourceManager()
        {
            assembly = Assembly.GetExecutingAssembly();
        }

        public static string GetScript(string folder, string name)
        {
            var path = string.Format("{0}.Scripts.{1}.{2}", assembly.GetName().Name, folder, name);

            var stream = assembly.GetManifestResourceStream(path);
            
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }
    }
}