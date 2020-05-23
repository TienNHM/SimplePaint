using System.Drawing;
using System.Drawing.Drawing2D;

namespace Paint.Shapes
{
    public class MyArc : MyShapes
    {

        #region Properties
        public float StartAngle { get; set; }
        public float SweepAngle { get; set; }

        /// <summary>
        /// Dùng để xác định hình chữ nhật bao quanh đối tượng shape 
        /// </summary>
        public Rectangle RectShape { get; set; }
        #endregion

        public MyArc(Pen myPen, Brush myBrush, int startAngle, int sweepAngle) : base(myPen, myBrush)
        {
            StartAngle = startAngle;
            SweepAngle = sweepAngle;
        }

        public override void SelectPoint(Point eLocation)
        {
            SelectEdge(eLocation);
        }

        public override void Draw(Graphics gp)
        {
            try
            {
                RectShape = DetectBound();
                GPPaths.Reset();
                GPPaths.AddArc(RectShape, StartAngle, SweepAngle);
                gp.DrawArc(Pen, RectShape, StartAngle, SweepAngle);
                if (IsSelected)
                {
                    using (var pen = new Pen(Color.Blue) { Width = 2, DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
                    {
                        gp.DrawRectangle(pen, RectShape);
                    }
                }
            }
            catch { }
        }

        public override void AddPoint(Point p)
        {
            P2 = p;
        }

        public override void Zoom(Point firstPoint, Point eLocation)
        {
            ZoomEdge(firstPoint, eLocation);
        }

        public override void Move(Point firstPoint, Point eLocation)
        {
            MovePoint(firstPoint, eLocation);
        }

        public override void Update(bool Fill, bool isDrawBorder, Brush brush, int penWidth, DashStyle dashStyle, Color penColor, float startAngle = 0, float sweepAngle = 0)
        {
            base.Update(Fill, isDrawBorder, brush, penWidth, dashStyle, penColor);
            StartAngle = startAngle;
            SweepAngle = sweepAngle;
        }
    }
}