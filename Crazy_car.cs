using System.Drawing;

namespace Project_cars
{
    class Crazy_car
    {
        protected int x { get; set; }
        protected int y { get; set; }
        private int SPEED { get; set; }
        protected Vector DIRECTION { get; set; }
        protected Bitmap sprite { get; set; }
        protected int side { get; set; }
        protected int on_cross { get; set; }

        public Crazy_car(int x, int y, int speed, Bitmap sprite, Vector dir, int side, int on_cros)
        {
            this.X = x;
            this.Y = y;
            this.SPEED = speed;
            this.sprite = sprite;
            this.DIRECTION = dir;
            this.side = side; // 0 - up, 1 - right, 2 - down, 3 - left;
            this.on_cross = on_cros;
        }
        public int X
        {
            get
            {
                return x;
            }
            protected set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            protected set
            {
                y = value;
            }
        }
        public int SIDE
        {
            get
            {
                return side;
            }
            protected set
            {
                side = value;
            }
        }
        public int ON_CROSS
        {
            get
            {
                return on_cross;
            }
            protected set
            {
                on_cross = value;
            }
        }
        public Bitmap SPRITE
        {
            get
            {
                return sprite;
            }
            protected set
            {
                sprite = value;
            }
        }

        public static void ChangeSpeed(int speed, Crazy_car car)
        {
            car.SPEED = speed;
        }
        public void ChangeCros(int cros_r)
        {
            this.on_cross = cros_r;
        }
        public void Move()
        {
            this.Y += (int)DIRECTION.Y * SPEED;
            this.X += (int)DIRECTION.X * SPEED;
        }
        public virtual void Check()
        {
            switch (this.SIDE)
            {
                case 0:
                    // верхние
                    if (this.Y > Engine.Picture.Height / 2 - 110 && this.Y < Engine.Picture.Height / 2 - 100 && this.on_cross == 1 || 
                        Engine.Cars.Exists(cr => cr.SIDE == 0 && (cr.Y - this.Y) < 70 && (this.Y - cr.Y) != 0 && (cr.Y - this.Y) > 0) ||
                        Engine.CR_cars.Exists(cr => cr.SIDE == 0 && (cr.Y - this.Y) < 70 && (this.Y - cr.Y) != 0 && (cr.Y - this.Y) > 0))
                        this.SPEED = 0;
                    else
                        this.SPEED = 5;
                    break;

                case 1:
                    // Правые
                    if (this.X > Engine.Picture.Width / 2 + 40 && this.X < Engine.Picture.Width / 2 + 50 &&
                        (Engine.Cars.Exists(cr => cr.on_cross == 1) || Engine.CR_cars.Exists(cr => cr.on_cross == 1)) || 
                        Engine.Cars.Exists(cr =>cr.SIDE == 1 && (this.X - cr.X) < 70 && (this.X - cr.X) != 0 && (cr.X - this.X) < 0) ||
                        Engine.CR_cars.Exists(cr => cr.SIDE == 1 && (this.X - cr.X) < 70 && (this.X - cr.X) != 0 && (cr.X - this.X) < 0))
                        this.SPEED = 0;
                    else
                        this.SPEED = 5;
                    break;

                case 2:
                    // нижние
                    if (this.Y > Engine.Picture.Height / 2 + 50 && this.Y < Engine.Picture.Height / 2 + 60 && this.on_cross == 1 || 
                        Engine.Cars.Exists(cr =>cr.SIDE == 2 && (this.Y - cr.Y) < 70 && (this.Y - cr.Y) != 0 && (cr.Y - this.Y) < 0) ||
                        Engine.CR_cars.Exists(cr => cr.SIDE == 2 && (this.Y - cr.Y) < 70 && (this.Y - cr.Y) != 0 && (cr.Y - this.Y) < 0))
                        this.SPEED = 0;
                    else
                        this.SPEED = 5;
                    break;

                case 3:
                    // леваки
                    if (this.X > Engine.Picture.Width / 2 - 110 && this.X < Engine.Picture.Width / 2 - 100 && this.on_cross == 1 || 
                        Engine.Cars.Exists(cr =>cr.SIDE == 3 && (cr.X - this.X) < 70 && (cr.X - this.X) != 0 && (this.X - cr.X) < 0) ||
                        Engine.CR_cars.Exists(cr => cr.SIDE == 3 && (cr.X - this.X) < 70 && (cr.X - this.X) != 0 && (this.X - cr.X) < 0))
                        this.SPEED = 0;
                    else
                        this.SPEED = 5;
                    break;
            }
        }
    }
}
