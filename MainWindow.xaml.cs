using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace PlatFormer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Player player = new Player(450, 100, "");
        internal List<Platform> mainList = new List<Platform>();
        public Collision collision = new Collision(); 
        public MainWindow()
        {
            InitializeComponent();
            CreatePlayer(player);
            player.PlayerMove();
            TickMethodGraphic();
        }
        
        public void TickMethodGraphic()
        {
            DispatcherTimer graphics = new DispatcherTimer();
            graphics.Tick += (o, e) => GraphicsUpdateForTimer();
            graphics.Interval = new TimeSpan(0, 0, 0, 0, 5);
            graphics.Start();
        }
        public void GraphicsUpdateForTimer()
        {
            FallingGraphics();
            CollisionDetection();
            FallDetection();
        }
        public void FallingGraphics()
        {
            RectPlayer.SetValue(Canvas.BottomProperty, player.PositionY);
            RectPlayer.SetValue(Canvas.LeftProperty, player.PositionX);
            RectPlayer.UpdateLayout();
        }
        void CreatePlayer(Player player)
        {
            
            RectPlayer.SetValue(Canvas.LeftProperty, player.PositionX);
            RectPlayer.SetValue(Canvas.BottomProperty, player.PositionY);
        }
        public void CollisionDetection()
        {
            double playerY = Canvas.GetBottom(RectPlayer);
            double playerX = Canvas.GetLeft(RectPlayer);
            mainList = CreatePlatformsList(mainList);
            collision.CollisionListCheck(mainList, new Rect(playerX, playerY, RectPlayer.Width, RectPlayer.Height), player);
        }
        internal List<Platform> CreatePlatformsList(List<Platform> list)
        {
            double playerY = Canvas.GetBottom(RectPlayer);
            double playerX = Canvas.GetLeft(RectPlayer);
            Platform newplatform = new Platform(Canvas.GetLeft(RectPlatform), Canvas.GetBottom(RectPlatform), RectPlatform.Width, RectPlatform.Height);
            Platform newplatform1 = new Platform(Canvas.GetLeft(RectPlatform1), Canvas.GetBottom(RectPlatform1), RectPlatform1.Width, RectPlatform1.Height);
            Platform newplatform2 = new Platform(Canvas.GetLeft(RectPlatform2), Canvas.GetBottom(RectPlatform2), RectPlatform2.Width, RectPlatform2.Height);
            list.Add(newplatform);
            list.Add(newplatform1);
            list.Add(newplatform2);
            return list;

        }
        
        public void FallDetection()
        {
            double playerY = Canvas.GetBottom(RectPlayer);
            double playerX = Canvas.GetLeft(RectPlayer);

            double bottomLineY = Canvas.GetBottom(bottomLine);
            double bottomLineX = Canvas.GetLeft(bottomLine);

            Collision.FellOff(new Rect(playerX, playerY, RectPlayer.Width, RectPlayer.Height), new Rect(bottomLineX, bottomLineY, RectPlatform.Width, RectPlatform.Height), player);
        }
        public async void MoveMethod(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && player.Jumping != Jumping.Down)
            {
                if (player.Jumping == Jumping.Up)
                {

                }
                else
                {
                    player.Jumping = Jumping.Up;
                }
            }
            while(Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right))
            {
                player.Moving = Movement.Right;
                await Task.Delay(5);
            }
            while (Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left))
            {
                player.Moving = Movement.Left;
                await Task.Delay(5);
            }

        }
        private void StopMovement(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.A || e.Key == Key.Left)
            {
                player.Moving = Movement.Standstill;
            }
            else if (e.Key == Key.D || e.Key == Key.Right)
            {
                player.Moving = Movement.Standstill;
            }   
            
        }
        public List<double> PlatformLocation()
        {
            Random random = new Random();
            random.Next(50, 850);

            Random random1 = new Random();
            random1.Next(50, 850);

            List<double> locationList = new List<double>();

            locationList.Add(Convert.ToDouble(random));
            locationList.Add(Convert.ToDouble(random1));

            return locationList;
        }
        public List<double> PlayerLocation()
        {
            List<double> playerLocation = new List<double>();
            playerLocation.Add(player.PositionX);
            playerLocation.Add(player.PositionY);
            return playerLocation;
        }

        public double PlatformSize()
        {
            double platformSize;
            Random random = new Random();
            random.Next(100, 300);

            platformSize = Convert.ToDouble(random);

            return platformSize;
        }

        public List<double> PlatformCenter(Platform platform)
        {
            double centerX = platform.PositionX + (platform.Lenght / 2);
            double centerY = platform.PositionY + (platform.Height / 2);
            List<double> center = new List<double>();
            center.Add(centerX);
            center.Add(centerY);

            return center;
        }

        public void PlatformReachCheck()
        {
            List<double> list = PlatformLocation();
            double playerReach = player.MoveSpeed * player.JumpSpeed / (player.FallSpeed / 2);
            List<double> playerLocation = PlayerLocation();

            bool ReachCheck;
        }
        
    }
}
