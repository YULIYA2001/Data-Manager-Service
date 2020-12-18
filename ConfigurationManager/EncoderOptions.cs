using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationManager
{
    public static class EncoderOptions
    {
        // ключ шифрования
        public static int key = Manager.GetOptions().key;
    }
}
