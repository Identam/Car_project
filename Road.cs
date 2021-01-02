using System.Drawing;
using System.Windows.Forms;

namespace Project_cars
{
    class Road
    {
        private Pen _myPen;
        public delegate void On_Cros(int a);
        static public event On_Cros on_cros;

        public void RenderRoad(PictureBox p, Graphics e)
        {
            _myPen = new Pen(Color.FromArgb(64, 64, 64), 1);
            _myPen.Width = 40;

            e.DrawLine(_myPen, p.Width / 2 - _myPen.Width / 2, 0, p.Width / 2 - _myPen.Width / 2, p.Height);
            e.DrawLine(_myPen, p.Width / 2 + _myPen.Width / 2, 0, p.Width / 2 + _myPen.Width / 2, p.Height);
            e.DrawLine(_myPen, 0, p.Height / 2 - _myPen.Width / 2, p.Width, p.Height / 2 - _myPen.Width / 2);
            e.DrawLine(_myPen, 0, p.Height / 2 + _myPen.Width / 2, p.Width, p.Height / 2 + _myPen.Width / 2);

            _myPen.Color = Color.White;
            _myPen.Width = 2;

            e.DrawLine(_myPen, p.Width / 2, 0, p.Width / 2, p.Height / 2 - 40); //12:00 
            e.DrawLine(_myPen, p.Width / 2, p.Height / 2 + 40, p.Width / 2, p.Height); //6:00
            e.DrawLine(_myPen, 0, p.Height / 2, p.Width / 2 - 40, p.Height / 2); //9:00
            e.DrawLine(_myPen, p.Width / 2 + 40, p.Height / 2, p.Width, p.Height / 2);//3:00
        }

        public static void OnCrossRoad(Crazy_car car)
        {
            switch (car.SIDE)
            {
                case 0:
                    // верхние
                    if (Engine.Cars.Exists(cr => cr.SIDE == 1 && cr.X < Engine.Picture.Width / 2 + 40 && cr.X > Engine.Picture.Width / 2 - 80) || 
                        Engine.Cars.Exists(cr => cr.SIDE == 3 && cr.X < Engine.Picture.Width / 2+60 && cr.X > Engine.Picture.Width / 2-50) || 
                        Engine.CR_cars.Exists(cr => cr.SIDE == 1 && cr.X < Engine.Picture.Width / 2 + 180 && cr.X > Engine.Picture.Width / 2 - 80) || 
                        Engine.CR_cars.Exists(cr => cr.SIDE == 3 && cr.X < Engine.Picture.Width / 2+60 && cr.X > Engine.Picture.Width / 2 - 70))
                        on_cros?.Invoke(1);
                    else
                        on_cros?.Invoke(0);
                    break;

                case 1:
                    // Правые
                    if (Engine.Cars.Exists(cr => cr.SIDE == 0 && cr.Y < Engine.Picture.Height / 2 && cr.Y > Engine.Picture.Height / 2 - 100) || 
                        Engine.Cars.Exists(cr => cr.SIDE == 2 && cr.Y > Engine.Picture.Height / 2 - 90 && cr.Y < Engine.Picture.Height / 2 +30) ||
                        Engine.CR_cars.Exists(cr => cr.SIDE == 0 && cr.Y < Engine.Picture.Height / 2 && cr.Y > Engine.Picture.Height / 2 - 100) ||
                        Engine.CR_cars.Exists(cr => cr.SIDE == 2 && cr.Y > Engine.Picture.Height / 2 - 90 && cr.Y < Engine.Picture.Height / 2 +60))
                        on_cros?.Invoke(1);
                    else
                        on_cros?.Invoke(0);
                    break;

                case 2:
                    // нижние
                    if (Engine.Cars.Exists(cr => cr.SIDE == 1 && cr.X > Engine.Picture.Width / 2 - 5 && cr.X < Engine.Picture.Width / 2 + 40) || 
                        Engine.Cars.Exists(cr => cr.SIDE == 3 && cr.X > Engine.Picture.Width / 2 - 100 && cr.X < Engine.Picture.Width / 2 + 30) ||
                        Engine.CR_cars.Exists(cr => cr.SIDE == 1 && cr.X > Engine.Picture.Width / 2 - 5 && cr.X < Engine.Picture.Width / 2 + 40) ||
                        Engine.CR_cars.Exists(cr => cr.SIDE == 3 && cr.X > Engine.Picture.Width / 2 - 120 && cr.X < Engine.Picture.Width / 2 + 30))
                        on_cros?.Invoke(1);
                    else
                        on_cros?.Invoke(0);
                    break;

                case 3:
                    // леваки
                    if (Engine.Cars.Exists(cr => cr.SIDE == 0 && cr.Y > Engine.Picture.Height / 2 - 90 && cr.Y < Engine.Picture.Height / 2 + 20) || 
                        Engine.Cars.Exists(cr => cr.SIDE == 2 && cr.Y > Engine.Picture.Height / 2 - 40 && cr.Y < Engine.Picture.Height / 2) ||
                        Engine.CR_cars.Exists(cr => cr.SIDE == 0 && cr.Y > Engine.Picture.Height / 2 - 110 && cr.Y < Engine.Picture.Height / 2+20) ||
                        Engine.CR_cars.Exists(cr => cr.SIDE == 2 && cr.Y > Engine.Picture.Height / 2 - 40 && cr.Y < Engine.Picture.Height / 2))
                        on_cros?.Invoke(1);
                    else
                        on_cros?.Invoke(0);
                    break;
            }
        }
    }
}
