using Paint.Enums;
using Paint.Model;

namespace Paint
{
    internal class Controller
    {
        public Controller(PictureBox Pic, float DefaultPenWidth)
        {
            // Создаем холст
            Bm = new Bitmap(Pic.Width, Pic.Height);
            Gr = Graphics.FromImage(Bm);

            // Заливаем холст белым цветом
            Gr.Clear(Color.White);

            // Присваиваем холст к PictureBox
            Pic.Image = Bm;

            Pens = new PenTool(DefaultPenWidth);
        }

        public Bitmap Bm { get; private set; }
        public Graphics Gr { get; private set; }

        public bool bPaint { get; private set; } = false;

        private Point StartPoint, EndPoint;

        public Tool CurrentTool { get; set; } = Tool.None;

        private PenTool Pens;
        private FigureTool Figures = new();

        // Начать рисование (MouseDown)
        public void BeginDrawing(Point MouseLocation)
        {
            // Включаем рисование
            bPaint = true;

            // Устанавливаем начальную точку, от которой будет рисование
            StartPoint = MouseLocation;
            EndPoint = StartPoint;

            // Присваиваем фигуре позицию StartPoint
            Figures.SetLocation(StartPoint);
        }

        // Рисовать, если росавание включено (MouseMove)
        public void Draw(PictureBox Pic, Point MouseLocation)
        {
            if (!bPaint)
            {
                return;
            }

            switch (CurrentTool)
            {
                case Tool.Pen:
                    PenTool.DrawLine(Gr, Pens.BasicPen, MouseLocation, ref StartPoint, ref EndPoint);

                    break;

                case Tool.Eraser:
                    PenTool.DrawLine(Gr, Pens.Eraser, MouseLocation, ref StartPoint, ref EndPoint);

                    break;

                // Рассчитываем новый размер фигуры, если выбрана одна из них
                case Tool.Ellipse:
                case Tool.Rectangle:
                case Tool.Line:
                    EndPoint = MouseLocation;
                    Figures.UpdateSize(EndPoint);

                    break;
            }

            Pic.Refresh();
        }

        // Закончить рисование (MouseUp)
        public void EndDrawing(PictureBox Pic, Point MouseLocation)
        {
            Figures.UpdateSize(EndPoint);
            
            if (CurrentTool == Tool.Fill)
            {
                Point FillStartPoint = FindPoint(Pic, MouseLocation);
                FillTool.FillPicture(Bm, FillStartPoint, Pens.BasicPen.Color);
            }
            else
            {
                // Рисуем фигуру, если выбран таков инструмент
                DrawFigure(Gr);
            }

            // Обновляем картинку
            Pic.Refresh();

            // Выключаем рисование
            bPaint = false;
        }

        // Пипетка для PictureBox
        public void PickColor(PictureBox ColorPicker, Panel PicColor, Point MouseLocation)
        {
            Point Pos = FindPoint(ColorPicker, MouseLocation);

            Color PickedColor = ((Bitmap)ColorPicker.Image).GetPixel(Pos.X, Pos.Y);
            SetColor(PicColor, PickedColor);
        }

        // Находит позицию PictureBox, на которую наведена мышка 
        private static Point FindPoint(PictureBox Pb, Point MousePos)
        {
            float PX = (float)Pb.Image.Width / Pb.Width;
            PX *= MousePos.X;

            float PY = (float)Pb.Image.Height / Pb.Height;
            PY *= MousePos.Y;

            return new Point((int)PX, (int)PY);
        }

        // Изменить цвет
        public void SetColor(Panel PicColor, Color NewColor)
        {
            PicColor.BackColor = NewColor;
            Pens.SetColor(NewColor);
        }

        // Нарисовать фигуру. Вызывать только в событии Paint, в ином случае, может быть непредвиденный результат
        public void DrawFigure(Graphics GrToDrawOn)
        {
            Figures.DrawFigure(GrToDrawOn, Pens.BasicPen, CurrentTool, StartPoint, EndPoint);
        }

        // Изменить размер кисти
        public void SetPenWidth(float NewWidth)
        {
            Pens.SetWidth(NewWidth);
        }

        // Очистить картинку
        public void ClearImage(PictureBox Pic)
        {
            Gr.Clear(Pic.BackColor);
            Pic.Image = Bm;
        }

        // Сохранить картинку
        public static void SaveImage(PictureBox Pic, SaveFileDialog SaveDialog)
        {
            SaveDialog.Filter = "JPG(*.JPG)|*.jpg";

            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                Pic.Image.Save(SaveDialog.FileName);
            }
        }
    }
}