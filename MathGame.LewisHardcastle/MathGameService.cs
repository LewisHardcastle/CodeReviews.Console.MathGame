using AngouriMath;

namespace MathGame.LewisHardcastle
{
    public class MathGameService
    {
        public List<GameHistoryModel> gameHistory = new List<GameHistoryModel>();

        int gameCounter;
        int score;
        int overallScore;
        public void GenerateMathProblem(string userAnswer)
        {
            Random rnd = new Random();
            int value1 = rnd.Next(1, 100);
            int value2 = rnd.Next(1, 100);

            if (userAnswer == "/")
            {
                while (value1 % value2 != 0)
                {
                    value1 = rnd.Next(1, 100);
                    value2 = rnd.Next(1, 100);
                }
            }

            Entity equation = $"{value1} {userAnswer} {value2}";

            Console.WriteLine($"What is the answer to the equation below?");
            Console.WriteLine($"{value1}{userAnswer}{value2}");
            Console.WriteLine("Type below:");

            int input = Convert.ToInt32(Console.ReadLine());

            // Add error handling for non-int input
            var correctAnswer = equation.EvalNumerical();

            if (input == correctAnswer)
            {
                gameCounter++;
                score = 1;
                overallScore++;
                Console.WriteLine("That is the correct answer.");
                Console.WriteLine("Press any key to go back to the main menu");
                Console.ReadLine();
                Console.Clear();
                HandleGameHistory(gameCounter, score, overallScore);
            }
            else
            {   
                gameCounter++;
                score = -1;
                overallScore--;
                Console.WriteLine($"That is incorrect, the answer is {correctAnswer}");
                Console.WriteLine("Press any key to go back to the main menu");
                Console.ReadLine();
                Console.Clear();
                HandleGameHistory(gameCounter, score, overallScore);
            }
        }

        public void HandleGameHistory(int gameCounter, int gameScore, int overallScore)
        {
            GameHistoryModel gameInstance = new GameHistoryModel();
            gameInstance.GameNumber = gameCounter;
            gameInstance.GameScore = gameScore;
            gameInstance.OverallScore = overallScore;

            gameHistory.Add(gameInstance);
        }

        public void ViewGameHistory()
        {
            if (gameHistory.Count > 0)
            {
                for (var i = 0; i < gameHistory.Count; i++)
                {
                    Console.WriteLine($"Game Number: {gameHistory[i].GameNumber}");
                    Console.WriteLine($"Game Score: {gameHistory[i].GameScore}");
                    Console.WriteLine($"Overall Score: {gameHistory[i].OverallScore}");
                    Console.WriteLine("-------------------------------------------------");
                }
            } 
            else
            {
                Console.WriteLine("You have not played any games yet");
            }
        }
    }
}
