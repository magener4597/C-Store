using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//  Name: Martin Gener
//  Assignment: Homework 9
//  Due Date: 5-31-18
//  Description: This program will display functionalities of Windows Form Apps through an online store. It uses labels, checkboxes, and textboxes
//               to read user input and use that input to display total amounts. It also provides a clear function that will reset the form.
//
namespace Store
{
    public partial class StoreCheckout : Form
    {

        int pepQuantity = 0;
        int cheQuantity = 0;
        int delQuantity = 0;
        decimal pepAmount;
        decimal cheAmount;
        decimal delAmount;
        decimal total = 0.0M;
        decimal subtotal = 0.0M;
        decimal tax = 0.07M;
        decimal delivery = 5.00M;

        public StoreCheckout()
        {
            InitializeComponent();
        }

        //Pepperoni quantity textbox
        //Reads quantity and calculates amount
        //outputs amount
        //The name is textBox_Q_WB because thats what it was orginally before i decided to change it to textBox_Q_Pep
        //The new name used inside is textBox_Q_Pep
        private void textBox_Q_WB_TextChanged(object sender, EventArgs e)
        {
            if (checkBox_Pep.Checked == true)
            {
                pepQuantity = Convert.ToInt32(textBox_Q_Pep.Text);
                Convert.ToDecimal(pepQuantity);
                pepAmount = (pepQuantity * 6.25M);
                string output = string.Format("${0}", pepAmount.ToString());
                label_P1Total.Text = output;
            }
            else if (checkBox_Pep.Checked == false)
            {
                MessageBox.Show("Click the checkbox if you want to edit.");
                textBox_Q_Pep.Text = "0";
            }

            RefreshLabels();
        }

        //Cheese quantity textbox
        //The name is textBox_Q_RB because thats what it was orginally before i decided to change it to textBox_Q_Che
        //The new name used inside is textBox_Q_Che
        private void textBox_Q_RB_TextChanged(object sender, EventArgs e)
        {
            if (checkBox_Che.Checked == true)
            {
                cheQuantity = Convert.ToInt32(textBox_Q_Che.Text);
                Convert.ToDecimal(cheQuantity);
                cheAmount = (cheQuantity * 5.00M);
                string output = string.Format("${0}", cheAmount.ToString());
                label_P2Total.Text = output;
            }
            else if (checkBox_Che.Checked == false)
            {
                MessageBox.Show("Click the checkbox if you want to edit.");
                textBox_Q_Che.Text = "0";
            }

            RefreshLabels();
        }

        //Deluxe quantity textbox
        //The name is textBox_Q_BB because thats what it was orginally before i decided to change it to textBox_Q_Del
        //The new name used inside is textBox_Q_Del
        private void textBox_Q_BB_TextChanged(object sender, EventArgs e)
        {
            if (checkBox_Del.Checked == true)
            {
                delQuantity = Convert.ToInt32(textBox_Q_Del.Text);
                Convert.ToDecimal(delQuantity);
                delAmount = (delQuantity * 7.50M);
                string output = string.Format("${0}", delAmount.ToString());
                label_P3Total.Text = output;
            }
            else if (checkBox_Del.Checked == false)
            {
                MessageBox.Show("Click the checkbox if you want to edit.");
                textBox_Q_Del.Text = "0";
            }

            RefreshLabels();
        }

        //This method will automatically re-calculate and display the labels after new inputs
        private void RefreshLabels()
        {
            subtotal = pepAmount + cheAmount + delAmount;
            decimal taxAmount = (subtotal * tax);
            string output = string.Format("${0}", subtotal.ToString());
            string taxOutput = string.Format("${0:0.00}", taxAmount.ToString());
            string delivOutput = string.Format("${0}", delivery.ToString());

            total = subtotal + taxAmount + delivery;
            string totalOutput = string.Format("${0:0.00}", total.ToString());

            label_NumSubtotal.Text = output;
            label_NumTax.Text = taxOutput;
            label_NumDelivery.Text = delivOutput;
            label_NumTotal.Text = totalOutput;

        }

        //Clear button method
        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_OrderNum.Text = "";
            textBox_Name.Text = "Enter Name Here";
            textBox_Ad1.Text = "Address Line 1";
            textBox_Ad2.Text = "Address Line 2";
            textBox_Ad3.Text = "City, State, Zip";
            textBox_Q_Pep.Text = "0";
            textBox_Q_Che.Text = "0";
            textBox_Q_Del.Text = "0";
            label_NumTax.Text = "$0.00";
            label_NumDelivery.Text = "$0.00";
            label_NumTotal.Text = "$0.00";
        }
    }
}
