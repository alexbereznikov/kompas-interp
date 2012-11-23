namespace KompasSharp.Interp
{
    using System;

    using Kompas6API5;

    using LuaInterface;

    /// <summary>
    /// Интерпретатор
    /// </summary>
    public class Interpretator
    {
        /// <summary>
        /// Конструктор класса <see cref="Interpretator"/>
        /// <param name="kompas">экземпляр Компас 3D</param>
        /// </summary>
        public Interpretator(KompasObject kompas)
        {
            lua = new Lua();
            initLua(kompas);
        }

        /// <summary>
        /// Инициализация интерпретатора
        /// <param name="kompas">экземпляр Компас 3D</param>
        /// </summary>
        private void initLua(KompasObject kompas)
        {
            this.lua["kompas"] = new KompasWrapper(kompas);
            // this.lua.DoString(ResourceManager.GetScript("Common", "CLRPackage.lua"));
        }

        /// <summary>
        /// Интерпретация скрипта или команды
        /// </summary>
        /// <param name="data">интерпретируемый код</param>
        /// <returns>результат интерпретации</returns>
        public string Interpret(string data)
        {
            object[] results;
            try
            {
                results = lua.DoString(data);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
            var result = string.Empty;

            if (results != null)
            {
                foreach (var res in results)
                {
                    if (res != null) result += res.ToString() + " ";
                }
            }
            
            return result;
        }

        private readonly Lua lua;
    }
}
