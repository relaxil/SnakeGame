enum Direction
{
    Left,
    Right,
    Up,
    Down
}

class Snake: Object
{
    public Direction direction = Direction.Right;

    public Snake(char symbol, int x, int y) : base (symbol, x, y)
    {
        this.position.VectorChangeEvent += Object.delete;
    }
    public void step()
    {
        switch (this.direction)
        {
            case Direction.Right:
                this.position.X += 1;
                break;
            case Direction.Left:
                this.position.X -= 1;
                break;
            case Direction.Up:
                this.position.Y -= 1;
                break;
            case Direction.Down:
                this.position.Y += 1;
                break;
        }
    }
}
