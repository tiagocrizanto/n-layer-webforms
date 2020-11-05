using PatientManager.Repository;
using PatientManager.Repository.Interfaces;
using Unity;

namespace PatientManager.Infra.IoC
{
    public static class RepositoryBootstrapper
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<IPatientRepository, PatientRepository>();
        }
    }
}
