using DeviceManager.Client.Services;
using DeviceManager.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace DeviceManager.Client.Pages
{

    public partial class DeviceAdd
    {
        [Inject]
        public IDeviceDataService DeviceDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Device Device { get; set; } = new Device();

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected async Task HandleValidSubmit()
        {
            DeviceDataService.AddDevice(Device);
            NavigationManager.NavigateTo($"/listofdevices");
        }
    }
}