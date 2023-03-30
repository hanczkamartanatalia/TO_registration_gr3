﻿using Console_Management_of_medical_clinic.Logic;
using Console_Management_of_medical_clinic.Model;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI_Management_of_medical_clinic
{
    public partial class FormUserList : Form
    {
        EmployeeModel currentUser;
        void LoadUserData()
        {
            dataGridViewUsers.DataSource = null;

            if (dataGridViewUsers.Rows.Count > 0)
            {
                dataGridViewUsers.Rows.Clear();
            }

            foreach (UserModel user in UserService.GetUsersData())
            {
                dataGridViewUsers.Rows.Add(user.IdUser, user.Username, user.Role, (user.IsActive == true) ? "Active" : "Not active");
                if (user.IdUser == currentUser.IdUser) { currentUser = EmployeeService.GetEmployeeByUserId(user); }     // it makes user always refreshed
            }

        }

        private void buttonFilterUser_Click(object sender, EventArgs e)
        {
            List<UserModel> filteredUsers = UserService.FilterUsers(textBoxUsername.Text, "", "", comboBoxRole.SelectedItem == null ? "" : comboBoxRole.SelectedItem.ToString());

            dataGridViewUsers.Rows.Clear();
            foreach (UserModel user in filteredUsers)
            {
                dataGridViewUsers.Rows.Add(user.IdUser, user.Username, user.Role, (user.IsActive == true) ? "Active" : "Not Active");
            }

        }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            LoadUserData();
            textBoxFirstname.Text = null;
            textBoxLastname.Text = null;
            textBoxFirstname.Text = null;
            comboBoxRole.SelectedItem = null;
        }

        private void FormUserList_Load(object sender, EventArgs e)
        {
            dataGridViewUsers.Rows.Clear();
            dataGridViewUsers.Columns.Add("IdUser", "Id of user");
            dataGridViewUsers.Columns.Add("Username", "Username");
            //dataGridViewUsers.Columns.Add("FirstName", "First name");
            //dataGridViewUsers.Columns.Add("LastName", "Last name");
            dataGridViewUsers.Columns.Add("Role", "Role");
            dataGridViewUsers.Columns.Add("IsActive", "Is active?");

            LoadUserData();
        }

        public FormUserList(EmployeeModel user)
        {
            currentUser = user;
            InitializeComponent();
        }
    }
}
