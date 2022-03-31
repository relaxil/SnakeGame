void renderPlayingField()
{
    for(int i = 0; i < Game.playingField.GetLength(0); i++)
    {
        for(int j = 0; j < Game.playingField.GetLength(1); j++)
        {
            Console.Write(Game.playingField[i, j]);
        }
        Console.Write('\n');
    }
}

void checkKey(ConsoleKey key, ref Snake snake)
{
    switch (key)
    {
        case ConsoleKey.RightArrow:
            snake.direction = Direction.Right;
            break;
        case ConsoleKey.LeftArrow:
            snake.direction = Direction.Left;
            break;
        case ConsoleKey.UpArrow:
            snake.direction = Direction.Up;
            break;
        case ConsoleKey.DownArrow:
            snake.direction = Direction.Down;
            break;
    }
}

void checkFoodTicket(ref Food food)
{
    if (!food.isExists && food.Ticks == 5)
    {
        Random rand = new Random();
        int randomX = rand.Next(1, Game.playingField.GetLength(1) - 1);
        int randomY = rand.Next(1, Game.playingField.GetLength(0) - 1);

        food.position = new Vector(randomX, randomY);
        food.spawn();
    }
}

void render()
{
    Game.fillField();
    Snake snake = new Snake('@', 30, 10);
    Food food = new Food('&');

    ConsoleKey key = default;

    while (true)
    {
        Thread.Sleep(700);

        if (Console.KeyAvailable)
            key = Console.ReadKey(true).Key;

        checkKey(key, ref snake);

        food.Ticks++;
        checkFoodTicket(ref food);

        if(Object.detectCollision(snake, food))
            food.isExists = false;

        snake.step();
        snake.spawn();

        Console.Clear();
        renderPlayingField();
    }
}

render();