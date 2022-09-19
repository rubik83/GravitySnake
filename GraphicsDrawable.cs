namespace GravitySnake;

public partial class GraphicsDrawable : IDrawable
{
    //public AccelerometerData Acc;
    internal Snake.Program Prog = new Snake.Program(new System.Drawing.Size { Width = 250, Height = 250 });

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        Prog.Draw(canvas, dirtyRect);
        /*
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 6;
        canvas.DrawLine(
            dirtyRect.Center.X,
            dirtyRect.Center.Y,
            (float)(dirtyRect.Center.X - (Acc.Acceleration.X * dirtyRect.Width / 2.0)),
            (float)(dirtyRect.Center.Y + (Acc.Acceleration.Y * dirtyRect.Height / 2.0))
        );
        canvas.DrawRoundedRectangle(dirtyRect, 10, 10);
        */

    }
}
