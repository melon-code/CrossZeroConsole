using System.Collections.Generic;
using ConsoleMenuAPI;

namespace CrossZeroRemastered {
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
}
