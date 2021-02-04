using System;
using System.Collections.Generic;
using CustomerApp.Shared.Entities.Concrete;
using CustomerApp.Shared.Utilities.Results.ComplexTypes;

namespace CustomerApp.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; } 
        public string Message { get; }
        public Exception Exception { get; }
        public IEnumerable<ValidationError> ValidationErrors { get; }
    }
}
