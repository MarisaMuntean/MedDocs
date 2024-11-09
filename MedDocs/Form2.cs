using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedDocs
{
    public partial class Form2 : Form
    {
        public bool ConsentGiven { get; set; }

        public Form2(List<Tuple<string,DateTime>> docs)
        {
            InitializeComponent();
            ConsentGiven = false;
        }

       
    }
}