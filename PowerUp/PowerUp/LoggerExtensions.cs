using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;

namespace PowerUp
{
    public static class LoggerExtensions
    {
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
