﻿using Console_Management_of_medical_clinic.Model;
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
    public partial class FormChangeStatusOfPatient : Form
    {
        Patient patient;
        EmployeeModel currentUser;

        public FormChangeStatusOfPatient(Patient patient2, EmployeeModel currentU)
        {
            InitializeComponent();
            patient = patient2;
            currentUser = currentU;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FormChangeStatusOfPatient_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
