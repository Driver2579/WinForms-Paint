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

            Bm = new Bitmap(Pic.Width, Pic.Height);
            Gr = Graphics.FromImage(Bm);
            Gr.Clear(Color.White);
            Pic.Image = Bm;

            BasicPen.Width = (float)NumericLineWitdth.Value;
            Eraser.Width = (float)NumericLineWitdth.Value;
        }

        Bitmap Bm;
        Graphics Gr;

        bool bPaint = false;

        Point Px, Py;

        Pen BasicPen = new Pen(Color.Black);
        Pen Eraser = new Pen(Color.White);

        Tool CurrentTool = Tool.T_None;

        private void Pic_MouseDown(object Sender, MouseEventArgs E)
        {
            bPaint = true;
            Py = E.Location;
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
                    Px = E.Location;
                    Gr.DrawLine(BasicPen, Py, Px);
                    Py = Px;

                    break;

                case Tool.T_Eraser:
                    Px = E.Location;
                    Gr.DrawLine(Eraser, Py, Px);
                    Py = Px;

                    break;
            }

            Pic.Refresh();
        }

        private void Pic_MouseUp(object Sender, MouseEventArgs E)
        {
            bPaint = false;
        }

        private void BtnPencil_Click(object sender, EventArgs e)
        {
            CurrentTool = Tool.T_Pen;
        }

        private void BtnEraser_Click(object sender, EventArgs e)
        {
            CurrentTool = Tool.T_Eraser;
        }

        private void NumericLineWitdth_ValueChanged(object Sender, EventArgs E)
        {
            BasicPen.Width = (float)NumericLineWitdth.Value;
            Eraser.Width = (float)NumericLineWitdth.Value;
        }
    }
}