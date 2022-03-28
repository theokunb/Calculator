using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            scrollViewExpression.SizeChanged += ScrollViewExpression_SizeChanged;
        }

        private void ScrollViewExpression_SizeChanged(object sender, EventArgs e)
        {
            if (scrollViewExpression.Height > 120)
                scrollViewExpression.HeightRequest = 120;
        }
    }
}