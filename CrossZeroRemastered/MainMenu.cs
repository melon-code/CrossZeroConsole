using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMenuAPI;

namespace CrossZeroRemastered {
    public class MainMenu : StandardConsoleMenu {
        const int sizeIndex = 1;
        const int player1Index = 2;
        const int player2Index = 3;

        public int Size => GetInt(sizeIndex);
        public bool Player1 => GetInt(player1Index) == 0;
        public bool Player2 => GetInt(player2Index) == 0;

        public MainMenu() : base(ItemsListHelper.GetMainMenuItems(), Localization.ExitString) {
        }
    }

    static class ItemsListHelper {
        public static IList<IMenuItem> GetMainMenuItems() {
            List<string> playerType = new List<string>() { "Игрок", "Компьютер" };
            return new List<IMenuItem>() {
                new ContinueItem("Новая игра"), new IntMenuItem("Размер поля", 3, 2, 128), new StringListMenuItem("Игрок 1", playerType),
                new StringListMenuItem("Игрок 2", playerType, 1)
            };
        }

        public static IList<IMenuItem> GetEndMenuItems() {
            return new List<IMenuItem>() {
                new ContinueItem("Повторить"), new ContinueItem("В главное меню"), new ExitItem(Localization.ExitString)
            };
        }
    }

    public class EndMenu : StandardConsoleMenu {
        readonly int cursorLeft;
        readonly int cursorTop;

        public bool Repeat => CurrentPosition == 0;

        public EndMenu() : base(ItemsListHelper.GetEndMenuItems()) {
            cursorLeft = Console.CursorLeft;
            cursorTop = Console.CursorTop;
            Drawer.ClearScreenInitially = false;
        }

        protected override void Draw() {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            DrawMenu();
        }
    }
}
