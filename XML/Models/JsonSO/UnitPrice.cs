using System;

namespace XML.Clases.JsonSO
{
    public class UnitPrice
    {
        public double value { get; set; }


        public static implicit operator double(UnitPrice v)
        {
            throw new NotImplementedException();
        }
    }
}