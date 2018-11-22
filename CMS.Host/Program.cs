using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CMS.WCF.Services;
using CMS.WCF.Services.Interfaces;

namespace CMS.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(ClientsService));
            try
            {
                host.Open();
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
                host.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                host.Abort();
                Console.ReadLine();
            }
        }
    }
}
