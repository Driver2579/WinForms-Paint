using Paint.Enums;

namespace Paint.Model
{
    internal class FigureTool
    {
        private Rectangle Rec = new();

        public void SetLocation(Point NewLocation)
        {
            Rec.Location = NewLocation;
        }

        public void UpdateSize(Point EndPoint)
        {
            Rec.Width = EndPoint.X - Rec.Location.X;
            Rec.Height = EndPoint.Y - Rec.Location.Y;
        }

        public void DrawFigure(Graphics GrToDrawOn, Pen PenToDrawWith, Tool CurrentTool, Point StartPoint, Point EndPoint)
        {
            switch (CurrentTool)
            {
                case Tool.Ellipse:
                    GrToDrawOn.DrawEllipse(PenToDrawWith, Rec);

                    break;

                case Tool.Rectangle:
                    GrToDrawOn.DrawRectangle(PenToDrawWith,
                            Math.Min(Rec.Location.X, EndPoint.X),
                            Math.Min(Rec.Location.Y, EndPoint.Y),
                            Math.Abs(Rec.Width),
                            Math.Abs(Rec.Height));

                    break;

                case Tool.Line:
                    GrToDrawOn.DrawLine(PenToDrawWith, StartPoint, EndPoint);

                    break;
            }
        }
    }
}
