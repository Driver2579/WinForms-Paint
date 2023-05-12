namespace Paint
{
    enum Tool
    {
        T_None,
        T_Pen,
        T_Eraser
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

        Point P1, P2;

        Pen BasicPen = new Pen(Color.Black);
        Pen Eraser = new Pen(Color.White);

        Tool CurrentTool = Tool.T_None;

        private void Pic_MouseDown(object Sender, MouseEventArgs E)
        {
            // �������� ���������
            bPaint = true;

            // ������������� ��������� �����, �� ������� ������ �����
            P1 = E.Location;
        }

        private void Pic_MouseMove(object Sender, MouseEventArgs E)
        {
            if (!bPaint)
            {
                return;
            }

            switch (CurrentTool)
            {
                case Tool.T_Pen:
                    // ������������� �������� �����, ���� ������ �����
                    P2 = E.Location;

                    // ������ ����� �� ��������� �� �������� �����
                    Gr.DrawLine(BasicPen, P1, P2);

                    // ������������� ��������� ����� � �����, ��� ��������� �����
                    P1 = P2;

                    break;

                case Tool.T_Eraser:
                    // ������������� �������� �����, ���� ������ �����
                    P2 = E.Location;

                    // ������ ����� �� ��������� �� �������� �����
                    Gr.DrawLine(Eraser, P1, P2);

                    // ������������� ��������� ����� � �����, ��� ��������� �����
                    P1 = P2;

                    break;
            }

            Pic.Refresh();
        }

        private void Pic_MouseUp(object Sender, MouseEventArgs E)
        {
            bPaint = false;
        }

        private void BtnPencil_Click(object Sender, EventArgs E)
        {
            CurrentTool = Tool.T_Pen;
        }

        private void BtnEraser_Click(object Sender, EventArgs E)
        {
            CurrentTool = Tool.T_Eraser;
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
    }
}