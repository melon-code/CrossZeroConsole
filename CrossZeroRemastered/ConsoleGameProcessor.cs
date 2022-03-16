using System;
using System.Text;
using CrossZeroAPI;

namespace CrossZeroRemastered {
    public class ConsoleGameProcessor : TTCGameProcessor {
        static void DrawLine(string line, bool addEOL) {
            if (addEOL)
                Console.WriteLine();
            Console.WriteLine(tab + line);
        }

        public static void DrawLine(string line) {
            DrawLine(line, false);
        }

        public static void DrawString(string str) {
            Console.Write(tab + str);
        }

        const string tab = "\t";
        const string horizon = "-";
        const int horizonBlockLength = 4;

        string horizontalLine = null;

        bool OnlyAI => Player1 is IAI && Player2 is IAI;
        string HorizontalLine {
            get {
                if (horizontalLine != null)
                    return horizontalLine;
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < GameFieldSize * horizonBlockLength + 1; i++)
                    builder.Append(horizon);
                horizontalLine = builder.ToString();
                return horizontalLine;
            }
        }

        public ConsoleGameProcessor(int fieldSize, IPlayer player1, IPlayer player2, Marks player1Mark) : base(fieldSize, player1, player2, player1Mark) {
        }

        public override void RenderGameField(ReadOnlyTable gameField) {
            DrawGrid(gameField);
            if (OnlyAI) {
                Console.WriteLine();
                DrawString("Нажмите Enter для продолжения");
                Console.ReadLine();
            }
        }

        public override void RenderLastFieldAndResult(ReadOnlyTable gameField, EndResult result) {
            DrawGrid(gameField);
            string resStr;
            switch (result) {
                case EndResult.CrossWin:
                    resStr = "Крестики победили!";
                    break;
                case EndResult.ZeroWin:
                    resStr = "Нолики победили!";
                    break;
                case EndResult.Draw:
                    resStr = "Ничья!";
                    break;
                default:
                    resStr = "WOOOP";
                    break;
            }
            DrawLine(resStr, true);
            Console.WriteLine();
        }

        void DrawGrid(ReadOnlyTable grid) {
            Console.Clear();
            for (int i = 0; i < GameFieldSize; i++) {
                DrawString("|");
                for (int j = 0; j < GameFieldSize; j++)
                    DrawCell(grid[i, j]);
                DrawLine(HorizontalLine, true);
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
            Console.Write(" " + mark + " |");
        }
    }
}
