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
    public partial class RegisteredVehiclesTypesForm : Form
    {
        private ObservableCollection<VehicleTypeModel> vehicleTypeModels;
        public RegisteredVehiclesTypesForm()
        {
            InitializeComponent();

        }

        private void RegisteredVehiclesTypesForm_Load(object sender, EventArgs e)
        {
            vehicleTypeModels = new ObservableCollection<VehicleTypeModel>(GetAllVehicleTypes());
            dgvVehicleTypes.DataSource = vehicleTypeModels;
        }

        private IEnumerable<VehicleTypeModel> GetAllVehicleTypes()
        {
            var client = new RestClient("https://localhost:44361/VehicleType/GetAllVehicleTypes");

            var request = new RestRequest(Method.GET);

            request.AddHeader("Accept", "application/vnd.api+json");
            var response = client.Execute<IEnumerable<VehicleTypeModel>>(request).Data;

            return response;
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVehicleType.Text))
                return;

            var client = new RestClient("https://localhost:44361/VehicleType/AddVehicleType");

            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/vnd.api+json");
            request.AddHeader("Accept", "application/vnd.api+json");

            request.AddJsonBody(new VehicleTypeModel { Type = txtVehicleType.Text });

            var response = client.Execute<VehicleTypeModel>(request).Data;

            if (response != null)
            {
                vehicleTypeModels.Add(response);
            }
            dgvVehicleTypes.Update();
            dgvVehicleTypes.Refresh();
        }
    }
}
