using System;

namespace ExceptionsAsExpressions
{
    // C# 6
    public class InitialisationExpressionOld
    {
        private readonly Configuration _config;

        public InitialisationExpressionOld()
        {
            _config = LoadConfig();
            if(_config == null)
                throw new InvalidOperationException("Could not load config");
        }
        private static Configuration LoadConfig()
        {
            return new Configuration { MinLoggingLevel = "Info" };
        }
    }

    // C# 7
    public class InitialisationExpression
    {
        private readonly Configuration _config = LoadConfig() ??
                                                 throw new InvalidOperationException("Could not load config");

        private static Configuration LoadConfig()
        {
            return new Configuration { MinLoggingLevel = "Info" };
        }
    }
}