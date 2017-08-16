using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmergencyClient
{
    public partial class ImageViewer : Form
    {
        public ImageViewer()
        {
            InitializeComponent();
        }

        public void SetImage(string url)
        {
            this.pictureBox.Load(url);
            this.pictureBox.Size = pictureBox.Image.Size;
        }

        private void ImageViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pictureBox.Image != null)
                pictureBox.Dispose();
        }
    }
}
