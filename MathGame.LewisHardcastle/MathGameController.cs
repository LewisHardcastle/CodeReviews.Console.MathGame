namespace MathGame.LewisHardcastle
{
    public class GameController
    {
        MathGameService gameService = new MathGameService();
        public void InvokeGame() 
        { 
            Console.WriteLine("What game would you like to play today? Choose from the options below:");
            Console.WriteLine("V - View Previous Games");
            Console.WriteLine("A - Addition");
            Console.WriteLine("S - Subtraction");
            Console.WriteLine("M - Multiplication");
            Console.WriteLine("D - Division");
            Console.WriteLine("Q - Quit Program");

            string userInput = Console.ReadLine();

            if (userInput.ToUpper() != "Q")
            {
                Console.Clear();
                MathGameController(userInput);
            }
        }
        
        public void MathGameController(string userAnswer)
        {
            switch (userAnswer.ToUpper())
            {
                case "V":
                    gameService.ViewGameHistory();
                    InvokeGame();
                    break;
                case "A":
                    gameService.GenerateMathProblem("+");
                    InvokeGame();
                    break;
                case "S":
                    gameService.GenerateMathProblem("-");
                    InvokeGame();
                    break;
                case "M":
                    gameService.GenerateMathProblem("*");
                    InvokeGame();
                    break;
                case "D":
                    gameService.GenerateMathProblem("/");
                    InvokeGame();
                    break;
            }
        }
    }
}
