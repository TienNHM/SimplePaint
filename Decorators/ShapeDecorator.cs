using Paint.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Decorators
{
    public abstract class ShapeDecorator : ShapeComponent
    {
        protected ShapeComponent shape;

        public ShapeDecorator(ShapeComponent shape) : base(shape.Pen, shape.Brush)
        {
            this.shape = shape;
        }

        public override void Draw(Graphics gp)
        {
            shape.Draw(gp);
        }

        public override void AddPoint(Point p)
        {
            shape.AddPoint(p);
        }

        public override void Zoom(Point firstPoint, Point eLocation)
        {
            shape.Zoom(firstPoint, eLocation);
        }

        public override void SelectPoint(Point eLocation)
        {
            shape.SelectPoint(eLocation);
        }

        public override void Move(Point firstPoint, Point eLocation)
        {
            shape.Move(firstPoint, eLocation);
        }
    }
}
