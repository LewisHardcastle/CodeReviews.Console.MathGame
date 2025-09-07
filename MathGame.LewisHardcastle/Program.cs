using MathGame.LewisHardcastle;

class Program
{
    static GameController gameController = new GameController();

    static void Main()
    {
        StartGame(gameController);
    }

    static void StartGame(GameController controller)
    {
        controller.InvokeGame();
    }
};