using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Object {
    public char symbol;
    public Vector position;

    public bool isExists = false;

    public Object(char symbol, int x, int y)
    {
        this.symbol = symbol;
        this.position = new Vector(x, y);
    }
    public static void delete(int x, int y)
    {
        Game.playingField[y, x] = ' ';
    }
    public static bool detectCollision(Object who1, Object who2)
    {
        if(who1.position.X == who2.position.X && who1.position.Y == who2.position.Y)
        {
            return true;
        }
        return false;
    }
    public void spawn()
    { 
        this.isExists = true;
        Game.playingField[position.Y, position.X] = this.symbol;
    }
}
