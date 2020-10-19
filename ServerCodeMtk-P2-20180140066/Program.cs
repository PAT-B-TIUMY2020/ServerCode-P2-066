using ServiceMtk_P1_20180140066;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ServerCodeMtk_P2_20180140066
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostObj = null;
            Uri address = new Uri("http://localhost:8888/Matematika");
            BasicHttpBinding bind = new BasicHttpBinding();

            try
            {
                hostObj = new ServiceHost(typeof(Matematika), address);                
                hostObj.AddServiceEndpoint(typeof(IMatematika), bind, ""); 

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();                  
                smb.HttpGetEnabled = true;                 
                hostObj.Description.Behaviors.Add(smb);
         
                Binding mexbind = MetadataExchangeBindings.CreateMexHttpBinding();
                hostObj.AddServiceEndpoint(typeof(IMetadataExchange), mexbind, "mex"); 

                hostObj.Open();
                Console.WriteLine("Server is ready!!!!");
                Console.ReadLine();
                hostObj.Close();
            }

            catch (Exception ex)
            {
                hostObj = null;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
