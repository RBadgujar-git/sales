using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;

using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;




namespace sample
{
    public partial class BackuptoDrive : Form
    {
       
        public BackuptoDrive()
        {
            InitializeComponent();
        }

        private void cretaeservice()
        {
            var clientid = "924106360940-3pkd782nuoge6cl8vr6tgb4fndnht8md.apps.googleusercontent.com";
            var clientsecret = "LvzYGykvOChvo9bvi2vs4sYF";
            //var uc as UserCredential=GoogleWebAuthorizationBroker.AuthorizeAsync
        }
    }
}
