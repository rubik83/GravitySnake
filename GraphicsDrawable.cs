namespace GravitySnake;

public partial class GraphicsDrawable : IDrawable
{
    internal Snake.Program Prog = new Snake.Program(new System.Drawing.Size { Width = 250, Height = 250 });

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.FillColor = Colors.Black;
        canvas.FillRectangle(dirtyRect);
        Prog.Draw(canvas, dirtyRect);
    }
}
