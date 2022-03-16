using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMenuAPI;
using CrossZeroAPI;

namespace CrossZeroRemastered {
    public class MainMenu : StandardConsoleMenu {
        static IPlayer CreatePlayer(bool player, int number, string mark) {
            if (player)
                return new ConsolePlayer(number, mark);
            return new AI();
        }

        const int sizeIndex = 1;
        const int player1Index = 2;
        const int player2Index = 3;
        const string player1Mark = "X";
        const string player2Mark = "O";

        public int Size => GetInt(sizeIndex);
        public IPlayer Player1 => CreatePlayer(GetInt(player1Index) == 0, 1, player1Mark);
        public IPlayer Player2 => CreatePlayer(GetInt(player2Index) == 0, 2, player2Mark);

        public MainMenu() : base(ItemsListHelper.GetMainMenuItems(), Localization.ExitString) {
        }
    }
}
