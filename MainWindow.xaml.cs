using System;
using System.Collections.Generic;
using System.Data;
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
using WPFCalculator.Zyrian.Validator;

namespace WPFCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            foreach (UIElement element in MainGrid.Children)
            {
                if (element is Button)
                {
                    ((Button)element).Click += ButtonClick;
                }
            }
        }

        SimpleExpressionValidator validator = new SimpleExpressionValidator();

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string buttonContent = (string)((Button)e.OriginalSource).Content;

            switch (buttonContent)
            {
                
                case "EC": Clear(); break;
                case "C": Delete(); break;
                case "=":
                    {
                        if (validator.IsSecondOperandExist(resultLabel.Text))
                        {
                            resultLabel.Text += validator.AddSecondOperand();
                        }
                        string value = new DataTable().Compute(resultLabel.Text, null).ToString();
                        resultLabel.Text = value;
                        break;
                    }
                default:
                    resultLabel.Text += buttonContent;
                    break;
            }
        }

        private void Clear() => resultLabel.Text = "";

        private void Delete()
        {
            string initialString = resultLabel.Text;
            if (initialString.Length > 0 && initialString != null)
            {
                resultLabel.Text = initialString.Remove(initialString.IndexOf(initialString.Last()), 1);
            }             
        }
    }
}
