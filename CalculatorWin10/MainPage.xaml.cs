using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CalculatorWin10
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public static object myObj;
        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            myObj = ((Button)sender).Tag;
            ClickHandler.InformationPassed(myObj.ToString());
            expressionView.Text = DisplayInfo.currentExpression;
            screen.Text = DisplayInfo.ExpressionToSuitable();
        }
        // OTHER FUNCTIONS
        private void menu_Click(object sender, RoutedEventArgs e)
        {

        }
        private void history_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
