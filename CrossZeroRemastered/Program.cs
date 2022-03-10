using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossZeroAPI;

namespace TestAI {
    class Program {
        static void Main(string[] args) {
            int a = 16;
            uint b = 15;
            string str = $"{a} + {b}";
            bool val = true;
            bool val1 = val ^ true;
            bool val2 = val1 ^ true;
            ConsoleTestGameProcessor processor = new ConsoleTestGameProcessor(3, new AI(), new AI(), Marks.Cross);
            processor.Play();
        }
    }

    public class ConsoleTestGameProcessor : TTCGameProcessor {
        public ConsoleTestGameProcessor(int fieldSize, IPlayer player1, IPlayer player2, Marks player1Mark) : base(fieldSize, player1, player2, player1Mark) {
        }

        public override void RenderGameField(ReadOnlyTable gameField) {
            DrawGrid(gameField);
            Console.WriteLine("\nPress to continue");
            Console.ReadLine();
        }

        public override void RenderResult(EndResult result) {
            if (TryGetGameField(out ReadOnlyTable table))
                DrawGrid(table);
            string resStr;
            switch (result) {
                case EndResult.CrossWin:
                    resStr = "Cross WIN!";
                    break;
                case EndResult.ZeroWin:
                    resStr = "Zero WIN!";
                    break;
                case EndResult.Draw:
                    resStr = "DRAW!";
                    break;
                default:
                    resStr = "WOOOP";
                    break;
            }
            Console.WriteLine("\n" + resStr);
            Console.ReadLine();
        }

        void DrawGrid(ReadOnlyTable grid) {
            Console.Clear();
            for (int i = 0; i < GameFieldSize; i++) {
                for (int j = 0; j < GameFieldSize; j++) 
                    DrawCell(grid[i, j]);
                Console.WriteLine("\n---------");
            }
        }

        void DrawCell(Cell item) {
            string mark;
            switch (item) {
                case Cell.Zero:
                    mark = "O";
                    break;
                case Cell.Cross:
                    mark = "X";
                    break;
                case Cell.Empty:
                    mark = " ";
                    break;
                default:
                    mark = "?";
                    break;
            }
            Console.Write(mark + " |");
        }
    }
}
