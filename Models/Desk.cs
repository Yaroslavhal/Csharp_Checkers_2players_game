using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers_demo_2._0.Models
{
    public class Desk
    {
        public char[,] matrix;
        public Desk()
        {
            matrix = new char[,] { { ' ', '-', ' ', '-', ' ', '-', ' ', '-' },
                                   { '-', ' ', '-', ' ', '-', ' ', '-', ' ' },
                                   { ' ', '-', '-', '-', ' ', '-', ' ', '-' },
                                   { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                   { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                   { '+', ' ', '+', ' ', '+', ' ', '+', ' ' },
                                   { ' ', '+', ' ', '+', ' ', '+', ' ', '+' },
                                   { '+', ' ', '+', ' ', '+', ' ', '+', ' ' }};
        }

        public void Move(int a, int b, int a2, int b2)
        {
            if (matrix[a,b] == '+')
            {
                matrix[a, b] = ' ';
                matrix[a2, b2] = '+';
            }
            else if (matrix[a, b] == '-')
            {
                matrix[a, b] = ' ';
                matrix[a2, b2] = '-';
            }
        }
    }
}
