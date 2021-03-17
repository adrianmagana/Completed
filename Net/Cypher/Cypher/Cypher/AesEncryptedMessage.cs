using System;
using System.Collections.Generic;
using System.Text;

namespace Cypher
{
    class AesEncryptedMessage
    {
        public AesEncryptedMessage(string message, string IV)
        {
            Message = message;
            this.IV = IV;
        }
        public AesEncryptedMessage() { }

        public string Message { get; set; }
        public string IV { get; set; }
    }
}
