using DeviceManager.Client.Services;
using DeviceManager.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace DeviceManager.Client.Pages
{
    public partial class DeviceView 
    {
        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }

        [Parameter]
        public string DeviceId { get; set; }

        public Device Device { get; set; } = new Device();

        protected override void OnInitialized()
        {
            Device = DeviceDataService.GetDevice(int.Parse(DeviceId));
            base.OnInitialized();
        }

    }
}
