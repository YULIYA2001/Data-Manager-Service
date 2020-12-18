using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationManager.Options
{
    public class EncoderOptions
    {
        public static int GetKey()
        {
            // ключ шифрования
            DefaultOptions defOp = new DefaultOptions();
            defOp = new Manager().GetOptions();
            int key = defOp.key;
            return key;
        }
    }
}
