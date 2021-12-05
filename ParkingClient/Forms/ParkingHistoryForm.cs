using ParkingClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingClient.Forms
{
    public partial class ParkingHistoryForm : Form
    {
        public ParkingHistoryForm()
        {
            InitializeComponent();
        }

        private void ParkingHistoryForm_Load(object sender, EventArgs e)
        {
            dgvParkingHistory.DataSource = GetAll();
        }

        private IEnumerable<ParkingStatusModel> GetAll()
        {
            var client = new RestClient("https://localhost:44361/ParkingAndPayment/ParkingStatuses");

            var request = new RestRequest(Method.GET);

            request.AddHeader("Accept", "application/vnd.api+json");
            var response = client.Execute<IEnumerable<ParkingStatusModel>>(request).Data;

            return response;
        }
    }
}
