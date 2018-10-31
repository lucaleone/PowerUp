using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace PowerUp
{
    public static class LoggerExtensions
    {
        private const byte LogThisMethodMethodLineOffset = 2;
        /// <summary>
        ///     Logs (Debug level) information about the calling method in the format: UTCDate - line: Class.Method()
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/blob/master/README.md#logthismethod"/>
        /// <example>
        /// public async Task<IActionResult> AddProduct([FromBody] NewProduct newProduct)
        ///{
        ///    _logger.LogThisMethod(); // result: 14/Sept/2018 | ProductController.AddProduct()
        ///    ...
        /// </example>
        /// <param name="logger">Logger used to print the information</param>
        /// <param name="callerMethodName">[Automatically filled]</param>
        /// <param name="sourceFilePath">[Automatically filled]</param>
        /// <param name="sourceLineNumber">[Automatically filled]</param>
        public static void LogThisMethod(this ILogger logger,
                                         [System.Runtime.CompilerServices.CallerMemberName] string callerMethodName = "",
                                         [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
                                         [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            sourceLineNumber -= LogThisMethodMethodLineOffset;
            var className = sourceFilePath.Split('\\').Last().Remove(".cs");
            logger.LogDebug($"{DateTime.UtcNow:dd/MMM/yyyy} | {sourceLineNumber}: {className}.{callerMethodName}()");
        }
    }
}
