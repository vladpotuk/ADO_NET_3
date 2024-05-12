using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Markup;

namespace ADO_NET_3
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _message;
        private readonly Data.DBManager _dbManager;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            _dbManager = new Data.DBManager();
        }

        private void InsertStationeryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = StationeryNameTextBox.Text;
                string type = StationeryTypeTextBox.Text;
                int quantity = int.Parse(QuantityTextBox.Text);
                decimal costPerUnit = decimal.Parse(CostPerUnitTextBox.Text);

                _dbManager.InsertStationery(name, type, quantity, costPerUnit);
                Message = "Stationery inserted successfully.";
            }
            catch (Exception ex)
            {
                Message = "Error inserting stationery: " + ex.Message;
            }
        }

        private void UpdateStationeryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(StationeryIdTextBox.Text);
                string name = StationeryNameTextBox.Text;
                string type = StationeryTypeTextBox.Text;
                int quantity = int.Parse(QuantityTextBox.Text);
                decimal costPerUnit = decimal.Parse(CostPerUnitTextBox.Text);

                _dbManager.UpdateStationery(id, name, type, quantity, costPerUnit);
                Message = "Stationery updated successfully.";
            }
            catch (Exception ex)
            {
                Message = "Error updating stationery: " + ex.Message;
            }
        }

        private void DeleteStationeryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(StationeryIdTextBox.Text);
                _dbManager.DeleteStationery(id);
                Message = "Stationery deleted successfully.";
            }
            catch (Exception ex)
            {
                Message = "Error deleting stationery: " + ex.Message;
            }
        }
    }
}