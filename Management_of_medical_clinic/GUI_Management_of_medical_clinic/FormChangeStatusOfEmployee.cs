﻿using Console_Management_of_medical_clinic.Logic;
using Console_Management_of_medical_clinic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Management_of_medical_clinic
{
    public partial class FormChangeStatusOfEmployee : Form
    {
        
        EmployeeModel employee;
        EmployeeModel currentUser;
        
        public FormChangeStatusOfEmployee(EmployeeModel emp, EmployeeModel currentU)
        {
            InitializeComponent();
            employee = emp;
            currentUser = currentU;
        }

        private void FormChangeStatusOfEmployee_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            FormEmployeeList formEmployeeList = new FormEmployeeList(currentUser);
            this.Hide();
            formEmployeeList.ShowDialog();
            this.Close();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            /*
            if (textBoxPassword.Text != currentUser.Password)
            {
                MessageBox.Show("Invalid password!");
                return;
            }
            */

            EmployeeModel.ChangeEmployeeStatus(employee);
            FormEmployeeList formEmployeeList = new FormEmployeeList(currentUser);
            this.Hide();
            formEmployeeList.ShowDialog();
            this.Close();
        }
    }
}
