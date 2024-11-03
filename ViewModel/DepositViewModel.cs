using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1.ViewModel {

	public class DepositViewModel : ObservableObject {

		private Deposit? _deposit;
		public ICommand SaveCommand { get; set; }
		public DepositViewModel() {
			_deposit = new Deposit();
		}
		public DepositViewModel(Deposit deposit) {
			_deposit = deposit;
			CalculateDeposit();
		}
		public string Name {
			get => _deposit.Name;
			set => SetProperty(_deposit.Name, value, _deposit, (dep,val) => dep.Name = val);
		}
		public Decimal InterestRate {
			get => _deposit.InterestRate; set {
				SetProperty(_deposit.InterestRate, value, _deposit, (dep, val) => dep.InterestRate = val);
				CalculateDeposit();
			}
		}
		public int MonthDuration {
			get => _deposit.MonthDuration; set {
				SetProperty(_deposit.MonthDuration, value, _deposit, (dep, val) => dep.MonthDuration = val);
				CalculateDeposit();
			}
		}

		public bool Capitalization {
			get => _deposit.Capitalization; set {
				SetProperty(_deposit.Capitalization, value, _deposit, (dep, val) => dep.Capitalization = val);
				CalculateDeposit();
			}
		}

		public Decimal Result {
			get => _deposit.Result; 
			set => SetProperty(_deposit.Result, value, _deposit, (dep, val) => dep.Result = val);
		}

		public Decimal DepositAmount {
			get => _deposit.DepositAmount; set {
				SetProperty(_deposit.DepositAmount, value, _deposit, (dep, val) => dep.DepositAmount = val);
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
