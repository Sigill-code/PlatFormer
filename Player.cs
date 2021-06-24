using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PlatFormer
{
    public enum Movement
    {
        Left,
        Right,
        Standstill  
    }
    public enum Jumping
    {
        Up,
        Down,
        Standstill
    }
    public class Player
    {
        double positionX;
        double positionY;
        string image;
        double moveSpeed = 10;
        double jumpSpeed = 15;
        double fallSpeed = 12;
        int playerJumpTimes = 15;
        Movement moving = Movement.Standstill;
        Jumping jumping = Jumping.Standstill;

        public Player(double positionX, double positionY, string image)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.Image = image;
        }

        public double PositionX { get => positionX; set => positionX = value; }
        public double PositionY { get => positionY; set => positionY = value; }
        public string Image { get => image; set => image = value; }
        public double MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
        public double JumpSpeed { get => jumpSpeed; set => jumpSpeed = value; }
        public Movement Moving { set => moving = value; }
        public Jumping Jumping { get => jumping; set => jumping = value; }
        public double FallSpeed { get => fallSpeed; set => fallSpeed = value; }
        public void PlayerMove()
        {
            DispatcherTimer playerTick = new DispatcherTimer();
            playerTick.Tick += (o, e) => Move();
            playerTick.Interval = new TimeSpan(0, 0, 0, 0, 10);
            playerTick.Start();
        }
        public void Move()
        {
            switch (moving)
            {
                case Movement.Left:
                    positionX -= moveSpeed;
                    break;
                case Movement.Right:
                    positionX += moveSpeed;
                    break;
                case Movement.Standstill:
                    break;
            }

            switch (jumping)
            {
                case Jumping.Up:
                    if (playerJumpTimes > 1)
                    {
                        positionY += jumpSpeed ;
                        playerJumpTimes -= 1;
                    }
                    else
                    {
                        positionY += jumpSpeed;
                        playerJumpTimes -= 1;
                        jumping = Jumping.Down;
                    }
                    break;
                case Jumping.Down:
                    positionY -= fallSpeed;
                    break;
                case Jumping.Standstill:
                    playerJumpTimes = 10;
                    break;
            }
        }

        
    }
}
