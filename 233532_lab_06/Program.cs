using System;
using System.Collections;
using System.Windows.Forms;

namespace ArrayListApp
{
    public partial class MainForm : Form
    {
        ArrayList numbers = new ArrayList();  // Create the ArrayList

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumber.Text, out int number))
            {
                numbers.Add(number);
                UpdateListBox();
                lblMessage.Text = $"{number} added to the list.";
            }
            else
            {
                lblMessage.Text = "Please enter a valid integer.";
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumber.Text, out int number))
            {
                if (numbers.Contains(number))
                {
                    numbers.Remove(number);
                    lblMessage.Text = $"{number} removed from the list.";
                }
                else
                {
                    lblMessage.Text = $"{number} not found in the list.";
                }
                UpdateListBox();
            }
            else
            {
                lblMessage.Text = "Please enter a valid integer.";
            }
        }

        private void btnContains_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumber.Text, out int number))
            {
                if (numbers.Contains(number))
                {
                    lblMessage.Text = $"{number} exists in the list.";
                }
                else
                {
                    lblMessage.Text = $"{number} does not exist in the list.";
                }
            }
            else
            {
                lblMessage.Text = "Please enter a valid integer.";
            }
        }

        // Update the ListBox with current ArrayList contents
        private void UpdateListBox()
        {
            listBoxNumbers.Items.Clear();
            foreach (int num in numbers)
            {
                listBoxNumbers.Items.Add(num);
            }
        }
    }
}
