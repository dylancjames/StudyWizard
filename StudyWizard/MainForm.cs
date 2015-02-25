﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StudyWizard
{
    public partial class MainForm : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        PandQ pandQ = new PandQ();
        Questions questions = new Questions();
        public bool textFileSelected = false;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_study_Click(object sender, EventArgs e)
        {
            if (textFileSelected)
            {
                SelectStudyForm selectStudyForm = new SelectStudyForm(this, pandQ, questions);
                selectStudyForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You didn't select a file! Click \"Load File\" and then select a file you wish to study from.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btn_edit_Click(object sender, EventArgs e)
        {
            SelectEditForm selectEditForm = new SelectEditForm(this, pandQ, textFileSelected);
            selectEditForm.Show();
            this.Hide();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            openFileDialog.ShowDialog();
            try
            {
                string file = openFileDialog.FileName;
                pandQ.file = file;
                pandQ.loadTextFile();
                textFileSelected = true;
            }
            catch { }
        }
    }
}
