using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;

using Newtonsoft.Json;

namespace Globomantics.BandAgent
{
    class Program
    {
        private const string DeviceConnectionString =
            "HostName=lablex-exercise.azure-devices.net;DeviceId=myFirstDevice;SharedAccessKey=xyUnNKbxm5C1myMHxYT0cy2ybuy1OuO+G/88CnRBHEo=";
        static async Task Main(string[] args)
        {
            Console.WriteLine("Initializing Band Agent");
            var device = DeviceClient.CreateFromConnectionString(DeviceConnectionString);
            await device.OpenAsync();
            Console.WriteLine("Device is Connected");
            var twinproperties = new TwinCollection();
            twinproperties["connectionType"] = "wi-fi";
            twinproperties["connectionStrength"] = "weak";
            await device.UpdateReportedPropertiesAsync(twinproperties);
            //var count = 1;
            //while (true) 
            //{

            //    var telemetry = new Telemetry
            //    {
            //        Message = "Sending Complex Object ...",
            //        StatusCode = count++
            //    };
            //    var telemtryJson = JsonConvert.SerializeObject(telemetry);
            //    var message = new Message(Encoding.ASCII.GetBytes(telemtryJson));

            //    await device.SendEventAsync(message);
            //    Console.WriteLine("Message sent to the cloud");
            //    Thread.Sleep(2000);
            
            //}
            Console.WriteLine("press any key to exit" );
            Console.ReadLine();

        }
    }
}
