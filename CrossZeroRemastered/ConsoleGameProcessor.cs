using System;
using CrossZeroAPI;

namespace CrossZeroRemastered {
    public class ConsoleGameProcessor : TTCGameProcessor {
        public ConsoleGameProcessor(int fieldSize, IPlayer player1, IPlayer player2, Marks player1Mark) : base(fieldSize, player1, player2, player1Mark) {
        }

        public override void RenderGameField(ReadOnlyTable gameField) {
            DrawGrid(gameField);
            Console.WriteLine("\nPress Enter to continue");
            Console.ReadLine();
        }

        public override void RenderLastFieldAndResult(ReadOnlyTable gameField, EndResult result) {
            DrawGrid(gameField);
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
            Console.WriteLine();
            //Console.ReadLine();
        }

        void DrawGrid(ReadOnlyTable grid) {
            Console.Clear();
            for (int i = 0; i < GameFieldSize; i++) {
                Console.Write("\t");
                for (int j = 0; j < GameFieldSize; j++)
                    DrawCell(grid[i, j]);
                Console.WriteLine("\n\t---------");
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

    public class ConsolePlayer : IPlayer {
        public Coordinate MakeTurn() {
            Console.Write("Введите строку: ");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите столбец: ");
            int column = Convert.ToInt32(Console.ReadLine());
            return new Coordinate(row, column);
        }
    }
}
