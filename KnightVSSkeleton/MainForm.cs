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
        Knight Knight;
        Fighter Skeleton;
        Weapons LongSworld;
        Weapons ShortSworld;
        public MainForm()
        {
            InitializeComponent();
            Knight = new Knight(knightPictureBox,ShortSworld);
            Skeleton = new Fighter(skeletonPictureBox,LongSworld);
            LongSworld = new Weapons()
            {
                MaxDamage = 20,
                MinDamage = 0
            };
            ShortSworld = new Weapons()
            {
                MaxDamage = 15,
                MinDamage = 10
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            skeletonPictureBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

        /// <summary>
        /// После того, как рыцарь и скелет проивзаимодействовали, нужно обновить их здоровье и картинки
        /// </summary>
        public async void Update_All()
        {

            skeletonsHealth.Text = Skeleton.TellHealth().ToString();
            knightsHealth.Text = Knight.TellHealth().ToString();

            if (Skeleton.IsDead() || Knight.IsDead())

            {
                button1.Enabled = false;
                if (Skeleton.IsDead()) MessageBox.Show("Winner Knight ", "Game Over!");
                else MessageBox.Show("Winner Skeleton", "Game Over!");
                await Task.Delay(900);
                Skeleton = new Fighter(skeletonPictureBox,LongSworld);
                Knight = new Knight(knightPictureBox,ShortSworld);
                skeletonsHealth.Text = Skeleton.TellHealth().ToString();
                knightsHealth.Text = Knight.TellHealth().ToString();
                skeletonAttacks.Enabled = true;
                button1.Enabled = true;
                skeletonPictureBox.Image = Image.FromFile(@"E:\Anton Hacker\KnightVSSkeleton-master\KnightVSSkeleton-master\Assets\Skeleton_idle.gif");
                knightPictureBox.Image = Image.FromFile(@"E:\Anton Hacker\KnightVSSkeleton-master\KnightVSSkeleton-master\Assets\Knight_idle.gif");
            }
            }

        private bool button1_Click()
        {
            throw new NotImplementedException();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Skeleton.ReceiveDamage(Knight.MakeDamage()); 
            Update_All();
            knightPictureBox.Image = Image.FromFile(@"E:\Anton Hacker\KnightVSSkeleton-master\KnightVSSkeleton-master\Assets\Knight_Attack.gif");
            await Task.Delay(1000);
            knightPictureBox.Enabled = false;
            knightPictureBox.Enabled = true;
            knightPictureBox.Image = Image.FromFile(@"E:\Anton Hacker\KnightVSSkeleton-master\KnightVSSkeleton-master\Assets\Knight_Idle.gif");

        }

        private async void skeletonAttacks_Click(object sender, EventArgs e)
        {

            Knight.ReceiveDamage(Skeleton.MakeDamage());
            Update_All();
            skeletonPictureBox.Image = Image.FromFile(@"E:\Anton Hacker\KnightVSSkeleton-master\KnightVSSkeleton-master\Assets\Skeleton_Attack.gif");
            await Task.Delay(1000);
            skeletonPictureBox.Enabled = false;
            skeletonPictureBox.Enabled = true;
            skeletonPictureBox.Image = Image.FromFile(@"E:\Anton Hacker\KnightVSSkeleton-master\KnightVSSkeleton-master\Assets\Skeleton_Idle.gif");

        }

        private void knightPictureBox_Click(object sender, EventArgs e)
        {
            
        }
        
    }
}
   


       