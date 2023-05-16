namespace Paint.Model
{
    internal class FillTool
    {
        public static void FillPicture(Bitmap Bm, Point FillStartPoint, Color NewColor)
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
    }
}
