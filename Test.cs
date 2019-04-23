using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace MyobPayroll
{
    [RunInstaller(true)]
    public partial class Test : System.Configuration.Install.Installer
    {
        public Test()
        {
            InitializeComponent();
        }
    }
}
