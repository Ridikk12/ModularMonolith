using Microsoft.AspNetCore.Http;
using ModularMonolith.Exceptions.Abstraction;
using Serilog;
using Serilog.Events;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using FluentValidation;

namespace ModularMonolith.Infrastructure.Exceptions
{
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ContentType = "application/json";

        private static readonly JsonSerializerOptions DefaultWebOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public ExceptionLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var logLevel = GetLoggerLevel(ex);
                Log.Logger.Write(logLevel, ex, "Exception has been thrown");

                httpContext.Response.ContentType = ContentType;
                httpContext.Response.StatusCode = GetHttpStatusCode(ex);

                var exceptionMessage = FormatErrorMessage(ex);
                var message = JsonSerializer.Serialize(exceptionMessage, DefaultWebOptions);

                await httpContext.Response.WriteAsync(message);
            }
        }

        private static ErrorResponse FormatErrorMessage(Exception ex) =>
            ex switch
            {
                DomainException domainException =>
                    new ErrorResponse(domainException.ExceptionCode, domainException.Message),
                ModularMonolithValidationException validationException => new ErrorResponse(
                    validationException.ExceptionCode,
                    validationException.Message,
                    validationException.ValidationMessages),
                ValidationException validationException => new ErrorResponse(validationException.Errors,
                    validationException.Message, -1),
                AppException appException => new ErrorResponse(appException.ExceptionCode,
                    appException.Message),
                _ => new ErrorResponse(-1, ex.Message),
            };

        private static int GetHttpStatusCode(Exception ex)
            => ex switch
            {
                DomainException _ => (int)HttpStatusCode.BadRequest,
                AppException _ => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };


        private static LogEventLevel GetLoggerLevel(Exception ex)
            => ex switch
            {
                DomainException _ => LogEventLevel.Information,
                AppException _ => LogEventLevel.Information,
                _ => LogEventLevel.Error
            };
    }
}