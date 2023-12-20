using DeviceManager.Client.Services;
using DeviceManager.Shared.Domain;
using Microsoft.AspNetCore.Components;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace DeviceManager.Client.Components
{

   
    public partial class DeviceList
    {
        [Parameter]
     
        public string ExtraCaption { get; set; } = string.Empty;

        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }

        public List<Device> DeviceLst { get; set; } = new List<Device>();

        public string responseData = string.Empty;
        public bool Error = false;
        public int count = 0;

        protected override async Task OnInitializedAsync()
        {
                
            var response = await Http.GetAsync("/devices");
         

            
            if(response.IsSuccessStatusCode)
            {
                responseData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true,
                };

                DeviceLst = (List<Device>)JsonSerializer.Deserialize<IEnumerable<Device>>(responseData, options);

                count = DeviceLst.Count();

            }
            else
            {
                Error = true;
            }
            
            await base.OnInitializedAsync();

        }

    }
}