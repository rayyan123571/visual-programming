using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        private ArrayList arrayList;
        public Form1()
        {
            InitializeComponent();
            arrayList = new ArrayList();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;  // Get text from input TextBox
            if (!string.IsNullOrWhiteSpace(input))
            {
                arrayList.Add(input);  // Add element to ArrayList
                txtInput.Clear();      // Clear the TextBox after adding
                DisplayElements();     // Refresh the ListBox to display updated elements
            }
            else
            {
                MessageBox.Show("Please enter a value.");  // Show message if input is empty
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            if (arrayList.Contains(input))  // Check if element exists in ArrayList
            {
                arrayList.Remove(input);  // Remove element from ArrayList
                txtInput.Clear();         // Clear the TextBox after removing
                DisplayElements();        // Refresh the ListBox
            }
            else
            {
                MessageBox.Show("Element not found in the list.");  // Show message if not found
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            arrayList.Clear();  // Clear all elements in ArrayList
            DisplayElements();  // Refresh the ListBox to show an empty list
        }

        private void btnCheckContains_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            if (arrayList.Contains(input))  // Check if element exists in ArrayList
            {
                MessageBox.Show("The element is present in the list.");
            }
            else
            {
                MessageBox.Show("The element is not in the list.");
            }
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            if (arrayList.Count > 0)
            {
                // Join all elements into a single string separated by commas
                string allElements = string.Join(", ", arrayList.Cast<string>());

                // Show the list in a MessageBox
                MessageBox.Show("Elements in the list: " + allElements, "All Elements");
            }
            else
            {
                // Show a message if the list is empty
                MessageBox.Show("The list is currently empty.", "All Elements");
            }
        }
        private void DisplayElements()
        {
            listBoxElements.Items.Clear();  // Clear ListBox
            foreach (var item in arrayList)
            {
                listBoxElements.Items.Add(item);  // Add each ArrayList item to ListBox
            }
        }

        

       
    }
}
