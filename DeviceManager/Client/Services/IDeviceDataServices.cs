using DeviceManager.Shared.Domain;


namespace DeviceManager.Client.Services
{
    public interface IDeviceDataService
    {
        List<Device> GetDevices();

        Device GetDevice(int Id);

        void DeleteDevice(int Id);

        void UpdateDevice(Device Device);

        void AddDevice(Device Device);
    }
}