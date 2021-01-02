using System.Drawing;

namespace Project_cars
{    
    class Car : Crazy_car
    {
        public int TRAF_C { get; set; }
        public Car(int x, int y, int speed, Bitmap sprite, Vector dir, int side, int traf_c, int on_cros)
            : base(x, y, speed, sprite, dir, side, on_cros)
        {
            this.TRAF_C = traf_c;
        }
        // так машина узнаёт о светофоре
        public void ChangeTraf(int traf)
        {
            TRAF_C = traf;
        }
        public override void Check()
        {
            switch (this.SIDE)
            {
                case 0:
                    // верхние
                    if (this.Y > Engine.Picture.Height / 2 - 110 && this.Y < Engine.Picture.Height / 2 - 100 &&
                        ((Engine.Cars.Exists(cr => cr.on_cross == 1) || Engine.CR_cars.Exists(cr => cr.ON_CROSS == 1)) || this.TRAF_C == 0) ||
                        Engine.Cars.Exists(cr => cr.SIDE == 0 && (cr.Y - this.Y) < 70 && (this.Y - cr.Y) != 0 && (cr.Y - this.Y) > 0) ||
                        Engine.CR_cars.Exists(cr => cr.SIDE == 0 && (cr.Y - this.Y) < 70 && (this.Y - cr.Y) != 0 && (cr.Y - this.Y) > 0))
                        ChangeSpeed(0, this);
                    else
                        ChangeSpeed(1, this);
                    break;

                case 1:
                    // Правые
                    if (this.X > Engine.Picture.Width / 2 + 40 && this.X < Engine.Picture.Width / 2 + 50 && 
                        ((Engine.Cars.Exists(cr => cr.on_cross == 1) || Engine.CR_cars.Exists(cr => cr.ON_CROSS == 1)) || this.TRAF_C == 0) ||
                        Engine.Cars.Exists(cr =>cr.SIDE == 1 && (this.X - cr.X) < 70 && (this.X - cr.X) != 0 && (cr.X - this.X) < 0) ||
                        Engine.CR_cars.Exists(cr => cr.SIDE == 1 && (this.X - cr.X) < 70 && (this.X - cr.X) != 0 && (cr.X - this.X) < 0))
                        ChangeSpeed(0, this);
                    else
                        ChangeSpeed(1, this);
                    break;

                case 2:
                    // нижние
                    if (this.Y > Engine.Picture.Height / 2 + 30 && this.Y < Engine.Picture.Height / 2 + 40 && 
                        ((Engine.Cars.Exists(cr => cr.on_cross == 1) || Engine.CR_cars.Exists(cr => cr.ON_CROSS == 1)) || this.TRAF_C == 0) || 
                        Engine.Cars.Exists(cr =>cr.SIDE == 2 && (this.Y - cr.Y) < 60 && (this.Y - cr.Y) != 0 && (cr.Y - this.Y) < 0) ||
                        Engine.CR_cars.Exists(cr => cr.SIDE == 2 && (this.Y - cr.Y) < 60 && (this.Y - cr.Y) != 0 && (cr.Y - this.Y) < 0))
                        ChangeSpeed(0, this);
                    else
                        ChangeSpeed(1, this);
                    break;

                case 3:
                    // леваки
                    if (this.X > Engine.Picture.Width / 2 - 110 && this.X < Engine.Picture.Width / 2 - 100 && 
                        ((Engine.Cars.Exists(cr => cr.on_cross == 1) || Engine.CR_cars.Exists(cr => cr.ON_CROSS == 1)) || this.TRAF_C == 0) || 
                        Engine.Cars.Exists(cr =>cr.SIDE == 3 && (cr.X - this.X) < 70 && (cr.X - this.X) != 0 && (this.X - cr.X) < 0) ||
                        Engine.CR_cars.Exists(cr => cr.SIDE == 3 && (cr.X - this.X) < 70 && (cr.X - this.X) != 0 && (this.X - cr.X) < 0))
                        ChangeSpeed(0, this);
                    else
                        ChangeSpeed(1, this);
                    break;
            }
        }   
    }
}
