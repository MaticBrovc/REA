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

        public MainForm()
        {
            InitializeComponent();

            UpdateGUI();
            //Set the comboboxes values
            cbCountry.DataSource = Enum.GetValues(typeof(Countries));
            cbEstate.DataSource = Enum.GetValues(typeof(Estates));
            cbStudy.DataSource = Enum.GetValues(typeof(StudyField));
            cbStore.DataSource = Enum.GetValues(typeof(ShopType));

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

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
                            int rooms = Int32.Parse(txtRooms.Text);
                            labelRooms.ForeColor = Color.Black;
                            Residentials res = (Residentials)cbBuilding.SelectedIndex;
                            switch (res)
                            {
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
                            labelRooms.ForeColor = Color.Red;
                        }
                        
                        break;
                    case Estates.Commercial:
                        if (!string.IsNullOrEmpty(txtSize.Text))
                        {
                            labelSize.ForeColor = Color.Black;
                            int s = Int32.Parse(txtSize.Text);
                            ShopType shopType = (ShopType)cbStore.SelectedIndex;
                            Comercials com = (Comercials)cbBuilding.SelectedIndex;
                            switch (com)
                            {
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
                            labelSize.ForeColor = Color.Red;
                        }
                        break;
                    case Estates.Institutional:
                        Institutionals ins = (Institutionals)cbBuilding.SelectedIndex;
                        StudyField studyField = (StudyField)cbStore.SelectedIndex;
                        switch (ins)
                        {
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
                    estate_t.ID = indexing;
                    indexing++;
                    //street, zip, city, country
                    estate_t.Address = new Address(txtStreet.Text, txtZip.Text, txtCity.Text, (Countries)cbCountry.SelectedIndex);
                    if (file.FileName != null)
                    {
                        estate_t.ImagePath = file.FileName;
                    }
                    em.Add(estate_t);

                    Console.WriteLine(estate_t.ImagePath);
                    //Console.WriteLine(estate_t.GetType());
                }

            }
            else
            {
                labelError.Visible = true;
            }

            //Refresh list
            UpdateGUI();
        }

        private void cbBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            //None
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            //Empty the list and refresh it.
            em.Empty();
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
                StudyField studyField = (StudyField)cbStore.SelectedIndex;

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
            }
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
            //TODO calculate cost lastEstate.Cost();
            //Messagebox

        }
    }
}
