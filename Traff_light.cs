using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Project_cars
{
    class Traff_light
    {
        public delegate void Light_change(int a);
        static public event Light_change Tr_c02; // для верхних и нижних машин
        static public event Light_change Tr_c13; // для боковых машин

        public Point Place { get; set; }
        public Lights CurrLight { get; set; }
        public int CurrInterval { get; set; }
        public int SIDE { get; set; }
        public Traff_light(Point pl, Lights lights, int interval, int side)
        {
            Place = pl;
            CurrLight = lights;
            CurrInterval = interval;
            SIDE = side;
        }
        public enum Lights
        {
            Red, Green
        }

        public static void CreateLight()
        {
            Engine.TrafficLights.Add(new Traff_light(new Point(Engine.Picture.Width / 2 - 75, Engine.Picture.Height / 2 - 75), Lights.Green,
            Engine.LightsInterval1, 0)); //левый верхний
            Engine.TrafficLights.Add(new Traff_light(new Point(Engine.Picture.Width / 2 + 45, Engine.Picture.Height / 2 - 75), Lights.Red,
            Engine.LightsInterval1, 1)); // правый верхний
            Engine.TrafficLights.Add(new Traff_light(new Point(Engine.Picture.Width / 2 - 75, Engine.Picture.Height / 2 + 45), Lights.Red,
            Engine.LightsInterval1, 3));
            Engine.TrafficLights.Add(new Traff_light(new Point(Engine.Picture.Width / 2 + 45, Engine.Picture.Height / 2 + 45), Lights.Green,
            Engine.LightsInterval1, 2));
        }
        public static void SwitchLight()
        {
            foreach (var light in Engine.TrafficLights)
            {
                switch (light.CurrLight)
                {
                    case Lights.Red:
                        Engine.LightsTimer.Interval = 3000;
                        light.CurrLight = Lights.Green;
                        break;
                    case Lights.Green:
                        Engine.LightsTimer.Interval = 3000;
                        light.CurrLight = Lights.Red;
                        break;
                }
            }
        }

        public static void RenderLight(Traff_light tl, PictureBox p, Graphics e)
        {
            var appDirR = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPath1 = @"Red.bmp";
            var fullPathR = Path.Combine(appDirR, fullPath1);
            var appDirG = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPath2 = @"Green.bmp";
            var fullPathG = Path.Combine(appDirG, fullPath2);

            Bitmap _tmpBitmapG = new Bitmap(Image.FromFile(fullPathG));
            Bitmap _tmpBitmapR = new Bitmap(Image.FromFile(fullPathR));


            switch (tl.CurrLight)
            {
                case Lights.Red:
                    e.DrawImage(_tmpBitmapR, tl.Place);
                    if (tl.SIDE == 0)
                    {
                        Tr_c02?.Invoke(0);
                        Tr_c13?.Invoke(1);
                    }
                    break;
                case Lights.Green:
                    e.DrawImage(_tmpBitmapG, tl.Place);
                    if (tl.SIDE == 0)
                    {
                        Tr_c02?.Invoke(1);
                        Tr_c13?.Invoke(0);
                    }
                    break;
            }

        }
    }
}
