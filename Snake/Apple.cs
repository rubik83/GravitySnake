using System.Security.Cryptography;
using SizeI = System.Drawing.Size;
using PointI = System.Drawing.Point;

namespace GravitySnake.Snake;

internal struct Apple
{
    internal PointI Position { get; }
    internal int Size { get; }

    internal Apple(in SizeI board, LinkedList<PointI> exclude)
    {
        do
        {
            Position = new PointI
            {
                X = RandomNumberGenerator.GetInt32(0, board.Width),
                Y = RandomNumberGenerator.GetInt32(0, board.Height),
            };
        } while (exclude.Contains(Position));

        Size = RandomNumberGenerator.GetInt32(1, 4);
    }

    private Color GetColor()
    {
        return Size switch
        {
            1 => Colors.Green,
            2 => Colors.Yellow,
            3 => Colors.Red,
            _ => throw new ArgumentOutOfRangeException()
        };
    }


    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = GetColor();
        canvas.StrokeSize = 6;
        canvas.DrawCircle(Position.X, Position.Y, 6);
    }
}
