using System;
using CrossZeroAPI;

namespace CrossZeroRemastered {
    public class ConsolePlayer : IPlayer {
        readonly int number;
        readonly string mark;

        public ConsolePlayer(int playerNumber, string playerMark) {
            number = playerNumber;
            mark = playerMark;
        }

        public Coordinate MakeTurn() {
            ConsoleGameProcessor.DrawLine($"Ход Игрока №{number} -- " + mark);
            ConsoleGameProcessor.DrawString("Введите строку: ");
            int row = Convert.ToInt32(Console.ReadLine());
            ConsoleGameProcessor.DrawString("Введите столбец: ");
            int column = Convert.ToInt32(Console.ReadLine());
            return new Coordinate(row - 1, column - 1);
        }
    }
}
