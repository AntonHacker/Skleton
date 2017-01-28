using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnightVSSkeleton
{
    public class Fighter
    {
       private int health;
       PictureBox sprite;
       public Fighter (PictureBox sprite)
        {
       this.sprite = sprite;
       this.health = 100;
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
        
        private async void Die()
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


 