class Vector
{
    public delegate void VectorChangeHandler(int x, int y);
    public event VectorChangeHandler? VectorChangeEvent;

    int x;
    int y;

    public int X {
        get { return x; }
        set {
            VectorChangeEvent?.Invoke(this.x, this.y);
            x = value; 
        }
    }
    public int Y {
        get { return y; }
        set
        {
            VectorChangeEvent?.Invoke(this.x, this.y);
            y = value;
        }
    }

    public Vector(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}