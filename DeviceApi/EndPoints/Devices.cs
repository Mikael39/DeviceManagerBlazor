using DeviceManager.Shared.Domain;

namespace DeviceApi.EndPoints
{
    public static class Devices
    {
        public static void RegisterUserEndPoints(this IEndpointRouteBuilder routes)
        {
            var devices = routes.MapGroup("");

            devices.MapGet("/device", () => "Simple text from Api");

            devices.MapGet("/devices", () => Collections.Devices.DeviceList);

            devices.MapGet("/device/{DeviceId}", (int DeviceId) => Collections.Devices.DeviceList
                                                 .FirstOrDefault(device => device.DeviceId == DeviceId));

            devices.MapPost("/device/add", (Device device) => Collections.Devices.DeviceList.Add(device));

            devices.MapPut("/device/edit/{DeviceId}", (int DeviceId, Device device) => 
                {

                    Device currentDevice = Collections.Devices.DeviceList.FirstOrDefault(device => device.DeviceId == DeviceId);
                    if (currentDevice != null) 
                { 
                    currentDevice.Status = device.Status;
                    currentDevice.DeviceType = device.DeviceType;
                    currentDevice.Location = device.Location;
                    currentDevice.Date = device.Date;
                }

            });

            devices.MapDelete("/device/delete/{DeviceId} ", (int DeviceId) =>
            {
                var Device = Collections.Devices.DeviceList.FirstOrDefault(device => device.DeviceId == DeviceId);
                if (Device != null)
                {
                    Collections.Devices.DeviceList.Remove(Device);
                    return Results.Ok("OK");
                }
                else
                {
                    return Results.Problem("Error");
                }

            });

        }

    }
}
