using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;

namespace WpfApp1.ViewModel {

	public class DepositViewModel : ViewModelBase {
		private Deposit _deposit;
		public ICommand SaveCommand { get; set; }
		public DepositViewModel() {
			_deposit = new Deposit();
			SaveCommand = new RelayCommand((param) => SaveItem());
		}

		public void SaveItem() {
			OnPropertyChanged(nameof(DepositListViewModel.Deposits));
		}

		public DepositViewModel(Deposit deposit) {
			_deposit = deposit;
			CalculateDeposit();
		}
		public string Name {
			get => _deposit.Name; set {
				_deposit.Name = value;
				OnPropertyChanged(nameof(Name));
			}
		}
		public Decimal InterestRate {
			get => _deposit.InterestRate; set {
				_deposit.InterestRate = value;
				OnPropertyChanged(nameof(InterestRate));
				CalculateDeposit();
			}
		}
		public int MonthDuration {
			get => _deposit.MonthDuration; set {
				_deposit.MonthDuration = value;
				OnPropertyChanged(nameof(MonthDuration));
				CalculateDeposit();
			}
		}

		public bool Capitalization {
			get => _deposit.Capitalization; set {
				_deposit.Capitalization = value;
				OnPropertyChanged(nameof(Capitalization));
				CalculateDeposit();
			}
		}

		public Decimal Result {
			get => _deposit.Result; set {
				_deposit.Result = value;
				OnPropertyChanged(nameof(Result));
			}
		}

		public Decimal DepositAmount {
			get => _deposit.DepositAmount; set {
				_deposit.DepositAmount = value;
				OnPropertyChanged(nameof(DepositAmount));
				CalculateDeposit();
			}
		}

		private void CalculateDeposit() {
			Decimal time = MonthDuration / 12;
			if (Capitalization) {
				Result = DepositAmount * (Decimal)Math.Pow(1 + ((double)InterestRate / 1200), MonthDuration);

			} else {
				Result = DepositAmount + ((DepositAmount * InterestRate * time) / 100);
			}

		}
	}
}
