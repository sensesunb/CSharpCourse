using CoffeeShop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeForms
{
    public partial class Form1 : Form
    {
        private Cashier Cashier { get; set; }
        private CoffeeShop.Menu Options { get; set; }

        public Form1()
        {
            InitializeComponent();
            Cashier = new Cashier();
            Options = new CoffeeShop.Menu(@"C:\Users\cris\Documents\work\IEEE\src\sensesunb\CSharpCourse\dunkindonuts.txt");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            foreach (var description in Options.GetDescriptions()) {
                listMenu.Items.Add(description);
            }
            Cashier.Start();
            buttonStart.Enabled = false;
            buttonOk.Enabled = buttonAdd.Enabled = buttonDelete.Enabled = true;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;
            buttonOk.Enabled = buttonAdd.Enabled = buttonDelete.Enabled = false;
            listMenu.Items.Clear();
            listOrder.Items.Clear();

            Cashier.Finish();
            MessageBox.Show(string.Format("{0:C}", Cashier.Total), "Compra Concluída! ☺");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (listMenu.SelectedIndex >= 0)
            {
                var coffeeName = listMenu.SelectedItem as string;
                Cashier.Add(Options.GetCoffee(coffeeName));
                listOrder.Items.Add(coffeeName);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listOrder.SelectedIndex >= 0)
            {
                int index = listOrder.SelectedIndex;
                // TODO Implement removal of list items
                listOrder.Items.RemoveAt(index);
            }
        }
    }
}
