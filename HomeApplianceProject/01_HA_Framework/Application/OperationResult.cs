using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HA_Framework.Application
{
    public class OperationResult
    {
        public bool IsSucceeded { set; get; }
        public string Message { set; get; }

        public OperationResult()
        {
            IsSucceeded = false;
        }
        public OperationResult Succeeded(string message)
        {
           IsSucceeded=true;
            Message = message;
            return this;
        }
        public OperationResult Failed(string message)
        {
            IsSucceeded = false;
            Message = message;
            return this;
        }
    }
}
