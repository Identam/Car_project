using System.IO;
using System.Drawing;
using System.Reflection;

namespace Project_cars
{
   
    class Gen_crazy
    {
        public static int SPEED = 5;
        public static string fullPath2 = @"car1_red.png";
        public static void GorizontalLeftC()
        {

            var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPath = Path.Combine(appDir, fullPath2);

            Bitmap _tmpBitmap = new Bitmap(Image.FromFile(fullPath));

            if (!Engine.Cars.Exists(
                c =>
                    c.Y == Engine.Picture.Height / 2 - 8 && c.X - 80 <= 0))
            {
                Engine.CR_cars.Add(new Crazy_car(-30, Engine.Picture.Height / 2 - 8, SPEED, _tmpBitmap, new Vector(1, 0), 3,0));
            }
        }
        public static void GorizontalRightC()
        {
            var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPath = Path.Combine(appDir, fullPath2);
            Bitmap _tmpBitmap = new Bitmap(Image.FromFile(fullPath));
            _tmpBitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);

            if (!Engine.Cars.Exists(
                c =>
                    c.Y == Engine.Picture.Height / 2 - 48 && c.X + 80 >= Engine.Picture.Width))
            {
                Engine.CR_cars.Add(new Crazy_car(Engine.Picture.Width, Engine.Picture.Height / 2 - 48, SPEED, _tmpBitmap, new Vector(-1, 0), 1,0));
            }
        }

        public static void VerticalUpC()
        {

            var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPath = Path.Combine(appDir, fullPath2);
            Bitmap _tmpBitmap = new Bitmap(Image.FromFile(fullPath));
            _tmpBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);

            if (!Engine.Cars.Exists(
                c =>
                    c.X == Engine.Picture.Width / 2 - 48 && c.Y - 80 <= 0))
            {
                Engine.CR_cars.Add(new Crazy_car(Engine.Picture.Width / 2 - 48, -30, SPEED, _tmpBitmap, new Vector(0, 1), 0,0));
            }
        }

        public static void VerticalDownC()
        {
            var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPath = Path.Combine(appDir, fullPath2);
            Bitmap _tmpBitmap = new Bitmap(Image.FromFile(fullPath));
            _tmpBitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);

            if (!Engine.Cars.Exists(
                c =>
                    c.X == Engine.Picture.Width / 2 - 8 && c.Y + 80 >= Engine.Picture.Height))
            {
                Engine.CR_cars.Add(new Crazy_car(Engine.Picture.Width / 2 - 8, Engine.Picture.Height, SPEED, _tmpBitmap, new Vector(0, -1), 2,0));
            }
        }
    }
}
