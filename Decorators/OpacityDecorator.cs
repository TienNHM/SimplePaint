using Paint.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Decorators
{
    public class OpacityDecorator : ShapeDecorator
    {
        private int alpha; // 0 (hoàn toàn trong suốt) đến 255 (đục hoàn toàn)

        public OpacityDecorator(ShapeComponent shape, int alpha)
            : base(shape)
        {
            this.alpha = Math.Max(0, Math.Min(255, alpha)); // Giới hạn alpha trong 0–255
        }

        public override void Draw(Graphics gp)
        {
            // Tạo pen và brush mới với độ trong suốt
            using (Pen transparentPen = (Pen)shape.Pen.Clone())
            {
                transparentPen.Color = Color.FromArgb(alpha, shape.Pen.Color);

                Brush transparentBrush = null;
                if (shape.Brush is SolidBrush solid)
                {
                    transparentBrush = new SolidBrush(Color.FromArgb(alpha, solid.Color));
                }
                else
                {
                    transparentBrush = shape.Brush; // fallback nếu không phải SolidBrush
                }

                // Tạm thời thay đổi pen và brush
                var originalPen = shape.Pen;
                var originalBrush = shape.Brush;

                shape.Pen = transparentPen;
                shape.Brush = transparentBrush;

                base.Draw(gp); // gọi hàm vẽ gốc

                // Khôi phục lại
                shape.Pen = originalPen;
                shape.Brush = originalBrush;

                transparentBrush?.Dispose();
            }
        }
    }
}
