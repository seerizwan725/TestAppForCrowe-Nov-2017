using System;
using DataLayer.Factory;

namespace CommandLayer.Shared
{
    public class BaseCommand : IDisposable
    {
        public string OracleConnectionString;
        public int CommandTimeout;
        bool disposed = false;
        public string ProcessName;
        public CommandFactory CommandFactory;

        private MyAppRepositoryFactory _oracleRepositoryFactory;
        
        public MyAppRepositoryFactory DBRepositoryFactory
        {          

            get
            {
                //if (_oracleRepositoryFactory != null)
                //{
                    _oracleRepositoryFactory = new MyAppRepositoryFactory(OracleConnectionString, CommandTimeout);
                //}
                return _oracleRepositoryFactory;
            }

        }
        public virtual T Execute<T>() where T : Class1
        {
            return default(T);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                CommandFactory.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
        ~BaseCommand()
        {
            Dispose(false);
        }
    }
}
