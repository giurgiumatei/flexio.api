using Flexio.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Flexio.Data.Exceptions
{
    public class CustomApplicationException : Exception
    {
        public ErrorCode ErrorCode { get; }

        public CustomApplicationException(ErrorCode code, string message) :
            base(JsonSerializer.Serialize(
                new CustomException
                {
                    Code = (int)code,
                    Message = message.ToString()
                }))
        {
            ErrorCode = code;
        }
    }
}
