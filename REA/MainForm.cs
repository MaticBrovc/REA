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
        public int indexing = 6253;

        private EstateManager em = new EstateManager();

        public MainForm()
        {
            InitializeComponent();

            UpdateGUI();

            cbCountry.DataSource = Enum.GetValues(typeof(Countries));
            cbEstate.DataSource = Enum.GetValues(typeof(Estates));
            cbStudy.DataSource = Enum.GetValues(typeof(StudyField));
            cbStore.DataSource = Enum.GetValues(typeof(ShopType));

            //Start the indexing

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void cbEstate_SelectedIndexChanged(object sender, EventArgs e)
        {

            Estates estates = (Estates)cbEstate.SelectedIndex;
            switch (estates)
            {
                case Estates.Residential:
                    cbBuilding.DataSource = Enum.GetValues(typeof(Residentials));
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
            Console.WriteLine(estates);
        }

        public void UpdateGUI()
        {
            lbEstates.Items.Clear();
            lbEstates.Items.AddRange(em.GetValues());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Estate e1 = new Estate(indexing, new Address("Test of button", "212", "Malmo", Countries.Slovenia));
            //em.Add(e1);
            labelRooms.ForeColor = Color.Black;
            labelSize.ForeColor = Color.Black;

            if (!string.IsNullOrEmpty(txtCity.Text) && !string.IsNullOrEmpty(txtStreet.Text) && !string.IsNullOrEmpty(txtZip.Text))
            {
                
                labelError.Visible = false;
                Estates estates = (Estates)cbEstate.SelectedIndex;
                Estate estate_t = null;
                switch (estates)
                {
                    case Estates.Residential:
                        if (!string.IsNullOrEmpty(txtRooms.Text))
                        {
                            labelRooms.ForeColor = Color.Black;
                            Residentials res = (Residentials)cbBuilding.SelectedIndex;
                            int rooms = Int32.Parse(txtRooms.Text);
                            switch (res)
                            {
                                case Residentials.Villa:
                                    estate_t = new Villa(rooms);
                                    break;
                                case Residentials.Rental:
                                    estate_t = new Rental();
                                    break;
                                case Residentials.Tenement:
                                    estate_t = new Tenement();
                                    break;
                                case Residentials.Townhouse:
                                    estate_t = new Townhouse();
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
                            Comercials com = (Comercials)cbBuilding.SelectedIndex;
                            switch (com)
                            {
                                case Comercials.Shop:
                                    estate_t = new Shop();
                                    break;
                                case Comercials.Warehouse:
                                    estate_t = new Warehouse();
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
                        switch (ins)
                        {
                            case Institutionals.School:
                                estate_t = new School();
                                break;
                            case Institutionals.University:
                                estate_t = new University();
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
                    em.Add(estate_t);
                }

            }
            else
            {
                labelError.Visible = true;
            }


            UpdateGUI();
        }

        private void cbBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
