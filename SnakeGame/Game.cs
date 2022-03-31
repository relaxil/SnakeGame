using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class Game {
    public static char[,] playingField = new char[20, 60];

    public static void fillField()
    {
        int row = Game.playingField.GetLength(0);
        int column = Game.playingField.GetLength(1);

        for(int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if(i == 0 || i == row - 1)
                {
                    Object obj = new Object('#', j, i);
                    obj.spawn();
                }
                else if (j == 0 || j == column - 1)
                {
                    Object obj = new Object('#', j, i);
                    obj.spawn();
                }
                else if(i > 0 && i < row - 1 && j > 0 && j < column - 1)
                {
                    Object obj = new Object(' ', j, i);
                    obj.spawn();
                }
            }
        }
    }
}
