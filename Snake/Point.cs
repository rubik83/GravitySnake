using SizeI = System.Drawing.Size;
using PointI = System.Drawing.Point;

namespace GravitySnake.Snake;

/// <summary>
///  Cardinal directions
/// </summary>
internal enum Direction
{
    Up,
    Down,
    Left,
    Right,
}

/// <summary>
///  This class performs extensions for <c>System.Drawing.Point</c>
/// </summary>
internal static class PointExtents
{
    /// <summary>
    ///  Move <c>Point</c> <paramref name="point"/> of <c>1</c> in <c>Direction</c> <paramref name="direction"/>
    /// </summary>
    /// <param name="point">Point to move</param>
    /// <param name="direction">Direction to move to</param>
    public static void Move(ref this PointI point, Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                point.Y -= 1;
                break;
            case Direction.Down:
                point.Y += 1;
                break;
            case Direction.Left:
                point.X -= 1;
                break;
            case Direction.Right:
                point.X += 1;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }

    public static bool Near(in this PointI point, in PointI other)
    {
        var result = new SizeI(point) - new SizeI(other);
        return ((Math.Abs(result.Width) < 6) && (Math.Abs(result.Height) < 6));
    }

    /// <summary>
    /// Wraps each dimension beyond a maximum or under <c>0</c>
    /// </summary>
    /// <param name="point">Point to wrap</param>
    /// <param name="max">Maximum width/height value for X/Y</param>
    internal static void Bounds(ref this PointI point, SizeI max)
    {
        point.X = ScalarBounds(point.X, max.Width);
        point.Y = ScalarBounds(point.Y, max.Height);
    }

    private static int ScalarBounds(int v, int maxV)
    {
        if (v < 0) return v + maxV;

        if (v >= maxV) return v - maxV;

        return v;
    }
}
