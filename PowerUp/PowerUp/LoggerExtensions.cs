using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace PowerUp
{
    public static class LoggerExtensions
    {
        /// <summary>
        ///     Logs (Debug level) information about the calling method in the format: UTCDate - line: Class.Method() | message
        /// </summary>
        /// <example>
        /// public async Task<IActionResult> AddProduct([FromBody] NewProduct newProduct)
        ///{
        ///    _logger.LogThisMethod(); // result: 14/Sept/2018 | ProductController.AddProduct()
        ///    ...
        /// </example>
        /// <param name="logger">Logger used to print the information</param>
        /// <param name="message">[Optional] Additional message.</param>
        /// <param name="callerMethodName">[Automatically filled]</param>
        /// <param name="sourceFilePath">[Automatically filled]</param>
        /// <param name="sourceLineNumber">[Automatically filled]</param>
        public static void LogThisMethod(this ILogger logger, string message = "",
                                         [System.Runtime.CompilerServices.CallerMemberName] string callerMethodName = "",
                                         [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
                                         [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            sourceLineNumber = -2; // offset
            var className = sourceFilePath.Split('\\').Last().Remove(".cs");
            logger.LogDebug($"{DateTime.UtcNow:dd/MMM/yyyy} | {sourceLineNumber}: {className}.{callerMethodName}() | {message}");
        }
    }
}
