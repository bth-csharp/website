namespace Dice100.src;

public class AsciiArt
{

    public static void PrintDie(int diceRoll)
    {
        switch (diceRoll)
        {
            case 1:
                Console.Write(@"
     _______
    |       |
    |   *   |
    |       |
     -------");
                break;
            case 2:
                Console.Write(@"
     _______
    | *     |
    |       |
    |     * |
     ------- ");
                break;
            case 3:
                Console.Write(@"
     _______
    | *     |
    |   *   |
    |     * |
     -------");
                break;
            case 4:
                Console.Write(@"
     _______
    | *   * |
    |       |
    | *   * |
     -------");
                break;
            case 5:
                Console.Write(@"
     _______
    | *   * |
    |   *   |
    | *   * |
     -------");
                break;
            case 6:
                Console.Write(@"
     _______
    | * * * |
    |       |
    | * * * |
     -------");
                break;
        }
    }
}