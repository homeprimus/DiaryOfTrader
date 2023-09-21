using System.Text;
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Utils
{
    public static class LoggingExtensions
    {
        public static void LogRequest<T>(this ILogger<T> logger, string controller, string method, params object[] args)
        {
            var pars = new object[args.Length / 2 + 2];
            var idx = 0;
            pars[idx] = controller;
            pars[++idx] = method;
            var sb = new StringBuilder();
            sb.Append("");
            if (args.Length > 0)
            {
                sb.Append(" params: ");
            }

            for (int i = 0; i < args.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sb.Append($"[{{{args[i]}}}]");
                }
                else
                {
                    pars[++idx] = args[i];
                }
            }
            logger.LogInformation(sb.ToString(), pars);
        } 
    }
}
