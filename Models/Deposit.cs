using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models {
	public class Deposit {
		public string Name { get; set; }
		public Decimal DepositAmount { get; set; }
		public Decimal InterestRate { get; set; }
		public Decimal Result { get; set; }
		public int MonthDuration { get; set; }
		public bool Capitalization { get; set; }
	}
}
