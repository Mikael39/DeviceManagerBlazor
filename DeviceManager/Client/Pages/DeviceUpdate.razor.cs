using DeviceManager.Client.Services;
using DeviceManager.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace DeviceManager.Client.Pages
{
    public partial class DeviceUpdate
    {

        [Inject]
        public IDeviceDataService DeviceDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string DeviceId { get; set; } = string.Empty;

        public Device Device { get; set; } = new Device();

        protected override void OnInitialized()
        {
            Device = DeviceDataService.GetDevice(int.Parse(DeviceId));

            base.OnInitialized();
        }

        protected async Task HandleValidSubmit()
        {
            DeviceDataService.UpdateDevice(Device);
            NavigationManager.NavigateTo($"listofdevices");
        }
    }
}