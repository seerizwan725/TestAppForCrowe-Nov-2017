using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace DataLayer
{
    public static class RepositoryContainer
    {
        private static object _lock = new object();
        static RepositoryContainer()
        {
            _repositories = new Collection<IRepository>();
            Configure();
        }

        private static void Configure()
        {
            lock (_lock)
            {
                _repositories.Clear();
                var repositoryTypes = Assembly
                        .GetAssembly(typeof(RepositoryContainer))
                        .GetTypes()
                        .Where(t => t.GetInterface("IRepository") != null && t.IsClass && !t.IsAbstract);

                foreach (var repositoryType in repositoryTypes)
                {
                    var repositoryConstructor = repositoryType.GetConstructor(new Type[0]);
                    _repositories.Add((IRepository)repositoryConstructor.Invoke(null));
                }
            }

        }
        public static void Reset()
        {
            Configure();
        }

        public static void Configure(params IRepository[] repositories)
        {
            lock (_lock)
            {
                foreach (var repository in repositories)
                {
                    RemoveExistingRepository(repository);
                    _repositories.Add(repository);
                }
            }
        }
        private static void RemoveExistingRepository(IRepository repository)
        {
            var repositoryInterfaces = repository.GetType().GetInterfaces().Where(i => i.Assembly == Assembly
                                .GetAssembly(typeof(RepositoryContainer)));

            var existingRepository = _repositories.SingleOrDefault(r => !r.GetType().GetInterfaces().Where(i => i.Assembly == Assembly
                                .GetAssembly(typeof(RepositoryContainer))).Except(repositoryInterfaces).Any());

            if (existingRepository != null)
                _repositories.Remove(existingRepository);
        }
        public static TRepository GetRepository<TRepository>() where TRepository : IRepository
        {
            TRepository locatedRepository = _repositories
                                                .Where(service => service is TRepository)
                                                .Cast<TRepository>()
                                                .FirstOrDefault();
            if (locatedRepository == null)
                throw new ArgumentException(string.Format("Cannot locate an implementation for {0}", typeof(TRepository)));

            return locatedRepository;
        }

        private static Collection<IRepository> _repositories;
    }
}
