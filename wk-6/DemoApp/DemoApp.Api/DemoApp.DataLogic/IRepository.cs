using DemoApp.BusinessLogic;

namespace DemoApp.DataLogic
{
    public interface IRepository
    {
        Task<IEnumerable<Device>> GetAllDevices();
        Task<IEnumerable<Device>> GetDevice(string Name);
    }
}