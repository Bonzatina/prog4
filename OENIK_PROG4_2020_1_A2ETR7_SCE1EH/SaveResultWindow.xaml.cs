using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace OENIK_PROG4_2020_1_A2ETR7_SCE1EH
{
    /// <summary>
    /// Interaction logic for SaveResultWindow.xaml
    /// </summary>
    public partial class SaveResultWindow : Window
    {
        FinalScoreViewModel finalScoreObj;

        public SaveResultWindow()
        {
            InitializeComponent();
          
        }

        public SaveResultWindow(FinalScoreViewModel vm, string finalScore) : this()
        {
            finalScoreObj = vm;
            finalScoreObj.FinalScore = finalScore;
            this.DataContext = finalScoreObj;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.finalScoreObj.resultNames.Add(new Tuple<string, string>(finalScoreObj.Name, finalScoreObj.FinalScore));
            DialogResult = true;
        }
    }



    public class FinalScoreViewModel : ViewModelBase
    {
        public bool loadGame { get; set; } = false;
        string finalScore;
        public string FinalScore
        {
            get { return finalScore; }
            set
            {
                Set(ref finalScore, value);
            }
        }
        string name;
        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }

        public ObservableCollection<Tuple<string, string>> resultNames { get; set; }

        public FinalScoreViewModel()
        {
            resultNames = new ObservableCollection<Tuple<string, string>>();
            resultNames.Add(new Tuple<string, string>("test", "0"));
        }
    }

}
