using System;
using System.Windows.Forms;

namespace lab07_activity2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPlaceOrder_Click(object sender, EventArgs e)
        {
            // Get the selected size
            string size = comboBoxSize.SelectedItem?.ToString() ?? "No size selected";

            // Get selected toppings
            string toppings = "";
            if (checkBoxCheese.Checked) toppings += "Cheese, ";
            if (checkBoxPepperoni.Checked) toppings += "Pepperoni, ";
            if (checkBoxMushrooms.Checked) toppings += "Mushrooms, ";
            if (string.IsNullOrEmpty(toppings)) toppings = "No toppings selected";
            else toppings = toppings.TrimEnd(',', ' ');

            // Get selected crust
            string crust = "";
            if (radioButtonThinCrust.Checked) crust = "Thin Crust";
            else if (radioButtonThickCrust.Checked) crust = "Thick Crust";
            else crust = "No crust selected";

            // Display the order summary
            labelOrderSummary.Text = $"Order Summary:\nSize: {size}\nToppings: {toppings}\nCrust: {crust}";
        }
    }
}
