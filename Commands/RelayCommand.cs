﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.Commands {
	public class RelayCommand : ICommand {
		private readonly Action<object> _executeAction;
		public RelayCommand(Action<object> executeAction) {
			_executeAction = executeAction;
		}
		public bool CanExecute(object? parameter) => true;
		public void Execute(object? parameter) => _executeAction(parameter);

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
	}
}
