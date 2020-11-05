using PatientManager.Business;
using PatientManager.Business.Interfaces;
using Unity;

namespace PatientManager.Infra.IoC
{
    public static class DomainServiceBootstrapper
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<IPatientBusiness, PatientBusiness>();
        }
    }
}
