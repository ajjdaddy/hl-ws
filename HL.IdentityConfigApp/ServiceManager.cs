using System;
using System.ServiceProcess;

namespace HL.IdentityConfigApp
{
    class ServiceManager
    {
        public static void StopService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                // convert ms to timespan
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to stop service " + serviceName + ": " + ex.Message);
            }
        }

        public static void StartService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                // convert ms to timespan
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to start service " + serviceName + ": " + ex.Message);
            }
        }

        /// <summary>
        /// TODO: Fix restart HL service
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="timeoutMilliseconds"></param>
        /// <exception cref="Exception"></exception>
        public static void RestartService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                if (ServiceIsRunning(serviceName))
                {
                    StopService(serviceName, timeoutMilliseconds);
                }
                // count the rest of the timeout

                StartService(serviceName, timeoutMilliseconds);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to restart service " + serviceName + ": " + ex.Message);
            }
        }

        public static bool IsServiceInstalled(string serviceName)
        {
            // get list of Windows services
            ServiceController[] services = ServiceController.GetServices();

            // try to find service name
            foreach (ServiceController service in services)
            {
                if (service.ServiceName == serviceName)
                    return true;
            }
            return false;
        }

        public static bool ServiceIsRunning(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            if (service.Status == ServiceControllerStatus.Running)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
