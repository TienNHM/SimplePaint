using Paint.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Decorators
{
    public class FillColorDecorator : ShapeDecorator
    {
        private Color fillColor;

        public FillColorDecorator(ShapeComponent shape, Color color)
            : base(shape)
        {
            this.fillColor = color;
        }

        public override void Draw(Graphics gp)
        {
            // Fill nền trước (nếu có path)
            if (shape.GPPaths != null)
            {
                using (Brush fillBrush = new SolidBrush(fillColor))
                {
                    gp.FillPath(fillBrush, shape.GPPaths);
                }
            }

            base.Draw(gp); // sau đó vẽ lại shape gốc
        }
    }
}
