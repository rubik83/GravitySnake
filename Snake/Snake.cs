using SizeI = System.Drawing.Size;
using PointI = System.Drawing.Point;

namespace GravitySnake.Snake;

internal sealed class Snake
{
    private readonly LinkedList<PointI> _coords;
    public int Size { get; private set; }

    public Snake(in SizeI board)
    {
        _coords = new LinkedList<PointI>();
        Size = 10;
        _coords.AddLast(new PointI(board / 2));
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Blue;
        canvas.StrokeSize = 6;
        foreach (var p in _coords) canvas.DrawCircle(p.X, p.Y, 6);
    }

    public bool Next(in SizeI board, ref Apple apple, Direction direction)
    {
        var head = _coords.Last();
        head.Move(direction);
        head.Bounds(board);
        if (_coords.Contains(head)) return false;

        _coords.AddLast(head);

        if (_coords.Last().Near(apple.Position))
        {
            Size += 3 * apple.Size;
            apple = new Apple(board, _coords);
        }

        if (_coords.Count <= Size) return true;

        _coords.RemoveFirst();

        return true;
    }
}
