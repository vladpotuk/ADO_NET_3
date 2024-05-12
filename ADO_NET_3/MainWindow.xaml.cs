using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;

namespace WpfApp_12._05
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _message;
        private DBManager _dbManager;

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
            _dbManager = new DBManager();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _dbManager.OpenConnection();
                Message = "Connected to the database.";
            }
            catch (Exception ex)
            {
                Message = "Error connecting to the database: " + ex.Message;
            }
        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _dbManager.CloseConnection();
                Message = "Disconnected from the database.";
            }
            catch (Exception ex)
            {
                Message = "Error disconnecting from the database: " + ex.Message;
            }
        }

        private void ShowAllStationeryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable stationeryTable = _dbManager.GetAllStationery();
                Message = "Displayed all stationery.";
            }
            catch (Exception ex)
            {
                Message = "Error displaying stationery: " + ex.Message;
            }
        }

        private void ShowAllTypesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> types = _dbManager.GetAllStationeryTypes();
                Message = "Displayed all types of stationery.";
            }
            catch (Exception ex)
            {
                Message = "Error displaying types of stationery: " + ex.Message;
            }
        }

        private void ShowAllSalesManagersButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> managers = _dbManager.GetAllSalesManagers();
                Message = "Displayed all sales managers.";
            }
            catch (Exception ex)
            {
                Message = "Error displaying sales managers: " + ex.Message;
            }
        }

        private void ShowMaxUnitsStationeryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable maxUnitsStationery = _dbManager.GetStationeryWithMaxUnits();
                Message = "Displayed stationery with maximum number of units.";
            }
            catch (Exception ex)
            {
                Message = "Error displaying stationery with maximum number of units: " + ex.Message;
            }
        }

        private void ShowMinUnitsStationeryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable minUnitsStationery = _dbManager.GetStationeryWithMinUnits();
                Message = "Displayed stationery with minimum number of units.";
            }
            catch (Exception ex)
            {
                Message = "Error displaying stationery with minimum number of units: " + ex.Message;
            }
        }

        private void ShowMinCostStationeryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable minCostStationery = _dbManager.GetStationeryWithMinCost();
                Message = "Displayed stationery with minimum unit cost.";
            }
            catch (Exception ex)
            {
                Message = "Error displaying stationery with minimum unit cost: " + ex.Message;
            }
        }

        private void ShowMaxCostStationeryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable maxCostStationery = _dbManager.GetStationeryWithMaxCost();
                Message = "Displayed stationery with maximum unit cost.";
            }
            catch (Exception ex)
            {
                Message = "Error displaying stationery with maximum unit cost: " + ex.Message;
            }
        }

        
        private void ShowStationeryByTypeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedType = "";
                DataTable stationeryByType = _dbManager.GetStationeryByType(selectedType);
                Message = $"Displayed stationery of type: {selectedType}.";
            }
            catch (Exception ex)
            {
                Message = "Error displaying stationery by type: " + ex.Message;
            }
        }

        private void ShowStationeryByManagerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedManager = "";
                DataTable stationeryByManager = _dbManager.GetStationeryByManager(selectedManager);
                Message = $"Displayed stationery sold by manager: {selectedManager}.";
            }
            catch (Exception ex)
            {
                Message = "Error displaying stationery by manager: " + ex.Message;
            }
        }

        private void ShowStationeryByBuyerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedBuyer = "";
                DataTable stationeryByBuyer = _dbManager.GetStationeryByBuyer(selectedBuyer);
                Message = $"Displayed stationery purchased by buyer: {selectedBuyer}.";
            }
            catch (Exception ex)
            {
                Message = "Error displaying stationery by buyer: " + ex.Message;
            }
        }

        private void ShowRecentSaleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRow recentSale = _dbManager.GetRecentSale();
                Message = "Displayed information about recent sale.";
            }
            catch (Exception ex)
            {
                Message = "Error displaying information about recent sale: " + ex.Message;
            }
        }

        private void ShowAverageItemsPerTypeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dictionary<string, double> averageItemsPerType = _dbManager.GetAverageItemsPerType();
                Message = "Displayed average number of items for each type of stationery.";
            }
            catch (Exception ex)
            {
                Message = "Error displaying average items per type: " + ex.Message;
            }
        }
    }
}