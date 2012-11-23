namespace KompasSharp.Interp
{
    using Kompas6API5;

    /// <summary>
    /// Обертка над функциями компаса
    /// </summary>
    public class KompasWrapper
    {
        private readonly KompasObject kompas;

        /// <summary>
        /// Конструктор класса <see cref="KompasWrapper"/>
        /// </summary>
        /// <param name="kompas">экземпляр компаса</param>
        public KompasWrapper(KompasObject kompas)
        {
            this.kompas = kompas;
        }

        public int ksYesNo(string text)
        {
            return this.kompas.ksYesNo(text);
        }

        public bool ksMessage(string text)
        {
            return this.kompas.ksMessage(text);
        }

        public int ksReadDouble(string mess, double defValue, double min, double max, ref double value)
        {
            return this.kompas.ksReadDouble(mess, defValue, min, max, value);
        }

        public object ActiveDocument2D()
        {
            return this.kompas.ActiveDocument2D();
        }

        public object ActiveDocument3D()
        {
            return this.kompas.ActiveDocument3D();
        }

        public int DataBaseObject();

        {
            return this.kompas.ksYesNo(text);
        }

        public int ksYesNo(string text)
        {
            return this.kompas.ksYesNo(text);
        }

        public int ksYesNo(string text)
        {
            return this.kompas.ksYesNo(text);
        }

    }
}