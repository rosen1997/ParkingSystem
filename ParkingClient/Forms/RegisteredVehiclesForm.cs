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
    public partial class RegisteredVehiclesForm : Form
    {
        private ObservableCollection<RegisteredVehicleModel> registeredVehicleModels;
        private IEnumerable<PriceRangeModel> priceRangeModels;
        private IEnumerable<VehicleTypeModel> vehicleTypeModels;
        public RegisteredVehiclesForm()
        {
            InitializeComponent();
        }

        private void RegisteredVehiclesForm_Load(object sender, EventArgs e)
        {
            priceRangeModels = GetPriceRanges();
            cmbPriceRange.DataSource = priceRangeModels;
            cmbPriceRange.DisplayMember = "Price";

            vehicleTypeModels = GetVehicleTypes();
            cmbVehicleType.DataSource = vehicleTypeModels;
            cmbVehicleType.DisplayMember = "Type";

            registeredVehicleModels = new ObservableCollection<RegisteredVehicleModel>(GetAll());
            dgvRegisteredVehicles.DataSource = registeredVehicleModels;
        }

        private IEnumerable<RegisteredVehicleModel> GetAll()
        {
            var client = new RestClient("https://localhost:44361/RegisteredVehicles/GetAll");

            var request = new RestRequest(Method.GET);

            request.AddHeader("Accept", "application/vnd.api+json");
            var response = client.Execute<IEnumerable<RegisteredVehicleModel>>(request).Data;

            return response;
        }

        private IEnumerable<PriceRangeModel> GetPriceRanges()
        {
            var client = new RestClient("https://localhost:44361/PriceRange/GetAllPrices");

            var request = new RestRequest(Method.GET);

            request.AddHeader("Accept", "application/vnd.api+json");
            var response = client.Execute<IEnumerable<PriceRangeModel>>(request).Data;

            return response;
        }

        private IEnumerable<VehicleTypeModel> GetVehicleTypes()
        {
            var client = new RestClient("https://localhost:44361/VehicleType/GetAllVehicleTypes");

            var request = new RestRequest(Method.GET);

            request.AddHeader("Accept", "application/vnd.api+json");
            var response = client.Execute<IEnumerable<VehicleTypeModel>>(request).Data;

            return response;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlate.Text))
                return;

            if (registeredVehicleModels.Any(x => x.LicensePlate.Equals(txtPlate.Text)))
                return;

            int priceRangeId = (cmbPriceRange.SelectedItem as PriceRangeModel).Id;
            int vehicleTypeId = (cmbVehicleType.SelectedItem as VehicleTypeModel).Id;

            var client = new RestClient("https://localhost:44361/RegisteredVehicles/RegisterVehicle");

            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/vnd.api+json");
            request.AddHeader("Accept", "application/vnd.api+json");

            request.AddJsonBody(new RegisteredVehicleModel { LicensePlate = txtPlate.Text, PriceRangeId = priceRangeId, VehicleTypeId = vehicleTypeId });
            var response = client.Execute<RegisteredVehicleModel>(request).Data;

            registeredVehicleModels.Add(response);
            dgvRegisteredVehicles.Refresh();
            dgvRegisteredVehicles.Update();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRegisteredVehicles.SelectedRows.Count != 1)
                return;

            var vehicle = dgvRegisteredVehicles.SelectedRows[0].DataBoundItem as RegisteredVehicleModel;
            var client = new RestClient("https://localhost:44361/RegisteredVehicles/RemoveRegisteredVehicle");

            var request = new RestRequest(Method.DELETE);

            request.AddHeader("Content-Type", "application/vnd.api+json");
            request.AddHeader("Accept", "application/vnd.api+json");

            request.AddJsonBody(vehicle);
            var response = client.Execute<RegisteredVehicleModel>(request).Data;

            registeredVehicleModels.Remove(vehicle);
            dgvRegisteredVehicles.Refresh();
            dgvRegisteredVehicles.Update();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvRegisteredVehicles.SelectedRows.Count == 0)
                return;
            var selectedItem = dgvRegisteredVehicles.SelectedRows[0].DataBoundItem as RegisteredVehicleModel;

            if (!selectedItem.LicensePlate.Equals(txtPlate.Text))
                return;

            int priceRangeId = (cmbPriceRange.SelectedItem as PriceRangeModel).Id;
            int vehicleTypeId = (cmbVehicleType.SelectedItem as VehicleTypeModel).Id;

            selectedItem.PriceRange = null;
            selectedItem.PriceRangeId = priceRangeId;
            selectedItem.VehicleType = null;
            selectedItem.VehicleTypeId = vehicleTypeId;

            var client = new RestClient("https://localhost:44361/RegisteredVehicles/UpdateRegisteredVehicleInformation");

            var request = new RestRequest(Method.PUT);

            request.AddHeader("Content-Type", "application/vnd.api+json");
            request.AddHeader("Accept", "application/vnd.api+json");

            request.AddJsonBody(selectedItem);
            var response = client.Execute<RegisteredVehicleModel>(request).Data;
            selectedItem = response;
            dgvRegisteredVehicles.Refresh();
            dgvRegisteredVehicles.Update();
        }

        private void dgvRegisteredVehicles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRegisteredVehicles.SelectedRows.Count == 0)
                return;

            var item = dgvRegisteredVehicles.SelectedRows[0].DataBoundItem as RegisteredVehicleModel;

            txtPlate.Text = item.LicensePlate;
            cmbPriceRange.SelectedItem = priceRangeModels.Where(x => x.Id == item.PriceRangeId).Single();
            cmbVehicleType.SelectedItem = vehicleTypeModels.Where(x => x.Id == item.VehicleTypeId).Single();
        }
    }
}
