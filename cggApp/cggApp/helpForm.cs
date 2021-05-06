using Smobiler.Core;
using Smobiler.Core.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cggApp
{
    partial class helpForm : Smobiler.Core.Controls.MobileForm
    {
        public helpForm() : base()
        {
            //This call is required by the SmobilerForm.
            InitializeComponent();
        }

        private void imageButton2_Press(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}