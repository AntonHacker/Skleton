using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnightVSSkeleton
{
    class Knight : Fighter
    {
        public Knight(PictureBox skeletonPictureBox) : base(skeletonPictureBox)
        {
        }

        public Knight (PictureBox sprite, Weapons MyWeapon) : base(sprite, MyWeapon) 
        {
        
        }
        protected override async void Die()
        {

            sprite.Image = Image.FromFile(@"E:\Anton Hacker\KnightVSSkeleton-master\KnightVSSkeleton-master\Assets\Knight_Death.gif");
            await Task.Delay(1000);
            sprite.Enabled = false;
        }
        

    }
     
}

