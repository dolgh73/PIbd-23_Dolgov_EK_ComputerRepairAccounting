using ComputerRepairAccounting.Interfaces;
using ComputerRepairAccounting.Repositories;
using Unity;
using Unity.Lifetime;

namespace ComputerRepairAccounting;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        using var container = CreateContainer();
        Application.Run(container.Resolve<MainForm>());
    }
    private static IUnityContainer CreateContainer()
    {
        var container = new UnityContainer();

        container.RegisterType<IMasterRepository, MasterRepository>(new ContainerControlledLifetimeManager());
        container.RegisterType<IComponentRepository, ComponentRepository>(new ContainerControlledLifetimeManager());
        container.RegisterType<IWarehouseRepository, WarehouseRepository>(new ContainerControlledLifetimeManager());
        container.RegisterType<IComponentReceiptRepository, ComponentReceiptRepository>(new ContainerControlledLifetimeManager());
        container.RegisterType<IRepairRepository, RepairRepository>(new ContainerControlledLifetimeManager());
        container.RegisterType<IDevicePlacementRepository, DevicePlacementRepository>(new ContainerControlledLifetimeManager());
        return container;
    }
}
