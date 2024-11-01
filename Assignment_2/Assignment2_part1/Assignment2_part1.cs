/*
 * This application demonstrates various functionalities including price calculation,
 * date and time selection, and web browsing within a Windows Forms application.
 * The main topics covered in this application include:
 * 
 * 1. Price Calculation:
 *    - NumericUpDown controls are used to input price and quantity.
 *    - A button to calculate the total cost based on the selected price and quantity,
 *      and a label to display the calculated total.
 * 
 * 2. Item Selection:
 *    - A ComboBox for selecting items (e.g., Apple, Banana, Orange).
 *    - A button to show the selected item in a MessageBox.
 * 
 * 3. Date and Time Functionality:
 *    - A DateTimePicker for selecting a single date.
 *    - A MonthCalendar for selecting a range of dates.
 *    - A button to display the selected dates from both the DateTimePicker and MonthCalendar.
 * 
 * 4. Web Browser Functionality:
 *    - A WebBrowser control to display web pages.
 *    - A TextBox for entering URLs and a button to navigate to the specified URL.
 *    - Ensures URLs are formatted correctly with "http://" or "https://" before navigation.
 * 
 * This application combines price calculations, date selections, and web browsing 
 * into a single user interface, showcasing various Windows Forms controls and event handling.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace PriceAndDateTimeWebBrowserApp
{
    public class MainForm : Form
    {
        // Controls for price and date time functionality
        private NumericUpDown numericUpDownPrice;
        private NumericUpDown numericUpDownQuantity;
        private Button buttonCalculate;
        private Label totalLabel; // Label to display the total amount
        private ComboBox comboBoxItems;
        private Button buttonShowSelection;

        private DateTimePicker dateTimePicker;
        private MonthCalendar monthCalendar;
        private Button buttonShowDate;

        // Controls for web browser functionality
        private WebBrowser webBrowser1;
        private TextBox textBoxUrl;
        private Button buttonNavigate;

        public MainForm()
        {
            // Initialize controls
            InitializePriceAndDateTimeControls();
            InitializeWebBrowserControls();

            // Set form properties
            this.Text = "Price, Selection, DateTime, and Web Browser Application";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(850, 700);
        }

        private void InitializePriceAndDateTimeControls()
        {
            // Initialize NumericUpDown for Price
            numericUpDownPrice = new NumericUpDown()
            {
                DecimalPlaces = 2,
                Minimum = 0,
                Maximum = 10000,
                Value = 4.50M,
                Location = new Point(20, 20),
                Width = 100
            };

            // Initialize NumericUpDown for Quantity
            numericUpDownQuantity = new NumericUpDown()
            {
                Minimum = 0,
                Maximum = 100,
                Value = 2,
                Location = new Point(150, 20),
                Width = 100
            };

            // Initialize Calculate Button
            buttonCalculate = new Button()
            {
                Text = "Calculate Total",
                Location = new Point(20, 60),
                Width = 100
            };
            buttonCalculate.Click += ButtonCalculate_Click;

            // Initialize Label for displaying total
            totalLabel = new Label()
            {
                Text = "Total: $0.00",
                Location = new Point(130, 60),
                AutoSize = true
            };

            // Initialize ComboBox for item selection
            comboBoxItems = new ComboBox()
            {
                Location = new Point(20, 100),
                Width = 150
            };
            comboBoxItems.Items.AddRange(new string[] { "Apple", "Banana", "Orange", "Grapes", "Mango" });
            comboBoxItems.SelectedIndex = 0; // Default selection

            // Initialize Show Selection Button
            buttonShowSelection = new Button()
            {
                Text = "Show Selection",
                Location = new Point(180, 100),
                Width = 150
            };
            buttonShowSelection.Click += ButtonShowSelection_Click;

            // Initialize DateTimePicker
            dateTimePicker = new DateTimePicker()
            {
                Location = new Point(20, 150),
                Format = DateTimePickerFormat.Short
            };

            // Initialize MonthCalendar
            monthCalendar = new MonthCalendar()
            {
                Location = new Point(20, 190)
            };

            // Initialize Show Date Button
            buttonShowDate = new Button()
            {
                Text = "Show Selected Dates",
                Location = new Point(20, 400),
                Width = 150
            };
            buttonShowDate.Click += ButtonShowDate_Click;

            // Add all controls to the form
            this.Controls.AddRange(new Control[] {
                numericUpDownPrice,
                numericUpDownQuantity,
                buttonCalculate,
                totalLabel,
                comboBoxItems,
                buttonShowSelection,
                dateTimePicker,
                monthCalendar,
                buttonShowDate
            });
        }

        private void InitializeWebBrowserControls()
        {
            // Initialize WebBrowser control
            webBrowser1 = new WebBrowser()
            {
                Location = new Point(20, 460),
                Size = new Size(800, 400)
            };

            // Initialize TextBox for URL input
            textBoxUrl = new TextBox()
            {
                Location = new Point(20, 420),
                Width = 700
            };

            // Initialize Navigate Button
            buttonNavigate = new Button()
            {
                Text = "Navigate",
                Location = new Point(730, 418)
            };
            buttonNavigate.Click += ButtonNavigate_Click;

            // Add web browser controls to the form
            this.Controls.Add(webBrowser1);
            this.Controls.Add(textBoxUrl);
            this.Controls.Add(buttonNavigate);
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            decimal price = numericUpDownPrice.Value;
            int quantity = (int)numericUpDownQuantity.Value;
            decimal total = price * quantity;
            totalLabel.Text = "Total: $" + total.ToString("F2");
        }

        private void ButtonShowSelection_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBoxItems.SelectedItem.ToString();
            MessageBox.Show("You selected: " + selectedItem);
        }

        private void ButtonShowDate_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker.Value;
            DateTime startDate = monthCalendar.SelectionStart;
            DateTime endDate = monthCalendar.SelectionEnd;

            MessageBox.Show($"DateTimePicker Selected Date: {selectedDate.ToShortDateString()}\n" +
                            $"MonthCalendar Selected Start Date: {startDate.ToShortDateString()}\n" +
                            $"MonthCalendar Selected End Date: {endDate.ToShortDateString()}");
        }

        // Event handler for the Navigate button click
        private void ButtonNavigate_Click(object sender, EventArgs e)
        {
            string url = textBoxUrl.Text;

            // Ensure URL starts with "http://" or "https://"
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "http://" + url;
            }

            // Navigate to the specified URL
            webBrowser1.Navigate(url);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
