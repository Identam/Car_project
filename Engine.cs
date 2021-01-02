using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Timer = System.Windows.Forms.Timer;
using System;



namespace Project_cars
{
    class Engine
    {
        public static List<Crazy_car> CR_cars { get; set; }
        public static List<Car> Cars { get; set; }
        public static List<Crazy_car> Deleter { get; set; }
        public static PictureBox Picture { get; set; }
        public static Graphics Graph { get; set; }
        public static Road road = new Road();
        public static Timer MoveTimer { get; set; }
        public static List<Traff_light> TrafficLights { get; set; }
        public static int LightsInterval1 { get; set; }
        public static Timer LightsTimer { get; set; }
        public static Random R { get; set; }
        public static Timer GenCarTimer { get; set; }
        public static int ver;


        public static void Initialization()
        {
            Cars = new List<Car>();
            CR_cars = new List<Crazy_car>();
            TrafficLights = new List<Traff_light>();
            MoveTimer = new Timer { Interval = 10 };        
            MoveTimer.Tick += (sender, e) => Update();
            LightsInterval1 = 30;
            LightsTimer = new Timer { Interval = LightsInterval1 };
            Traff_light.CreateLight();
            LightsTimer.Tick += (sender, e) => Traff_light.SwitchLight();
            R = new Random();
            GenCarTimer = new Timer { Interval = 1000 };
            GenCarTimer.Tick += (sender, e) => GenerateCar_Tick();
            Deleter = new List<Crazy_car>();
        }
        public static void Start()
        {            
            MoveTimer.Start();
            LightsTimer.Start();
            GenCarTimer.Start();
        }
        public static void Pause()
        {
            MoveTimer.Stop();
            LightsTimer.Stop();
            GenCarTimer.Stop();
        }

        public static void Update()
        {
            foreach (var c in Cars)
            {
                // Тут у машин меняется знание о цвете светофора
                if (c.SIDE == 0 || c.SIDE == 2)
                    Traff_light.Tr_c02 += c.ChangeTraf;
                else
                    Traff_light.Tr_c13 += c.ChangeTraf;

                // Тут узнаем, какие машины на перекрестке
                Road.OnCrossRoad(c);
                Road.on_cros += c.ChangeCros;
                c.Check();
                c.Move();
                if (c.X < -50 || c.X > Picture.Width + 50 || c.Y < -50 || c.Y > Picture.Height + 50)
                {
                    Deleter.Add(c);
                }
            }
            foreach (var c in CR_cars)
            {
                Road.OnCrossRoad(c);
                Road.on_cros += c.ChangeCros;
                c.Check();
                c.Move();
            }
            if (Deleter.Count != 0)
            {
                foreach (Car car in Deleter)
                {
                    Cars.Remove(car);
                }
            }
            RenderMap();
            Picture.Invalidate();
            ver = R.Next(1, 6);
        }

        public static void RenderMap()
        {
            road.RenderRoad(Picture, Graph);
            foreach(Car c in Cars)
            {
                Graph.DrawImage(c.SPRITE, new Point(c.X, c.Y));
            }
            foreach (Crazy_car c in CR_cars)
            {
                Graph.DrawImage(c.SPRITE, new Point(c.X, c.Y));
            }
            foreach (var light in TrafficLights)
            {
                Traff_light.RenderLight(light, Picture, Graph);
            }
        }
        public static void GenerateCar_Tick()
        {
            if (ver == 5)
            {
                switch (R.Next(1, 5))
                {
                    case 1:
                        Gen_crazy.GorizontalLeftC();
                        break;
                    case 2:
                        Gen_crazy.GorizontalRightC();
                        break;
                    case 3:
                        Gen_crazy.VerticalDownC();
                        break;
                    case 4:
                        Gen_crazy.VerticalUpC();
                        break;
                }
            }
            else
            {
                switch (R.Next(1, 5))
                {
                    case 1:
                        Generate.GorizontalLeft();
                        break;
                    case 2:
                        Generate.GorizontalRight();
                        break;
                    case 3:
                        Generate.VerticalDown();
                        break;
                    case 4:
                        Generate.VerticalUp();
                        break;
                }
            }
        }
    }
}
