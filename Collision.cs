using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace PlatFormer
{
    public class Collision
    {

        
        
        internal void CollisionListCheck(List<Platform> platformList, Rect rectPlayer, Player player)
        {
            bool onGround = false;
            foreach (var item in platformList)
            {
                Rect rect = new Rect(item.PositionX, item.PositionY, item.Lenght, item.Height);
                bool check = rectPlayer.IntersectsWith(rect);

                if (check && player.Jumping != Jumping.Up)
                {
                    player.Jumping = Jumping.Standstill;
                    onGround = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
            if (onGround == false && player.Jumping != Jumping.Up)
            {
                player.Jumping = Jumping.Down;
            }
        }

        public static void FellOff(Rect player, Rect platform, Player thePlayer)
        {
            bool check = player.IntersectsWith(platform);

            if (check || thePlayer.PositionY < platform.Bottom)
            {
                thePlayer.PositionX = 650;
                thePlayer.PositionY = 300;
            }
        }

       


    }
}
