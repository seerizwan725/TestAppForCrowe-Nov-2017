using System;

namespace CommandLayer.Shared
{
    public class CommandFactory : IDisposable
    {
        private const int DefaultCommandTimeout = 30;

        private readonly string _oracleConnectionString;
        private readonly string _processName;
        private readonly int _commandTimeout;

        public CommandFactory(string oracleConnectionString, string processName)
        {
            _oracleConnectionString = oracleConnectionString;
            _processName = processName;

            //var oracleRepoFactory = new MyRepositoryFactory(_oracleConnectionString, DefaultCommandTimeout);
            

        }

        //[DebuggerStepThrough]
        public T Create<T>() where T : BaseCommand
        {
            var cmd = Activator.CreateInstance<T>();

            cmd.OracleConnectionString = _oracleConnectionString;
            cmd.ProcessName = _processName;

            cmd.CommandTimeout = _commandTimeout;
            //cmd.Logger = new StanleyLogger(LogManager.GetLogger(typeof(T).Name), cmd);

            cmd.CommandFactory = this;
            return cmd;
        }
        public void Dispose()
        {

        }

        ~CommandFactory()
        {
            Dispose();
        }
    }
}
