/*
 * This program demonstrates various Windows Forms controls and their functionalities.
 * The main topics covered in this application include:
 * 
 * 1. MessageBox:
 *    - Displaying a message box with "OK" and "Cancel" options when a button is clicked.
 * 
 * 2. LinkLabel:
 *    - Providing a hyperlink that opens a web browser when clicked.
 * 
 * 3. TextBox:
 *    - Accepting user input (name) through a TextBox and displaying it in a MessageBox.
 * 
 * 4. RichTextBox:
 *    - Demonstrating the use of a RichTextBox to enter and display formatted text.
 *    - Changing the font style of the text using two buttons.
 * 
 * 5. CheckBox:
 *    - Allowing multiple selections of items (Pencil, Sharpener, Pen) using CheckBox controls.
 * 
 * 6. RadioButton:
 *    - Allowing the user to select a gender (Male/Female) using RadioButton controls.
 * 
 * 7. PictureBox:
 *    - Displaying an image selected by the user from their file system using a PictureBox control.
 * 
 * 8. File Dialog:
 *    - Using an OpenFileDialog to let the user choose an image file to load into the PictureBox.
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CombinedAppDemo
{
    public class MainForm : Form
    {
        // Controls for the MessageBox and LinkLabel demo
        private Button displayButton;
        private LinkLabel linkLabel;

        // Controls for the TextBox demo
        private Label promptLabel;
        private TextBox nameTextBox;
        private Button showButton;

        // Controls for the RichTextBox demo
        private RichTextBox richTextBox;
        private Button oldFontButton;
        private Button newFontButton;

        // Controls for the CheckBox and RadioButton demo
        private CheckBox checkBoxPencil;
        private CheckBox checkBoxSharpener;
        private CheckBox checkBoxPen;
        private RadioButton radioButtonMale;
        private RadioButton radioButtonFemale;
        private Button buttonBuy;
        private Button buttonGender;

        // Controls for the PictureBox demo
        private Button loadImageButton;
        private PictureBox pictureBox;

        public MainForm()
        {
            // Initialize the button for displaying the message box
            displayButton = new Button();
            displayButton.Text = "Show Message";
            displayButton.Location = new System.Drawing.Point(20, 20);
            displayButton.Click += new EventHandler(button_Click);

            // Initialize the LinkLabel and set its properties
            linkLabel = new LinkLabel();
            linkLabel.Text = "For more information, click here to visit OpenAI.";
            linkLabel.Location = new System.Drawing.Point(20, 60);
            linkLabel.AutoSize = true; // Adjusts size to fit the text
            linkLabel.Links.Add(45, 4, "https://www.openai.com");
            linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel_LinkClicked);

            // Initialize the Label and TextBox for name input
            promptLabel = new Label();
            promptLabel.Text = "Enter your name:";
            promptLabel.Location = new System.Drawing.Point(20, 100);
            promptLabel.AutoSize = true; // Adjusts size to fit the text

            nameTextBox = new TextBox();
            nameTextBox.Location = new System.Drawing.Point(20, 130);
            nameTextBox.Width = 200;

            // Initialize the Button to show the name entered
            showButton = new Button();
            showButton.Text = "Show Name";
            showButton.Location = new System.Drawing.Point(20, 160);
            showButton.Click += new EventHandler(showButton_Click);

            // Initialize the RichTextBox and set its properties
            richTextBox = new RichTextBox();
            richTextBox.Location = new Point(20, 200);
            richTextBox.Size = new Size(360, 100);
            richTextBox.Font = new Font("Arial", 12); // Default font
            richTextBox.ScrollBars = RichTextBoxScrollBars.Vertical; // Enable vertical scroll bars

            // Initialize the Old Font Button and set its properties
            oldFontButton = new Button();
            oldFontButton.Text = "Set Old Font";
            oldFontButton.Location = new Point(20, 310);
            oldFontButton.Click += new EventHandler(oldFontButton_Click);

            // Initialize the New Font Button and set its properties
            newFontButton = new Button();
            newFontButton.Text = "Set New Font";
            newFontButton.Location = new Point(150, 310);
            newFontButton.Click += new EventHandler(newFontButton_Click);

            // Initialize CheckBoxes for items
            checkBoxPencil = new CheckBox() { Text = "Pencil", Location = new System.Drawing.Point(20, 350) };
            checkBoxSharpener = new CheckBox() { Text = "Sharpener", Location = new System.Drawing.Point(20, 380) };
            checkBoxPen = new CheckBox() { Text = "Pen", Location = new System.Drawing.Point(20, 410) };

            // Initialize RadioButtons for gender selection
            radioButtonMale = new RadioButton() { Text = "Male", Location = new System.Drawing.Point(150, 350) };
            radioButtonFemale = new RadioButton() { Text = "Female", Location = new System.Drawing.Point(150, 380) };

            // Initialize Buttons for CheckBox and RadioButton actions
            buttonBuy = new Button() { Text = "Buy", Location = new System.Drawing.Point(20, 440) };
            buttonBuy.Click += new EventHandler(buttonBuy_Click);

            buttonGender = new Button() { Text = "Click Gender", Location = new System.Drawing.Point(150, 440) };
            buttonGender.Click += new EventHandler(buttonGender_Click);

            // Initialize the PictureBox
            pictureBox = new PictureBox()
            {
                Location = new Point(20, 480),
                Size = new Size(360, 250),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom // Adjusts the image size
            };

            // Initialize the Load Image Button
            loadImageButton = new Button()
            {
                Text = "Load Image",
                Location = new Point(20, 740)
            };
            loadImageButton.Click += new EventHandler(loadImageButton_Click);

            // Add all controls to the form
            this.Controls.Add(displayButton);
            this.Controls.Add(linkLabel);
            this.Controls.Add(promptLabel);
            this.Controls.Add(nameTextBox);
            this.Controls.Add(showButton);
            this.Controls.Add(richTextBox);
            this.Controls.Add(oldFontButton);
            this.Controls.Add(newFontButton);
            this.Controls.Add(checkBoxPencil);
            this.Controls.Add(checkBoxSharpener);
            this.Controls.Add(checkBoxPen);
            this.Controls.Add(radioButtonMale);
            this.Controls.Add(radioButtonFemale);
            this.Controls.Add(buttonBuy);
            this.Controls.Add(buttonGender);
            this.Controls.Add(pictureBox);
            this.Controls.Add(loadImageButton);

            // Set form properties
            this.Text = "Combined Application Demo";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(400, 1100);
        }

        private void button_Click(object sender, EventArgs e)
        {
            // Display a message box when the button is clicked
            DialogResult result = MessageBox.Show("Hello World", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            // Handle the result of the message box buttons
            if (result == DialogResult.OK)
            {
                MessageBox.Show("You clicked OK!");
            }
            else
            {
                MessageBox.Show("You clicked Cancel!");
            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the default web browser
            Process.Start(new ProcessStartInfo("cmd", $"/c start {e.Link.LinkData}") { CreateNoWindow = true });
        }

        // Event handler for showing the name entered in the TextBox
        private void showButton_Click(object sender, EventArgs e)
        {
            // Get the name entered in the TextBox
            string name = nameTextBox.Text;
            MessageBox.Show("Hello, " + name + "!");
        }

        // Event handler for setting the old font in the RichTextBox
        private void oldFontButton_Click(object sender, EventArgs e)
        {
            richTextBox.Font = new Font("Arial", 10); // Set to old font style
        }

        // Event handler for setting the new font in the RichTextBox
        private void newFontButton_Click(object sender, EventArgs e)
        {
            richTextBox.Font = new Font("Courier New", 16); // Set to new font style
        }

        // Event handler for the buy button
        private void buttonBuy_Click(object sender, EventArgs e)
        {
            string items = "Items selected:\n";
            if (checkBoxPencil.Checked) items += "- Pencil\n";
            if (checkBoxSharpener.Checked) items += "- Sharpener\n";
            if (checkBoxPen.Checked) items += "- Pen\n";

            if (items == "Items selected:\n")
            {
                items = "No items selected.";
            }

            MessageBox.Show(items, "Selected Items");
        }

        private void buttonGender_Click(object sender, EventArgs e)
        {
            string gender = radioButtonMale.Checked ? "Male" : "Female";
            MessageBox.Show("Selected Gender: " + gender, "Gender");
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select an Image"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        [STAThread]
        static void Main()
        {
            // Run the Windows Forms application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
