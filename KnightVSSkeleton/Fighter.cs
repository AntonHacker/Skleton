using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnightVSSkeleton
{
    public class Fighter
    {
       private int health;
       protected PictureBox sprite;
        private PictureBox skeletonPictureBox;
        Weapons Myweapon;

        public Fighter (PictureBox sprite,Weapons Myweapon)
        {
       this.Myweapon = Myweapon;
       this.sprite = sprite;
       this.health = 100;
        }

        public Fighter(PictureBox skeletonPictureBox)
        {
            this.skeletonPictureBox = skeletonPictureBox;
        }

        public int MakeDamage() 
        {
        Random random = new Random();
        return random.Next(1, 10);
         }
        
        public void ReceiveDamage(int howMuchDamage)
        {
        health -= howMuchDamage;
        if (health <= 0)
            {
            health = 0;
                Die();
            }
        }
        public int TellHealth()
        {
            return health;
        }
        
        protected virtual async void Die()
        {
            sprite.Image = Image.FromFile(@"E:\Anton Hacker\KnightVSSkeleton-master\KnightVSSkeleton-master\Assets\Skeleton_Death.gif");
            await Task.Delay(1000);
            sprite.Enabled = false;
        }

        public bool IsDead()
        {
            if (health <= 0) return true;
            else return false;
        }
        
      
 
        }
        
    
    
      
        
    }


 