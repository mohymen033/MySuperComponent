using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.EnterpriseServices;


namespace MyWatcher
{
    public partial class Form1 : Form, MySuperEvent.IMyEvent
    {

        private Guid subscriptionID;


        public Form1()
        {
            InitializeComponent();
        }

       public void TheEvent(string s)
        {
            MessageBox.Show("TheEvent with: " + s);
        }

       

        private void subscribe_Click(object sender, EventArgs e)
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

        private void unsubscribe_Click(object sender, EventArgs e)
        {
            COMAdmin.ICOMAdminCatalog pICat = new COMAdmin.COMAdminCatalogClass() as COMAdmin.ICOMAdminCatalog;
            COMAdminWrapper.Subscriptions.RemoveTransientSubscription(pICat, subscriptionID.ToString());
        }
       
    }
}
