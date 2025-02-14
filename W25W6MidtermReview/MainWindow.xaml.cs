using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace W25W6MidtermReview;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    Employee _emp;
    List<Employee> _employees = new List<Employee>();

    public MainWindow()
    {
        InitializeComponent();
        rdoHourly.IsChecked = true;
    }

    private void rdoCommission_Checked(object sender, RoutedEventArgs e)
    {
        lblInput2.Content = "Gross Sales";
        lblInput3.Content = "Commission Rate";
    }

    private void rdoHourly_Checked(object sender, RoutedEventArgs e)
    {
        lblInput2.Content = "Hours Worked";
        lblInput3.Content = "Hourly Wage";
    }

    private void btnCalculate_Click(object sender, RoutedEventArgs e)
    {
        string name = txtName.Text;

        if (rdoHourly.IsChecked == true)
        {
            int hours = int.Parse(txtInput2.Text);
            double wage = double.Parse(txtInput3.Text);

            _emp = new HourlyEmployee(name, hours, wage);
        }
        else
        {
            double grossSales = double.Parse(txtInput2.Text);
            double commissionRate = double.Parse(txtInput3.Text) / 100;

            _emp = new CommissionEmployee(name, grossSales, commissionRate);
        }

        txtGrossEarnings.Text = _emp.GrossEarnings().ToString("C");
        txtTax.Text = _emp.Tax().ToString("C");
        txtNetEarnings.Text = _emp.NetEarnings().ToString("C");

        // add name to the listbox
        lstEmployees.Items.Add(name);

        // add the emp object to the List<>
        _employees.Add(_emp);
    }
}