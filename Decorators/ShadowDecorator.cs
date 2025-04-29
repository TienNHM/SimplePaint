using Paint.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Decorators
{
    public class ShadowDecorator : ShapeDecorator
    {
        private int offsetX;
        private int offsetY;
        private Color shadowColor;

        public ShadowDecorator(ShapeComponent shape, int offsetX = 5, int offsetY = 5, Color? color = null)
            : base(shape)
        {
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            this.shadowColor = color ?? Color.FromArgb(100, Color.Black); // màu đen trong suốt
        }

        public override void Draw(Graphics gp)
        {
            if (shape.GPPaths != null && shape.GPPaths.PointCount > 0)
            {
                using (Matrix m = new Matrix())
                {
                    m.Translate(offsetX, offsetY);
                    GraphicsPath shadowPath = (GraphicsPath)shape.GPPaths.Clone();
                    shadowPath.Transform(m);

                    using (Brush shadowBrush = new SolidBrush(shadowColor))
                    {
                        gp.FillPath(shadowBrush, shadowPath);
                    }
                }
            }
            else
            {
                // Với các shape không có path như MyLine, vẽ lại đường lệch xuống
                Point p1 = new Point(shape.P1.X + offsetX, shape.P1.Y + offsetY);
                Point p2 = new Point(shape.P2.X + offsetX, shape.P2.Y + offsetY);

                using (Pen shadowPen = new Pen(shadowColor, shape.Pen.Width))
                {
                    shadowPen.StartCap = shadowPen.EndCap = shape.Pen.StartCap;
                    gp.DrawLine(shadowPen, p1, p2);
                }
            }

            // Sau khi vẽ bóng, vẽ lại shape gốc
            base.Draw(gp);
        }
    }
}
