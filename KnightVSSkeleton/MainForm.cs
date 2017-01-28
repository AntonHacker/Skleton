using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnightVSSkeleton
{
    public partial class MainForm : Form

    {
        Fighter Knight;
        Fighter Skeleton;
        public MainForm()
        {
            InitializeComponent();
            Knight = new Fighter(knightPictureBox);
            Skeleton = new Fighter(skeletonPictureBox);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            skeletonPictureBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

        /// <summary>
        /// После того, как рыцарь и скелет проивзаимодействовали, нужно обновить их здоровье и картинки
        /// </summary>
        public void Update_All()
        {
            throw new System.NotImplementedException();
        }

        private void skeletonAttacks_Click(object sender, EventArgs e)
        {
            Knight.ReceiveDamage(Skeleton.MakeDamage());
            knightsHealth.Text = Knight.TellHealth().ToString();
            if (Knight.IsDead())
            {
            skeletonAttacks.Enabled = false;
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Skeleton.ReceiveDamage(Knight.MakeDamage());
            skeletonsHealth.Text = Skeleton.TellHealth().ToString();
            if (Skeleton.IsDead())
            {
            button1.Enabled = false;
            }      
        }

        private void skeletonsHealth_Click(object sender, EventArgs e)
        {
        
        }
    }
}
