using System;
using ConsoleMenuAPI;

namespace CrossZeroRemastered {
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
