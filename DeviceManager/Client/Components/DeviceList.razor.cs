using DeviceManager.Shared.Domain;

namespace DeviceManager.Client.Components
{

   
    public partial class DeviceList
    {
        public List<Device> Devices { get; set; } = new List<Device>();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Devices.Add(new Device() { DeviceId = Guid.NewGuid(), Location = Location.Sweden, Date = new DateTime(), DeviceType = "DeviceType1", Status = Status.online }) ;

            Devices.Add(new Device() { DeviceId = Guid.NewGuid(), Location = Location.England, Date = new DateTime(), DeviceType = "DeviceType2", Status = Status.offline });
        }

    }
}
