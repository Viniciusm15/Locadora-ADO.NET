﻿using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFPresentatioLayer
{
    public partial class FORMPARATESTES : Form
    {
        public FORMPARATESTES()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ClienteService().Insert(new Cliente());
        }
    }
}
