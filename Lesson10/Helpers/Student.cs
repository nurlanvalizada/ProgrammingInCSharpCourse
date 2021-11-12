using System;

namespace Helpers
{
    public class Student
    {
        public string Name;
        internal string Age;
        protected internal string School;

        private byte _iq;

        public byte IQ 
        { 
            get
            {
                return _iq;
            }
            set 
            {
                if (value <= 200)
                {
                    _iq = value;
                }
                else
                {
                    throw new Exception("IQ cannot be more than 200");
                }

                _iq =value;
            }
        }

        public byte Score { get; set; } = 10;
    }
}
