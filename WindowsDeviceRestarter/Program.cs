using DeviceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsDeviceRestarter
{
    class GpuRestarter
    {
        static void Main(string[] args)
        {
            GpuRestarter gpu = new GpuRestarter();
            Console.Out.WriteLine("Trying to disable Device");
            try
            {
                gpu.EnableGpu(false);
                gpu.EnableGpu(true);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine("Please run this program as administrator to access device manager");
                Console.ReadLine();
            }
        }
        public void EnableGpu(Boolean enable)
        {
            // every type of device has a hard-coded GUID, this is the one for GPU
            Guid gpuGuid = new Guid("{4d36e968-e325-11ce-bfc1-08002be10318}");

            // get this from the properties dialog box of this device in Device Manager
            string instancePath = @"PCI\VEN_10DE&DEV_0A6C&SUBSYS_21CC17AA&REV_A2\4&225D9F2B&0&0008";

            DeviceHelper.SetDeviceEnabled(gpuGuid, instancePath, enable);
        }
    }
}
