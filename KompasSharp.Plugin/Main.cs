namespace KompasSharp.Plugin
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using Kompas6API5;

    using KompasSharp.Plugin.Forms;

    using Microsoft.Win32;

    /// <summary>
    /// Главный класс плагина
    /// </summary>
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class Main
    {
        /// <summary>
        /// Получить название библиотеки
        /// </summary>
        /// <returns>Название библиотеки</returns>
        [return: MarshalAs(UnmanagedType.BStr)]
        public string GetLibraryName()
        {
            return "KompasSharp";
        }

        /// <summary>
        /// Выполнить коианду
        /// </summary>
        /// <param name="command">Команда</param>
        /// <param name="mode">Режим</param>
        /// <param name="kompas_">Объект Компаса</param>
        public void ExternalRunCommand([In] short command, [In] short mode, [In, MarshalAs(UnmanagedType.IDispatch)] object kompas_)
        {
            var kompas = (KompasObject)kompas_;
            var form = new MainForm(kompas);
            form.Show();
        }

        #region COM Registration

        // Эта функция выполняется при регистрации класса для COM
        // Она добавляет в ветку реестра компонента раздел Kompas_Library,
        // который сигнализирует о том, что класс является приложением Компас,
        // а также заменяет имя InprocServer32 на полное, с указанием пути.
        // Все это делается для того, чтобы иметь возможность подключить
        // библиотеку на вкладке ActiveX.
        [ComRegisterFunction]
        public static void RegisterKompasLib(Type t)
        {
            try
            {
                RegistryKey regKey = Registry.LocalMachine;
                string keyName = @"SOFTWARE\Classes\CLSID\{" + t.GUID.ToString() + "}";
                regKey = regKey.OpenSubKey(keyName, true);
                regKey.CreateSubKey("Kompas_Library");
                regKey = regKey.OpenSubKey("InprocServer32", true);
                regKey.SetValue(null, System.Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\mscoree.dll");
                regKey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("При регистрации класса для COM-Interop произошла ошибка:\n{0}", ex));
            }
        }

        // Эта функция удаляет раздел Kompas_Library из реестра
        [ComUnregisterFunction]
        public static void UnregisterKompasLib(Type t)
        {
            RegistryKey regKey = Registry.LocalMachine;
            string keyName = @"SOFTWARE\Classes\CLSID\{" + t.GUID.ToString() + "}";
            RegistryKey subKey = regKey.OpenSubKey(keyName, true);
            subKey.DeleteSubKey("Kompas_Library");
            subKey.Close();
        }

        #endregion
    }
}
