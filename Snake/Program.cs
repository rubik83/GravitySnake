using SizeI = System.Drawing.Size;
using PointI = System.Drawing.Point;

namespace GravitySnake.Snake;

internal sealed class Program
{
    private readonly SizeI _board;
    private Apple _apple;
    private readonly Snake _snake;

    public Program(SizeI board)
    {
        _board = board;
        _apple = new Apple(_board, new LinkedList<PointI>());
        _snake = new Snake(_board);
    }

    public bool Update(float AccX, float AccY)
    {
        var direction = DirectionFromAcc(AccX, AccY);
        if (!_snake.Next(_board, ref _apple, direction))
        {
            return false;
        }

        return true;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        _snake.Draw(canvas, dirtyRect);
        _apple.Draw(canvas, dirtyRect);
    }

    private static Direction DirectionFromAcc(float AccX, float AccY)
    {
        if (Math.Abs(AccY) > Math.Abs(AccX))
        {
            if (AccY < 0.0)
                return Direction.Up;
            else
                return Direction.Down;
        }
        else
        {
            if (AccX > 0.0)
                return Direction.Left;
            else
                return Direction.Right;
        }
    }
}
