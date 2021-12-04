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
    public partial class PaymentsForm : Form
    {
        public PaymentsForm()
        {
            InitializeComponent();
        }

        private void PaymentsForm_Load(object sender, EventArgs e)
        {
            dgvPayments.DataSource = GetAllPayments();
        }

        private IEnumerable<PaymentModel> GetAllPayments()
        {
            var client = new RestClient("https://localhost:44361/ParkingAndPayment/GetAllPayments");

            var request = new RestRequest(Method.GET);

            request.AddHeader("Accept", "application/vnd.api+json");
            var response = client.Execute<IEnumerable<PaymentModel>>(request).Data;

            return response;
        }
    }
}
