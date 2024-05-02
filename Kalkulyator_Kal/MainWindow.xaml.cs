using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
using static Kalkulyator_Kal.MainWindow;

namespace Kalkulyator_Kal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double bel;//Ввожу переменные для белков,жиров,углеводов и калорий.
        double zh;
        double ugl;
        double cal;
        public MainWindow()
        {

            InitializeComponent();

            spisok.ItemsSource = new Products[]
            {
                new Products { Name = "Гречка"},
                new Products { Name = "Рис"},
                new Products { Name = "Перловка"},
                new Products { Name = "Пшенка"},
                new Products { Name = "Банан"},
                new Products { Name = "Мед"},
                new Products { Name = "Молоко"}
            };
        }
        public class Products
        { 
            public string Name { get; set; }
            public override string ToString() => $"{Name}";
        }

        private void spisok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (spisok.SelectedIndex == 0)//гречка
            {
                bel = 0.095; zh = 0.023; ugl = 0.604;
                cal = 3.13; //Присваиваю переменным значение, в зависимости от выбранного продукта
            }
            if (spisok.SelectedIndex == 1)//рис
            {
                bel = 0.067; zh = 0.01; ugl = 0.740;
                cal = 3.34;
            }
            if (spisok.SelectedIndex == 2)//перловка
            {
                bel = 0.093; zh = 0.01; ugl = 0.669;
                cal = 3.2;
            }
            if (spisok.SelectedIndex == 3)//пшенка
            {
                bel = 0.160; zh = 0.01; ugl = 0.70;
                cal = 1.35;
            }
            if (spisok.SelectedIndex == 4)//банан
            {
                bel = 0.01; zh = 0.0033; ugl = 0.228;
                cal = 1.11;
            }
            if (spisok.SelectedIndex == 5)//мед
            {
                bel = 0.08; zh = 0; ugl = 0.80;
                cal = 3.28;
            }
            if (spisok.SelectedIndex == 6)//молоко
            {
                bel = 0.029; zh = 0.032; ugl = 0.047;
                cal = 0.60;
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            double b = Convert.ToDouble(textBox2.Text); //Ввожу переменную b и присваюваю ей значение, введенное пользователем
            double x = bel * b;//Ррасчитываю количество белков,жиров,углеводов и калорий,и вывожу их значение.
            double z = zh * b;
            double y = ugl * b;
            double a = cal * b;
            label3.Content = a.ToString();
            label5.Content = x.ToString();
            label6.Content = z.ToString();
            label7.Content = y.ToString();
            label1.Content = "Ты молодец!";
        }
        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox2.Text.Length == 0)//Делаю кнопку "Рассчитать" неактивной, если пользователь не ввел число.
            {
                button1.IsEnabled = false;
            }
            else
                button1.IsEnabled = true;
        }

        private void textBox2_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
                e.Handled = true;//Делаю так, чтобы вводить можно было только цифры от 0 до 9
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
