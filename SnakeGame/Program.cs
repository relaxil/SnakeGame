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

void spawnSnakeTail(ref List<Snake> list)
{
    int lastList = list.Count - 1;
    Snake? newSnake = null;

    switch (list[lastList].direction)
    {
        case Direction.Left:
            newSnake = new Snake('@', list[lastList].position.X + 1, list[lastList].position.Y);
            list[lastList].lastTail = newSnake;
            list.Add(newSnake);
            break;
        case Direction.Right:
            newSnake = new Snake('@', list[lastList].position.X - 1, list[lastList].position.Y);
            list[lastList].lastTail = newSnake;
            list.Add(newSnake);
            break;
        case Direction.Up:
            newSnake = new Snake('@', list[lastList].position.X, list[lastList].position.Y - 1);
            list[lastList].lastTail = newSnake;
            list.Add(newSnake);
            break;
        case Direction.Down:
            newSnake = new Snake('@', list[lastList].position.X, list[lastList].position.Y + 1);
            list[lastList].lastTail = newSnake;
            list.Add(newSnake);
            break;
    }
    if(newSnake != null) newSnake.direction = list[lastList].direction;

    /*Snake newSnake = new Snake('@', list[lastList].position.X - 1, list[lastList].position.Y);
    list[lastList].lastTail = newSnake;
    list.Add(newSnake);*/
}

void render()
{
    Game.fillField();
    Snake snake = new Snake('@', 30, 10);
    Food food = new Food('&');

    ConsoleKey key = default;

    List<Snake> list = new List<Snake>();
    list.Add(snake);

    while (true)
    {
        Thread.Sleep(700);

        if (Object.detectCollision(snake, food))
        {
            food.Ticks = 0;
            food.isExists = false;

            spawnSnakeTail(ref list);
        }

        if (Console.KeyAvailable)
            key = Console.ReadKey(true).Key;
        checkKey(key, ref snake);

        snake.step();

        food.Ticks++;
        checkFoodTicket(ref food);

        foreach (Snake item in list)
        {
            item.spawn();
        }

        Console.Clear();
        renderPlayingField();
    }
}

render();