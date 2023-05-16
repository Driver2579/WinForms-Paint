using System.Net;

namespace Paint.Model
{
    internal class PenTool
    {
        public PenTool(float DefaultPenWidth)
        {
            // Устанавливаем ширину кисти
            BasicPen.Width = DefaultPenWidth;

            // Скругляем начало и конец кисти
            BasicPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            BasicPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            // Устанавливаем ширину ластика
            Eraser.Width = DefaultPenWidth;

            // Скругляем начало и конец ластика
            Eraser.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Eraser.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        public Pen BasicPen { get; set; } = new Pen(Color.Black);
        public Pen Eraser { get; set; } = new Pen(Color.White);

        public static void DrawLine(Graphics Gr, Pen PenToDrawWith, Point MouseLocation, ref Point StartPoint, ref Point EndPoint)
        {
            // Устанавливаем конечную точку, куда пойдет линия
            EndPoint = MouseLocation;

            // Рисуем линию от начальной до конечной точки
            Gr.DrawLine(PenToDrawWith, StartPoint, EndPoint);

            // Устанавливаем начальную точку в место, где находится мышка
            StartPoint = EndPoint;
        }

        public void SetColor(Color NewColor)
        {
            BasicPen.Color = NewColor;
        }

        public void SetWidth(float NewWidth)
        {
            BasicPen.Width = NewWidth;
            Eraser.Width = NewWidth;
        }
    }
}