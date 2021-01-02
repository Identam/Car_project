using System.IO;
using System.Drawing;
using System.Reflection;

namespace Project_cars
{
    class Generate
    {
        public static int SPEED = 1;
        public static string fullPath2 = @"car2_green.png";
        public static void GorizontalLeft()
        {

            var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPath = Path.Combine(appDir, fullPath2);

            Bitmap _tmpBitmap = new Bitmap(Image.FromFile(fullPath));

            if (!Engine.Cars.Exists(
                c =>
                    c.Y == Engine.Picture.Height / 2 - 8  && c.X - 80 <= 0))
            {//Engine.Cars.Add(new Car(-30, Engine.Picture.Height / 2 - 8 , SPEED, _tmpBitmap, new Vector(1, 0), 3, 1));
                Engine.Cars.Add(new Car(-30, Engine.Picture.Height / 2 - 8 , SPEED, _tmpBitmap, new Vector(1, 0), 3, 1,0));
            }
                    
        }   
        public static void GorizontalRight()
        {
            var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPath = Path.Combine(appDir, fullPath2);
            Bitmap _tmpBitmap = new Bitmap(Image.FromFile(fullPath));
            _tmpBitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);

            if (!Engine.Cars.Exists(
                c =>
                    c.Y == Engine.Picture.Height / 2 - 48 && c.X + 80 >= Engine.Picture.Width))
            {//Engine.Cars.Add(new Car(Engine.Picture.Width , Engine.Picture.Height / 2 - 48, SPEED, _tmpBitmap, new Vector(-1, 0), 1,1));
                Engine.Cars.Add(new Car(Engine.Picture.Width , Engine.Picture.Height / 2 - 48, SPEED, _tmpBitmap, new Vector(-1, 0), 1,1,0));
            }

        }
        public static void VerticalUp()
        {
            var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPath = Path.Combine(appDir, fullPath2);
            Bitmap _tmpBitmap = new Bitmap(Image.FromFile(fullPath));
            _tmpBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);

            if (!Engine.Cars.Exists(
                c =>
                    c.X == Engine.Picture.Width / 2 - 48 && c.Y - 80 <= 0))
            {
                Engine.Cars.Add(new Car(Engine.Picture.Width / 2 - 48 , -30 , SPEED, _tmpBitmap, new Vector(0, 1), 0,1,0));
            }
        }

        public static void VerticalDown()
        {
            var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPath = Path.Combine(appDir, fullPath2);
            Bitmap _tmpBitmap = new Bitmap(Image.FromFile(fullPath));
            _tmpBitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);

            if (!Engine.Cars.Exists(
                c =>
                    c.X == Engine.Picture.Width / 2 - 8 && c.Y + 80 >= Engine.Picture.Height))
            {//Engine.Cars.Add(new Car(Engine.Picture.Width / 2 - 8, Engine.Picture.Height , SPEED, _tmpBitmap, new Vector(0, -1), 2,1));
                Engine.Cars.Add(new Car(Engine.Picture.Width / 2 - 8, Engine.Picture.Height , SPEED, _tmpBitmap, new Vector(0, -1), 2,1,0));
            }
        }
    }
}

