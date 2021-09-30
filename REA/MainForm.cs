using REA.Classes;
using REA.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REA
{
    public partial class MainForm : Form
    {
        //Start indexing
        public int indexing = 6253;

        //Save opened file
        private string fromFile = "";

        //Possibile Objects
        private string[] residentials = {"Villa", "Rental", "Tenement", "Townhouse"};
        private string[] comercials = { "Shop", "Warehouse" };
        private string[] institutionals = { "School", "University" };

        //Declare a new EstateManager that holds the list of all the Estates used in the program
        private EstateManager em1 = new EstateManager();

        //Create a filedialog
        private OpenFileDialog file = new OpenFileDialog();

        private System.Drawing.Image placeholder;

        public MainForm()
        {
            this.KeyPreview = true;
            InitializeComponent();

            UpdateGUI();
            //Set the comboboxes values
            cbCountry.DataSource = Enum.GetValues(typeof(Countries));
            cbEstate.DataSource = Enum.GetValues(typeof(Estates));
            cbStudy.DataSource = Enum.GetValues(typeof(StudyField));
            cbStore.DataSource = Enum.GetValues(typeof(ShopType));
            cbLegal.DataSource = Enum.GetValues(typeof(LegalForm));

            placeholder = pictureBox1.Image;


        }


        private void cbEstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get the selected estate type
            Estates estates = (Estates)cbEstate.SelectedIndex;
            switch (estates)
            {
                //Set the combobox values with the correct types.
                case Estates.Residential:
                    cbBuilding.DataSource = Enum.GetValues(typeof(Residentials));
                    //hide and show the needed data.
                    txtRooms.Show();
                    cbStudy.Hide();
                    cbStore.Hide();
                    txtSize.Hide();
                    break;
                case Estates.Commercial:
                    cbBuilding.DataSource = Enum.GetValues(typeof(Comercials));
                    txtRooms.Hide();
                    cbStudy.Hide();
                    cbStore.Show();
                    txtSize.Show();
                    break;
                case Estates.Institutional:
                    cbBuilding.DataSource = Enum.GetValues(typeof(Institutionals));
                    txtRooms.Hide();
                    cbStudy.Show();
                    cbStore.Hide();
                    txtSize.Hide();
                    break;

            }
        }
        /// <summary>
        /// Refreshes all the values if needed
        /// </summary>
        /// <returns></returns>
        public void UpdateGUI()
        {
            //Clear the entire list
            lbEstates.Items.Clear();
            //Get new values
            lbEstates.Items.AddRange(em1.ToStringArray());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //Set label colors to black(no errors)
            labelRooms.ForeColor = Color.Black;
            labelSize.ForeColor = Color.Black;

            //Check if fields are filed
            if (!string.IsNullOrEmpty(txtCity.Text) && !string.IsNullOrEmpty(txtStreet.Text) && !string.IsNullOrEmpty(txtZip.Text))
            {
                //hide the error message
                labelError.Visible = false;

                //Generate comboboxes based on the selected type.
                Estates estates = (Estates)cbEstate.SelectedIndex;
                Estate estate_t = null;
                switch (estates)
                {
                    case Estates.Residential:
                        if (!string.IsNullOrEmpty(txtRooms.Text))
                        {
                            //Parse number of rooms from string to int
                            //Remove the error color if set
                            int rooms = Int32.Parse(txtRooms.Text);
                            labelRooms.ForeColor = Color.Black;
                            //Get the selected type of building
                            Residentials res = (Residentials)cbBuilding.SelectedIndex;
                            switch (res)
                            {
                                //Based on selection create an object
                                case Residentials.Villa:
                                    estate_t = new Villa(rooms);
                                    break;
                                case Residentials.Rental:
                                    estate_t = new Rental(rooms);
                                    break;
                                case Residentials.Tenement:
                                    estate_t = new Tenement(rooms);
                                    break;
                                case Residentials.Townhouse:
                                    estate_t = new Townhouse(rooms);
                                    break;
                            }
                        }
                        else
                        {
                            //Show error
                            labelRooms.ForeColor = Color.Red;
                        }
                        
                        break;
                    case Estates.Commercial:
                        if (!string.IsNullOrEmpty(txtSize.Text))
                        {
                            //Reset error
                            labelSize.ForeColor = Color.Black;
                            //Parse the size of building
                            int s = Int32.Parse(txtSize.Text);

                            //Get the shop/warehouse type and selected building type
                            ShopType shopType = (ShopType)cbStore.SelectedIndex;
                            Comercials com = (Comercials)cbBuilding.SelectedIndex;
                            switch (com)
                            {
                                //Create an object based on selection
                                case Comercials.Shop:
                                    estate_t = new Shop(shopType, s);
                                    break;
                                case Comercials.Warehouse:
                                    estate_t = new Warehouse(shopType, s);
                                    break;
                            }
                            
                        }
                        else
                        {
                            //Show error
                            labelSize.ForeColor = Color.Red;
                        }
                        break;
                    case Estates.Institutional:
                        //Get selected Study field and  Building type
                        Institutionals ins = (Institutionals)cbBuilding.SelectedIndex;
                        StudyField studyField = (StudyField)cbStore.SelectedIndex;
                        switch (ins)
                        {

                            //Create estate type
                            case Institutionals.School:
                                estate_t = new School(studyField);
                                break;
                            case Institutionals.University:
                                estate_t = new University(studyField);
                                break;
                        }
                        break;

                }
                if(estate_t != null)
                {
                    //Set the index and increment it
                    estate_t.ID = indexing;
                    indexing++;
                    //street, zip, city, country
                    estate_t.Address = new Address(txtStreet.Text, txtZip.Text, txtCity.Text, (Countries)cbCountry.SelectedIndex);

                    //Set the legal form
                    estate_t.LegalForm = (LegalForm)cbLegal.SelectedIndex;
                    if (file.FileName != null)
                    {
                        estate_t.ImagePath = file.FileName;
                    }
                    em1.Add(estate_t);
                }

            }
            else
            {
                //Show error
                labelError.Visible = true;
            }

            //Refresh list
            UpdateGUI();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            //Empty the list and refresh it.
            em1.DeleteAll();
            //Reset all the fields
            resetWindowValues();
            UpdateGUI();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Estate le = em1.GetAt(lbEstates.SelectedIndex);

            Estate updatedEntry = null;
            if(le != null)
            {
                string tipNew = cbBuilding.SelectedItem.ToString();

                //Set default values to variable
                int noRooms = 0;
                int s = 0;
                

                //Get selected type of shop
                ShopType shopType = (ShopType)cbStore.SelectedIndex;

                //try to parse the string to int or catch the errors while parsing.
                try
                {
                    noRooms = Int32.Parse(txtRooms.Text);
                }
                catch (FormatException) { }
                try
                {
                    s = Int32.Parse(txtSize.Text);
                }
                catch (FormatException) { }

                //Get the study field for institutional estates
                StudyField studyField = (StudyField)cbStudy.SelectedIndex;

                //Create updated objects based on the building type
                switch (tipNew)
                {
                    //Residential
                    case "Villa":
                        updatedEntry = new Villa(noRooms);
                        break;
                    case "Rental":
                        updatedEntry = new Rental(noRooms);
                        break;
                    case "Tenement":
                        updatedEntry = new Tenement(noRooms);
                        break;
                    case "Townhouse":
                        updatedEntry = new Townhouse(noRooms);
                        break;

                    //Comercial
                    case "Shop":
                        updatedEntry = new Shop(shopType, s);
                        break;
                    case "Warehouse":
                        updatedEntry = new Warehouse(shopType, s);
                        break;

                    //Institutional

                    case "School":
                        updatedEntry = new School(studyField);
                        break;
                    case "University":
                        updatedEntry = new University(studyField);
                        break;


                }

                //Set the Address to the updated address
                updatedEntry.Address = new Address(txtStreet.Text, txtZip.Text, txtCity.Text, (Countries)cbCountry.SelectedIndex);

                //reset the ID
                updatedEntry.ID = le.ID;

                //Set the legal form
                updatedEntry.LegalForm = (LegalForm)cbLegal.SelectedIndex;

                //Check if user has selected an image, if so, set it to a variable.
                if (file.FileName != null)
                {
                    updatedEntry.ImagePath = file.FileName;
                }
                //Update the entry
                em1.ChangeAt(updatedEntry, lbEstates.SelectedIndex);
            }
            else
            {
                MessageBox.Show("There are no available Estates!");
            }
            //Refresh the list
            UpdateGUI();


            

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Check if deleted
            if (!em1.DeleteAt(lbEstates.SelectedIndex))
            {
                //Show error if not deleted
                MessageBox.Show("There are no available Estates!");
                return;
            }
            //Empty all the values
            resetWindowValues();
            //Refresh the list
            UpdateGUI();
        }

        //When clicked upon the picture box will open a file dialog where you can select an image.
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string path;
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                //Load image from file
                pictureBox1.Image = Image.FromFile(path);
                //Stretch the image so it fits in the frame
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //Set a fixed size of the image
                pictureBox1.Size = new System.Drawing.Size(388, 318);
            }
           
        }

        private void btnCost_Click(object sender, EventArgs e)
        {
            //Display a message box with an estimated price of the estate
            if(em1.GetAt(lbEstates.SelectedIndex) != null)
            {
                MessageBox.Show("The price of the estate is estimated around: " + em1.GetAt(lbEstates.SelectedIndex).Cost().ToString() + "€");
            }
            else
            {
                MessageBox.Show("Please add or select an estate!");
            }
            
        }

        /// <summary>
        /// Fill out all the fields based on the provided index.
        /// </summary>
        /// <param name="index">.</param>
        /// <returns></returns>
        private void fillFields(int index)
        {
            //Empty all the existing values
            resetWindowValues();

            //Get the selected estate
            Estate e = em1.GetAt(index);
            if(e != null)
            {
                //Select the legal form
                cbLegal.SelectedItem = e.LegalForm;

                //Get base type and type of estate
                string baseName = e.GetType().BaseType.Name;
                string name = e.GetType().Name;

                //Select the type of estate
                if (baseName == "Appartment") baseName = "Residential";
                cbEstate.SelectedItem = (Estates)Enum.Parse(typeof(Estates), baseName);
                switch (baseName)
                {
                    //Based on base type set building types and other parameters in regard to that type
                    case "Residential":
                        cbBuilding.SelectedItem = (Residentials)Enum.Parse(typeof(Residentials), name);
                        txtRooms.Text = ((Residential)e).NumberOfRooms.ToString();
                        break;
                    case "Commercial":
                        cbBuilding.SelectedItem = (Comercials)Enum.Parse(typeof(Comercials), name);
                        txtSize.Text = ((Commercial)e).Size.ToString();
                        cbStore.SelectedItem = ((Commercial)e).ShopType;
                        break;
                    case "Institutional":
                        cbBuilding.SelectedItem = (Institutionals)Enum.Parse(typeof(Institutionals), name);
                        cbStudy.SelectedItem = ((Institutional)e).StudyField;
                        break;
                }
                //Get the address and break it into pieces

                //Get the dictionary values from the address field
                Dictionary<string, Object> addr = e.Address.getParemeters();
                //To use values use Cast
                txtCity.Text = (string)addr["city"];
                txtZip.Text = (string)addr["zip"];
                txtStreet.Text = (string)addr["street"];
                cbCountry.SelectedItem = (Countries)addr["country"];

                //If image exists load it othervise set a placeholder
                if (File.Exists(e.ImagePath))
                {
                    pictureBox1.Image = Image.FromFile(e.ImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Size = new System.Drawing.Size(388, 318);
                }
                else
                {
                    pictureBox1.Image = placeholder;
                }
            }
        }

        private void lbEstates_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Fill fields with data from selected object
            int selection = lbEstates.SelectedIndex;
            fillFields(selection);
            
        }

        /// <summary>
        /// Resets all the values
        /// </summary>
        /// <returns></returns>
        private void resetWindowValues()
        {
            // reset all the comboboxes
            cbBuilding.SelectedIndex = 0;
            cbCountry.SelectedIndex = 0;
            cbEstate.SelectedIndex = 0;
            cbLegal.SelectedIndex = 0;
            cbStore.SelectedIndex = 0;
            cbStudy.SelectedIndex = 0;

            //Reset all the text boxes
            txtCity.Text = "";
            txtRooms.Text = "";
            txtSize.Text = "";
            txtStreet.Text = "";
            txtZip.Text = "";

            //Reset image
            pictureBox1.Image = placeholder;

            //ResetGUI
        }

        /// <summary>
        /// Resets all the values and empties the lists
        /// </summary>
        /// <returns></returns>
        private void newWindow()
        {
            //Check if any value is filled
            if (!string.IsNullOrEmpty(txtRooms.Text)
                || !string.IsNullOrEmpty(txtCity.Text)
                || !string.IsNullOrEmpty(txtSize.Text)
                || !string.IsNullOrEmpty(txtStreet.Text)
                || !string.IsNullOrEmpty(txtZip.Text)
                || em1.Count > 0)
            {
                //Get confirmation of user
                DialogResult dr = MessageBox.Show("Are you sure you want to remove all the entries?", "Delete in progress", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

                //If Ok, reset all valeus
                if (dr == DialogResult.Yes)
                {
                    em1.DeleteAll();
                    resetWindowValues();
                }
            }
            //If no valeus exist, reset the fields
            else
            {
                resetWindowValues();
            }
            //Update GUI
            fromFile = "";
            UpdateGUI();
        }

        private void newNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newWindow();  
        }

        /// <summary>
        /// Opens file dialog to select the estates
        /// </summary>
        /// <returns></returns>
        private void openFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Generic Files .dat|*.dat";
            openFileDialog.ShowDialog();
            string path = openFileDialog.FileName;
            if (path != "")
            {
                if (!em1.BinaryDeSerialize(path)) MessageBox.Show("There was an error", "Error");
                else { 
                    fromFile = path; 
                    if(em1.Count > 0)indexing = em1.GetAt(em1.Count - 1).ID + 1;
                }
                UpdateGUI();
            }
        }

        private void openOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        /// <summary>
        /// Saves data into current opened file
        /// </summary>
        /// <returns></returns>
        private void save()
        {
            if (!String.IsNullOrEmpty(fromFile))
            {
                if (em1.BinarySerialize(fromFile)) MessageBox.Show("Successfuly saved!");
                else MessageBox.Show("There are no Estates to save!");
            }
            else saveAs();
        }

        /// <summary>
        /// Opens file dialog and saves the data from EstateManager
        /// </summary>
        /// <returns></returns>
        private void saveAs()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Generic Files .dat|*.dat";
            saveFileDialog1.Title = "Save The Estates";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                if (em1.BinarySerialize(saveFileDialog1.FileName))
                {
                    MessageBox.Show("Successfully saved");
                }
                else
                {
                    MessageBox.Show("There are no Estates to save!");
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAs();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control == true)
            {
                switch (e.KeyCode)
                {
                    case Keys.N:
                        newWindow();
                        break;
                    case Keys.O:
                        openFile();
                        break;
                    case Keys.S:
                        save();
                        break;
                }
                
            }
        }

        /// <summary>
        /// Opens file dialog to select xml file to save the estates
        /// </summary>
        /// <returns></returns>
        private void exportToXML()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML files .xml|*.xml";
            saveFileDialog1.Title = "Save The Estates";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                if (em1.XMLSerialize(saveFileDialog1.FileName))
                {
                    MessageBox.Show("Successfully saved");
                }
                else
                {
                    MessageBox.Show("There are no Estates to save!");
                }
            }
        }

        private void exportToXMLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportToXML();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}