namespace TimesTableGame.util;

public struct GameResult
{
    public static readonly GameResult Success = new GameResult("You win!");
    public static readonly GameResult Failure = new GameResult("You lose :(");
    
    public string Message
    {
        get;
        private set;
    }
    
    private GameResult(string message)
    {
        Message = message;
    }
}