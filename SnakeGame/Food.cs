class Food: Object
{
    public delegate void FoodHanlder();
    public event FoodHanlder FoodEvent;

    int ticket;
    public int Ticks {
        get { return ticket; }
        set
        {
            if (ticket == 5)
            {
                ticket = 0;
                FoodEvent?.Invoke();
            }
            else
                ticket = value;
        }
    }

    public Food(char symbol): base(symbol, 0, 0) { }
}