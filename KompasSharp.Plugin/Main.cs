namespace KompasSharp.Plugin
{
    using System.Runtime.InteropServices;

    using Kompas6API5;

    /// <summary>
    /// Главный класс плагина
    /// </summary>
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class Main
    {
        [return: MarshalAs(UnmanagedType.BStr)]
        public string GetLibraryName()
        {
            return "KompasSharp";
        }

        public void ExternalRunCommand([In] short command, [In] short mode, [In, MarshalAs(UnmanagedType.IDispatch)] object kompas_)
        {
            var kompas = (KompasObject)kompas_;


        }
    }
}
