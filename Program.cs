﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SmartCortana
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
           

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmCortana());
           
        }
    }
}
