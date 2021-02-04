using System;
using CustomerApp.Shared.Utilities.Results.ComplexTypes;

namespace CustomerApp.Shared.Entities.Concrete
{
    public class ApiError
    {
        public string Message { get; set; }
        public string Detail { get; set; }
        public ResultStatus ResultStatus { get; set; }
    }
}
