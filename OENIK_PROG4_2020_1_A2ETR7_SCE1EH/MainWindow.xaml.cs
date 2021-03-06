﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OENIK_PROG4_2020_1_A2ETR7_SCE1EH
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FinalScoreViewModel finalScoreObj;
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(FinalScoreViewModel vm) : this()
        {
            finalScoreObj = vm;
            this.DataContext = finalScoreObj;
        }
    }
}
