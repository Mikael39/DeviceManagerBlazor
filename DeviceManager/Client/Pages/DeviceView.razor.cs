using DeviceManager.Client.Services;
using DeviceManager.Shared.Domain;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace DeviceManager.Client.Pages
{
    public partial class DeviceView 
    {
        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }

        [Parameter]
        public int DeviceId { get; set; }

        public Device Device { get; set; } = new Device();

        public string responseData = string.Empty;
        public bool Error = false;

        protected override async Task OnInitializedAsync()
        {
            var response = await Http.GetAsync("/device/" + DeviceId);
            if(response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true,

                };

                responseData = await response.Content.ReadAsStringAsync();
                Device = JsonSerializer.Deserialize<Device>(responseData, options);
            }

                else
                {
                    Error = true;
                }

            await base.OnInitializedAsync();
        }

    }
}
