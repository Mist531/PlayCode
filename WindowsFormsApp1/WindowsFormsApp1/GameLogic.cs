using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class GameLogic
    {
        int size = 4;
        int[,] map;
        int space_x, space_y;
        static Random rand = new Random(); 
        public GameLogic(int size)
        {
            map = new int[size,size];
        }
        public void start()
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    map[x, y] = cords(x, y) + 1;
                }
            }
            space_x = size - 1;
            space_y = size - 1;
            map[space_x , space_y ] = 0;
        }
        public int get(int position)
        {
            int x,y;
            cordVozvr(position, out x, out y);
            if (x < 0 || x >= size)
            {
                return 0;
            }
            if (y < 0 || y >= size)
            {
                return 0;
            }
            return map[x,y];
        }
        private int cords(int x, int y) 
        {
            if (x > size - 1)
            {
                x=size - 1;
            }
            if(y > size - 1)
            {
                y=size - 1;
            }
            if(x < 0)
            {
                x = 0;
            }
            if (y<0)
            {
                y=0;
            }
            return y * size + x;       
        }
        private void cordVozvr(int position, out int x, out int y)
        {
            if(position < 0)
            {
                position=0;
            }
            if(position > size*size - 1)
            {
                position=size*size - 1;
            }
            x = position % size;
            y = position / size;
        }
        public void smena(int position)
        {
            int x, y;
            cordVozvr(position, out x, out y);
            if (Math.Abs(space_x - x) + Math.Abs(space_y - y) != 1)
            {
                return;
            }
            map[space_x,space_y] = map[x,y];
            map[x, y] = 0;
            space_y = y;
            space_x = x;

        }
        public void random()
        {
            int a = rand.Next(0, 4);
            int x = space_x;
            int y = space_y;
            switch (a)
            {
                case 0: x--; break;
                case 1: x++; break;
                case 2: y--; break;
                case 3: y++; break;
            }
            smena(cords(x,y));
        }
        public bool Proverka()
        {
            if (!(space_x == size - 1 && space_y == size - 1))
            {
                return false;
            }
            for(int x = 0; x < size; x++)
            {
                for(int y = 0; y < size; y++)
                {
                    if (!(x == size - 1 && y == size - 1))
                    {
                        if (map[x, y] != cords(x, y) + 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
