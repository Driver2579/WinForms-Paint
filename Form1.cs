using Paint.Enums;

namespace Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            FormController = new Controller(Pic, (float)NumericLineWitdth.Value);
        }

        Controller FormController;

        private void Pic_MouseDown(object Sender, MouseEventArgs E)
        {
            FormController.BeginDrawing(E.Location);
        }

        private void Pic_MouseMove(object Sender, MouseEventArgs E)
        {
            FormController.Draw(E.Location, Pic);
        }

        private void Pic_MouseUp(object Sender, MouseEventArgs E)
        {
            FormController.EndDrawing(Pic, E.Location);
        }

        private void BtnColor_Click(object Sender, EventArgs E)
        {
            ColorDialog1.ShowDialog();
            FormController.SetColor(PicColor, ColorDialog1.Color);
        }

        private void BtnFill_Click(object Sender, EventArgs E)
        {
            FormController.CurrentTool = Tool.Fill;
        }

        private void BtnPencil_Click(object Sender, EventArgs E)
        {
            FormController.CurrentTool = Tool.Pen;
        }

        private void BtnEraser_Click(object Sender, EventArgs E)
        {
            FormController.CurrentTool = Tool.Eraser;
        }

        private void BtnEllipse_Click(object Sender, EventArgs E)
        {
            FormController.CurrentTool = Tool.Ellipse;
        }

        private void BtnRect_Click(object Sender, EventArgs E)
        {
            FormController.CurrentTool = Tool.Rectangle;
        }

        private void BtnLine_Click(object sender, EventArgs e)
        {
            FormController.CurrentTool = Tool.Line;
        }

        private void NumericLineWitdth_ValueChanged(object Sender, EventArgs E)
        {
            FormController.SetPenWidth((float)NumericLineWitdth.Value);
        }

        private void BtnClear_Click(object Sender, EventArgs E)
        {
            FormController.ClearImage(Pic);
        }

        private void BtnSave_Click(object Sender, EventArgs E)
        {
            FormController.SaveImage(Pic, SaveFileDialog1);
        }

        private void Pic_Paint(object Sender, PaintEventArgs E)
        {
            FormController.DrawFigure(E.Graphics);
        }

        private void ColorPicker_MouseClick(object Sender, MouseEventArgs E)
        {
            FormController.PickColor(ColorPicker, PicColor, E.Location);
        }
    }
}