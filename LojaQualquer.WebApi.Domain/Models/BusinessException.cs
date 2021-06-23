using System;

namespace LojaQualquer.WebApi.Domain.Models
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
    }
}