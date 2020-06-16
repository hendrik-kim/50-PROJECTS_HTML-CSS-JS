using System;
using System.Collections.Generic;
using System.Text;

namespace Talent.Services
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public T Data { get; set; }
    }
}
