using REA.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        //Declare a new EstateManager that will hold all the estate entries
        private EstateManager em = new EstateManager();

        //Create a filedialog
        private OpenFileDialog file = new OpenFileDialog();

        private System.Drawing.Image placeholder;

        public MainForm()
        {
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

        public void UpdateGUI()
        {
            //Clear the entire list
            lbEstates.Items.Clear();
            //Get new values
            lbEstates.Items.AddRange(em.GetValues());
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
                    em.Add(estate_t);
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
            em.Empty();
            txtCity.Text = "";
            txtRooms.Text = "";
            txtSize.Text = "";
            txtStreet.Text = "";
            txtZip.Text = "";
            pictureBox1.Image = placeholder;
            UpdateGUI();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Zadnji zapis znotraj managerja drzi vrednost(tip zgradbe), če primerjam ta tip z novimi podatki in je novi drugačen od starega je objekt potrebno zamenjati.
            //Če ni samo posodobi podatke.
            Estate lastEntry = em.getLastEntry();
            Estate updatedEntry = null;
            if(lastEntry != null)
            {
                string tip = em.getLastEntry().GetType().Name;
                string tipNew = cbBuilding.SelectedItem.ToString();

                //Instead of updating just create a new object an replace it, but leave the same ID.
                //TODO

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
                updatedEntry.ID = lastEntry.ID;

                //Set the legal form
                updatedEntry.LegalForm = (LegalForm)cbLegal.SelectedIndex;

                //Check if user has selected an image, if so, set it to a variable.
                if (file.FileName != null)
                {
                    updatedEntry.ImagePath = file.FileName;
                }
                //Update the entry
                em.updateLast(updatedEntry);
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
            //Delete current object or show an error box.

            if (!em.deleteCurrent())
            {
                MessageBox.Show("There are no available Estates!");
                return;
            }
            txtCity.Text = "";
            txtRooms.Text = "";
            txtSize.Text = "";
            txtStreet.Text = "";
            txtZip.Text = "";
            pictureBox1.Image = placeholder;
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
                pictureBox1.Size = new System.Drawing.Size(247, 229);
            }
           
        }

        private void btnCost_Click(object sender, EventArgs e)
        {
            //Display a message box with an estimated price of the estate
            MessageBox.Show("The price of the estate is estimated around: " + em.getLastEntry().Cost().ToString() + "€");
        }
    }
}
