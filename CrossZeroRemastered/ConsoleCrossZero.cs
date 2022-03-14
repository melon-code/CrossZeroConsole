using CrossZeroAPI;
using ConsoleMenuAPI;

namespace CrossZeroRemastered {
    public static class ConsoleCrossZero {
        public static void Run() {
            MenuEndResult endMenuResult = MenuEndResult.Further;
            MainMenu menu = new MainMenu();
            EndMenu endMenu;
            while (endMenuResult == MenuEndResult.Further && menu.ShowDialog() == MenuEndResult.Further) {
                do {
                    ConsoleGameProcessor processor = new ConsoleGameProcessor(menu.Size, menu.Player1, menu.Player2, Marks.Cross);
                    processor.Play();
                    endMenu = new EndMenu();
                    endMenuResult = endMenu.ShowDialog();
                } while (endMenu.Repeat);
            }
        }
    }
}
