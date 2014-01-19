using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.EnterpriseServices;


namespace WebApplicationwatcher
{
    public partial class _Default : Page, MySuperEvent.IMyEvent
    {
        private Guid subscriptionID;
/*
        protected void Page_Load(object sender, EventArgs e)
        {

        }
*/
        public void TheEvent(string s)
        {
            Console.WriteLine(s);
        }

        public void Button1_Click(object sender, EventArgs e)
        {
           
            
            subscriptionID = Guid.NewGuid();
            MySuperEvent.IMyEvent subscriberInterface = this as MySuperEvent.IMyEvent;
            COMAdmin.ICOMAdminCatalog pICat = new COMAdmin.COMAdminCatalogClass() as COMAdmin.ICOMAdminCatalog;
            COMAdminWrapper.Subscriptions.AddTransientSubscription(
                pICat,                                      //ICOMAdminCatalog
                subscriptionID.ToString(),                  // Subscription name
                MySuperEvent.MyEventClass.EventClassCLSID,  // EventClass to subscribe to
                null,                                       // PublisherID
                MySuperEvent.MyEventClass.FiringInterfaceID,// FiringInterfaceID
                subscriberInterface,                        // the transient interface pointer on this form
                null,                                       // methodName
                null,                                       // FilterCriteria
                null,                                       // Publisher property name
                null);                                      // publisher property value


        }

        public void Button2_Click(object sender, EventArgs e)
        {
            COMAdmin.ICOMAdminCatalog pICat = new COMAdmin.COMAdminCatalogClass() as COMAdmin.ICOMAdminCatalog;
            COMAdminWrapper.Subscriptions.RemoveTransientSubscription(pICat, subscriptionID.ToString());
        }
    }
}