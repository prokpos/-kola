﻿using SharedProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaAplication
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly Model model;
        private readonly CalculationService calculationService;

        public double LoanAmount
        {
            get => model.LoanAmount;
            set
            {
                model.LoanAmount = value;
                Calculate();
            }
        }

        public double InterestRate
        {
            get => model.InterestRate;
            set
            {
                model.InterestRate = value;
                Calculate();
            }
        }

        public int LoanTerm
        {
            get => model.LoanTerm;
            set
            {
                model.LoanTerm = value;
                Calculate();
            }
        }

        private double _monthlyPayment;


        public double MonthlyPayment
        {
            get => _monthlyPayment;
            set
            {
                _monthlyPayment = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MonthlyPayment)));
            }
        }

        public ViewModel()
        {
            model = new Model(8000000.0, 6.0, 30);
            calculationService = new CalculationService();

            Calculate();
        }

        private void Calculate()
        {
            MonthlyPayment = calculationService.MonthlyPayment(LoanAmount, InterestRate, LoanTerm);
        }
    }
}
