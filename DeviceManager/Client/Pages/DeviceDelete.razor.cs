using DeviceManager.Client.Services;
using DeviceManager.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace DeviceManager.Client.Pages
{
    public partial class DeviceDelete
    {
        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string DeviceId { get; set; }

        public Device Device { get; set; } = new Device();

        protected override void OnInitialized()
        {
            Device = DeviceDataService.GetDevice(int.Parse(DeviceId));
        }

        protected void Delete(string DeviceId)
        {
            DeviceDataService.DeleteDevice(int.Parse(DeviceId));

            NavigationManager.NavigateTo($"/listofdevices");

        }
    }
}