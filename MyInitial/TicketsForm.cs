using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNameSpace
{
    public partial class TicketsForm : Form
    {
        TicketPrice mTicketPrice;
        int mSection = 2;
        int mQuantity = 0;
        bool mDiscount = false;
        decimal discountAmount = 0;

        public TicketsForm()
        {
            InitializeComponent();
        }

        private void TicketsForm_Load(object sender, EventArgs e)
        {

        }

        private void cmdCalculate_Click(object sender, EventArgs e)
        {
            mQuantity = int.Parse(txtQuantity.Text);

            if (chkDiscount.Checked)
            {
                mDiscount = true;
                discountAmount = decimal.Parse(discountTextBox.Text);
            }

            if (radBalcony.Checked)
                { mSection = 1; }
            if (radGeneral.Checked)
                { mSection = 2; }
            if (radBox.Checked)
                { mSection = 3; }
            if (backStallRadioButton.Checked)
                { mSection = 4; }

            mTicketPrice = new TicketPrice(mSection, mQuantity, mDiscount, discountAmount);

            mTicketPrice.calculatePrice();
            lblAmount.Text = System.Convert.ToString(mTicketPrice.AmountDue);
        }

        private void sectionRadioButtond_CheckedChanged(object sender, EventArgs e)
        {
            discountTextBox.Text = "5";
        }
    }
}
