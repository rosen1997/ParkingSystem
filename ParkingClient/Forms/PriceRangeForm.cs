using ParkingClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingClient.Forms
{
    public partial class PriceRangeForm : Form
    {
        private ObservableCollection<PriceRangeModel> priceRanges;
        public PriceRangeForm()
        {
            InitializeComponent();
        }

        private void PriceRangeForm_Load(object sender, EventArgs e)
        {
            priceRanges = new ObservableCollection<PriceRangeModel>(GetPriceRanges());
            dgvPriceRanges.DataSource = priceRanges;
        }

        private IEnumerable<PriceRangeModel> GetPriceRanges()
        {
            var client = new RestClient("https://localhost:44361/PriceRange/GetAllPrices");

            var request = new RestRequest(Method.GET);

            request.AddHeader("Accept", "application/vnd.api+json");
            var response = client.Execute<IEnumerable<PriceRangeModel>>(request).Data;

            return response;
        }

        private void btnAddPrice_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://localhost:44361/PriceRange/AddPriceRange");

            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/vnd.api+json");
            request.AddHeader("Accept", "application/vnd.api+json");

            request.AddJsonBody(new PriceRangeModel { Price = double.Parse(numPrice.Value.ToString()) });

            var response = client.Execute<PriceRangeModel>(request).Data;

            if (response != null)
            {
                priceRanges.Add(response);
            }
            dgvPriceRanges.Update();
            dgvPriceRanges.Refresh();
        }
    }
}
