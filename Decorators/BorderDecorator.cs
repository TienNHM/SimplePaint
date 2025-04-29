using Paint.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Decorators
{
    public class BorderDecorator : ShapeDecorator
    {
        private Color borderColor;
        private float borderWidth;

        public BorderDecorator(ShapeComponent shape, Color color, float width)
            : base(shape)
        {
            this.borderColor = color;
            this.borderWidth = width;
        }

        public override void Draw(Graphics gp)
        {
            base.Draw(gp); // vẽ shape gốc

            if (shape.GPPaths != null)
            {
                using (Pen borderPen = new Pen(borderColor, borderWidth))
                {
                    gp.DrawPath(borderPen, shape.GPPaths);
                }
            }
        }
    }
}
