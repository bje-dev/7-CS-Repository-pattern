using DAL.Contracts;
using DAL.Repositories.SqlServer;
using DOM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patron_Repository
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IGenericRepository<Address> genericRepository = new AddressRepository();

            Guid id = Guid.Parse(textBox1.Text);
            Address address = genericRepository.GetOne(id);

            label3.Text = address.Street;


        }

        
    }
}
