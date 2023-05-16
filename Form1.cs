using Paint.Enums;

namespace Paint
{
    public partial class Form1 : Form
    {
        Controller FormController = new Controller();

        public Form1()
        {
            InitializeComponent();

            // ������� �����
            Bm = new Bitmap(Pic.Width, Pic.Height);
            Gr = Graphics.FromImage(Bm);

            // �������� ����� ����� ������
            Gr.Clear(Color.White);

            // ����������� ����� � PictureBox
            Pic.Image = Bm;

            // ������������� ������ �����
            BasicPen.Width = (float)NumericLineWitdth.Value;

            // ��������� ������ � ����� �����
            BasicPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            BasicPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            // ������������� ������ �������
            Eraser.Width = (float)NumericLineWitdth.Value;

            // ��������� ������ � ����� �������
            Eraser.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Eraser.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        Bitmap Bm;
        Graphics Gr;

        bool bPaint = false;

        Point StartPoint, EndPoint;

        Pen BasicPen = new Pen(Color.Black);
        Pen Eraser = new Pen(Color.White);

        Tool CurrentTool = Tool.None;

        Rectangle Rec = new();

        private void Pic_MouseDown(object Sender, MouseEventArgs E)
        {
            // �������� ���������
            bPaint = true;

            // ������������� ��������� �����, �� ������� ����� ���������
            StartPoint = E.Location;
            EndPoint = StartPoint;
            Rec.Location = StartPoint;
        }

        private void Pic_MouseMove(object Sender, MouseEventArgs E)
        {
            if (!bPaint)
            {
                return;
            }

            switch (CurrentTool)
            {
                case Tool.Pen:
                    // ������������� �������� �����, ���� ������ �����
                    EndPoint = E.Location;

                    // ������ ����� �� ��������� �� �������� �����
                    Gr.DrawLine(BasicPen, StartPoint, EndPoint);

                    // ������������� ��������� ����� � �����, ��� ��������� �����
                    StartPoint = EndPoint;

                    break;

                case Tool.Eraser:
                    // ������������� �������� �����, ���� ������ �����
                    EndPoint = E.Location;

                    // ������ ����� �� ��������� �� �������� �����
                    Gr.DrawLine(Eraser, StartPoint, EndPoint);

                    // ������������� ��������� ����� � �����, ��� ��������� �����
                    StartPoint = EndPoint;

                    break;

                case Tool.Ellipse:
                case Tool.Rectangle:
                case Tool.Line:
                    EndPoint = E.Location;

                    Rec.Width = EndPoint.X - Rec.Location.X;
                    Rec.Height = EndPoint.Y - Rec.Location.Y;

                    break;
            }

            Pic.Refresh();
        }

        private void Pic_MouseUp(object Sender, MouseEventArgs E)
        {
            // ��������� ���������
            bPaint = false;

            Rec.Width = EndPoint.X - Rec.Location.X;
            Rec.Height = EndPoint.Y - Rec.Location.Y;

            switch (CurrentTool)
            {
                // �������
                case Tool.Fill:
                    Point P = FindPoint(Pic, E.Location);
                    Fill(Bm, P, PicColor.BackColor);

                    break;

                // ��������� ��������� �������
                case Tool.Ellipse:
                    Gr.DrawEllipse(BasicPen, Rec);

                    break;

                // ��������� ��������� ��������������
                case Tool.Rectangle:
                    Gr.DrawRectangle(BasicPen,
                        Math.Min(Rec.Location.X, EndPoint.X),
                        Math.Min(Rec.Location.Y, EndPoint.Y),
                        Math.Abs(Rec.Width),
                        Math.Abs(Rec.Height));

                    break;

                // ��������� ��������� �����
                case Tool.Line:
                    Gr.DrawLine(BasicPen, StartPoint, EndPoint);

                    break;
            }

            // ��������� ��������
            Pic.Refresh();
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            ColorDialog1.ShowDialog();
            PicColor.BackColor = ColorDialog1.Color;
            BasicPen.Color = ColorDialog1.Color;
        }

        private void BtnFill_Click(object Sender, EventArgs E)
        {
            CurrentTool = Tool.Fill;
        }

        private void BtnPencil_Click(object Sender, EventArgs E)
        {
            CurrentTool = Tool.Pen;
        }

        private void BtnEraser_Click(object Sender, EventArgs E)
        {
            CurrentTool = Tool.Eraser;
        }

        private void BtnEllipse_Click(object Sender, EventArgs E)
        {
            CurrentTool = Tool.Ellipse;
        }

        private void BtnRect_Click(object Sender, EventArgs E)
        {
            CurrentTool = Tool.Rectangle;
        }

        private void BtnLine_Click(object sender, EventArgs e)
        {
            CurrentTool = Tool.Line;
        }

        private void NumericLineWitdth_ValueChanged(object Sender, EventArgs E)
        {
            BasicPen.Width = (float)NumericLineWitdth.Value;
            Eraser.Width = (float)NumericLineWitdth.Value;
        }

        private void BtnClear_Click(object Sender, EventArgs E)
        {
            Gr.Clear(Pic.BackColor);
            Pic.Image = Bm;
        }

        private void BtnSave_Click(object Sender, EventArgs E)
        {
            SaveFileDialog1.Filter = "JPG(*.JPG)|*.jpg";

            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Pic.Image.Save(SaveFileDialog1.FileName);
            }
        }

        private void Pic_Paint(object Sender, PaintEventArgs E)
        {
            if (!bPaint)
            {
                return;
            }

            Graphics GrTemp = E.Graphics;

            switch (CurrentTool)
            {
                case Tool.Ellipse:
                    GrTemp.DrawEllipse(BasicPen, Rec);

                    break;

                case Tool.Rectangle:
                    GrTemp.DrawRectangle(BasicPen,
                            Math.Min(Rec.Location.X, EndPoint.X),
                            Math.Min(Rec.Location.Y, EndPoint.Y),
                            Math.Abs(Rec.Width),
                            Math.Abs(Rec.Height));

                    break;

                case Tool.Line:
                    GrTemp.DrawLine(BasicPen, StartPoint, EndPoint);

                    break;
            }
        }

        // ������� ������� PictureBox �� ������� �������� ����� 
        private Point FindPoint(PictureBox PB, Point MousePos)
        {
            float PX = (float)PB.Image.Width / PB.Width;
            PX *= MousePos.X;

            float PY = (float)PB.Image.Height / PB.Height;
            PY *= MousePos.Y;

            return new Point((int)PX, (int)PY);
        }

        private void ColorPicker_MouseClick(object Sender, MouseEventArgs E)
        {
            Point Pos = FindPoint(ColorPicker, E.Location);

            PicColor.BackColor = ((Bitmap)ColorPicker.Image).GetPixel(Pos.X, Pos.Y);
            BasicPen.Color = PicColor.BackColor;
        }

        private void Validate(Bitmap Bm, Stack<Point> PointsStack, int X, int Y, Color OldColor, Color NewColor)
        {
            Color PixelColor = Bm.GetPixel(X, Y);

            if (PixelColor == OldColor)
            {
                PointsStack.Push(new Point(X, Y));
                Bm.SetPixel(X, Y, NewColor);
            }
        }

        public void Fill(Bitmap Bm, Point FillStartPoint, Color NewColor)
        {
            // ���������� ������� ���� �������
            Color OldColor = Bm.GetPixel(FillStartPoint.X, FillStartPoint.Y);

            // ������� ���� �������� � ��������� � ���� �������, � �������� �������� �������
            Stack<Point> Pixels = new Stack<Point>();
            Pixels.Push(FillStartPoint);

            // ������� �� ������ ��������, ���� ������� ��� ������ ��������� ������
            if (OldColor == NewColor)
            {
                return;
            }

            // �������� ��� �������� �������, �� ��� ���, ���� ��������� ����� ��������� ������� ��� ������� �� ��������� �������
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
    }
}