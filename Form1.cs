namespace Paint
{
    enum Tool
    {
        None,
        Fill,
        Pen,
        Eraser,
        Ellipse,
        Rectangle,
        Line
    }

    public partial class Form1 : Form
    {
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
                case Tool.Ellipse:
                    Gr.DrawEllipse(BasicPen, Rec);

                    break;

                case Tool.Rectangle:
                    Gr.DrawRectangle(BasicPen,
                        Math.Min(Rec.Location.X, EndPoint.X),
                        Math.Min(Rec.Location.Y, EndPoint.Y),
                        Math.Abs(Rec.Width),
                        Math.Abs(Rec.Height));

                    break;

                case Tool.Line:
                    Gr.DrawLine(BasicPen, StartPoint, EndPoint);

                    break;
            }

            Pic.Refresh();
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
    }
}