using DeviceManager.Client.Services;
using Microsoft.AspNetCore.Components;



namespace DeviceManager.Client.Components
{
    public partial class DailyStats
    {
        [Inject]
        public IDeviceDataService DeviceDataService { get; set; }

        public int NumberOfDevice { get; set; }

        protected override void OnInitialized()
        {
            NumberOfDevice = DeviceDataService.GetDevices().Count;

            base.OnInitialized();
        }

    }
}
