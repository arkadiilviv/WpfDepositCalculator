using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.Windows;

namespace WpfApp1.ViewModel {
	public class DepositListViewModel : ObservableObject {
		public static int Inc = 0;
		public ObservableCollection<DepositViewModel> _deposits = new ObservableCollection<DepositViewModel>();
		public ICommand AddCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand OpenCommand { get; set; }
		public ObservableCollection<DepositViewModel> Deposits {
			get { return _deposits; }
			set {
				SetProperty(ref _deposits, value);
			}
		}
		public DepositListViewModel() {

			AddCommand = new RelayCommand((object param) => AddDeposit());
			DeleteCommand = new RelayCommand((param) => DeleteDeposit((DepositViewModel)param));
			OpenCommand = new RelayCommand((param) => OpenDeposit((DepositViewModel)param));
		}
		public void AddDeposit() {
			Deposits.Add(new DepositViewModel() { Name = "dep:" + Inc });
			Inc++;
		}

		public void DeleteDeposit(DepositViewModel deposit) {
			Deposits.Remove(deposit);
		}
		public void OpenDeposit(DepositViewModel deposit) {
			DepositWindow depositWindow = new DepositWindow(deposit);
			depositWindow.Owner = Application.Current.MainWindow;
			depositWindow.ShowDialog();
		}
	}
}
