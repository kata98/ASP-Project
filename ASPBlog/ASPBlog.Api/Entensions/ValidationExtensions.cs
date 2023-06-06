using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPBlog.Api.Extensions
{
    public static class ValidationExtensions
    {
        public static UnprocessableEntityObjectResult AsUnprocessableEntity(this IEnumerable<ValidationFailure> errors)
        {
            var errorObj = new
            {
                errors = errors.Select(x => new
                {
                    property = x.PropertyName,
                    error = x.ErrorMessage
                })
            };

            var result = new UnprocessableEntityObjectResult(errorObj);

            return result;
        }
    }
}
