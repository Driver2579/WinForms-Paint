﻿using Paint.Enums;

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

        public Bitmap Bm { get; private set; }
        public Graphics Gr { get; private set; }

        public bool bPaint { get; private set; } = false;

        public Tool CurrentTool { get; set; } = Tool.None;

        private Point StartPoint, EndPoint;

        private Pen BasicPen = new Pen(Color.Black);
        private Pen Eraser = new Pen(Color.White);

        private Rectangle Rec = new();

        public void BeginDrawing(Point MouseLocation)
        {
            // Включаем рисование
            bPaint = true;

            // Устанавливаем начальную точку, от которой будет рисование
            StartPoint = MouseLocation;
            EndPoint = StartPoint;
            Rec.Location = StartPoint;
        }

        public void Draw(PictureBox Pic, Point MouseLocation)
        {
            if (!bPaint)
            {
                return;
            }

            switch (CurrentTool)
            {
                case Tool.Pen:
                    DrawLine(BasicPen, MouseLocation);

                    break;

                case Tool.Eraser:
                    DrawLine(Eraser, MouseLocation);

                    break;

                // Рассчитываем новый размер фигуры, если выбрана одна из них
                case Tool.Ellipse:
                case Tool.Rectangle:
                case Tool.Line:
                    EndPoint = MouseLocation;

                    Rec.Width = EndPoint.X - Rec.Location.X;
                    Rec.Height = EndPoint.Y - Rec.Location.Y;

                    break;
            }

            Pic.Refresh();
        }

        private void DrawLine(Pen PenToDrawWith, Point MouseLocation)
        {
            // Устанавливаем конечную точку, куда пойдет линия
            EndPoint = MouseLocation;

            // Рисуем линию от начальной до конечной точки
            Gr.DrawLine(PenToDrawWith, StartPoint, EndPoint);

            // Устанавливаем начальную точку в место, где находится мышка
            StartPoint = EndPoint;
        }

        public void EndDrawing(PictureBox Pic, Point MouseLocation)
        {
            Rec.Width = EndPoint.X - Rec.Location.X;
            Rec.Height = EndPoint.Y - Rec.Location.Y;
            
            if (CurrentTool == Tool.Fill)
            {
                Point FillStartPoint = FindPoint(Pic, MouseLocation);
                Fill(Bm, Pic, FillStartPoint, BasicPen.Color);
            }
            else
            {
                DrawFigure(Gr);

                // Обновляем картинку
                Pic.Refresh();
            }

            // Выключаем рисование
            bPaint = false;
        }

        public void DrawFigure(Graphics GrToDrawOn)
        {
            if (!bPaint)
            {
                return;
            }

            switch (CurrentTool)
            {
                case Tool.Ellipse:
                    GrToDrawOn.DrawEllipse(BasicPen, Rec);

                    break;

                case Tool.Rectangle:
                    GrToDrawOn.DrawRectangle(BasicPen,
                            Math.Min(Rec.Location.X, EndPoint.X),
                            Math.Min(Rec.Location.Y, EndPoint.Y),
                            Math.Abs(Rec.Width),
                            Math.Abs(Rec.Height));

                    break;

                case Tool.Line:
                    GrToDrawOn.DrawLine(BasicPen, StartPoint, EndPoint);

                    break;
            }
        }

        public void PickColor(PictureBox ColorPicker, Panel PicColor, Point MouseLocation)
        {
            Point Pos = FindPoint(ColorPicker, MouseLocation);

            Color PickedColor = ((Bitmap)ColorPicker.Image).GetPixel(Pos.X, Pos.Y);
            SetColor(PicColor, PickedColor);
        }

        public void SetColor(Panel PicColor, Color NewColor)
        {
            PicColor.BackColor = NewColor;
            BasicPen.Color = NewColor;
        }

        public void SetPenWidth(float NewWidth)
        {
            BasicPen.Width = NewWidth;
            Eraser.Width = NewWidth;
        }

        public void ClearImage(PictureBox Pic)
        {
            Gr.Clear(Pic.BackColor);
            Pic.Image = Bm;
        }

        public static void SaveImage(PictureBox Pic, SaveFileDialog SaveDialog)
        {
            SaveDialog.Filter = "JPG(*.JPG)|*.jpg";

            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                Pic.Image.Save(SaveDialog.FileName);
            }
        }

        // Находит позицию PictureBox на которую наведена мышка 
        private static Point FindPoint(PictureBox PB, Point MousePos)
        {
            float PX = (float)PB.Image.Width / PB.Width;
            PX *= MousePos.X;

            float PY = (float)PB.Image.Height / PB.Height;
            PY *= MousePos.Y;

            return new Point((int)PX, (int)PY);
        }

        private static void Validate(Bitmap Bm, Stack<Point> PointsStack, int X, int Y, Color OldColor, Color NewColor)
        {
            Color PixelColor = Bm.GetPixel(X, Y);

            if (PixelColor == OldColor)
            {
                PointsStack.Push(new Point(X, Y));
                Bm.SetPixel(X, Y, NewColor);
            }
        }

        public static void Fill(Bitmap Bm, PictureBox Pic, Point FillStartPoint, Color NewColor)
        {
            // Запоминаем текущий цвет пикселя
            Color OldColor = Bm.GetPixel(FillStartPoint.X, FillStartPoint.Y);

            // Создаем стэк пикселей и добавляем в него пиксель, с которого начнется заливка
            Stack<Point> Pixels = new();
            Pixels.Push(FillStartPoint);

            // Заливка не должна работать, если область уже залита выбранным цветом
            if (OldColor == NewColor)
            {
                return;
            }

            // Заливаем все соседние пиксели, до тех пор, пока валидация будет проходить успешно для каждого из соседнего пикселя
            while (Pixels.Count > 0)
            {
                Point P = Pixels.Pop();

                if (P.X > 0 && P.X < Bm.Width - 1 && P.Y > 0 && P.Y < Bm.Height - 1)
                {
                    Validate(Bm, Pixels, P.X - 1, P.Y, OldColor, NewColor);
                    Validate(Bm, Pixels, P.X, P.Y - 1, OldColor, NewColor);
                    Validate(Bm, Pixels, P.X + 1, P.Y, OldColor, NewColor);
                    Validate(Bm, Pixels, P.X, P.Y + 1, OldColor, NewColor);
                }
            }

            // Обновляем картинку
            Pic.Refresh();
        }
    }
}