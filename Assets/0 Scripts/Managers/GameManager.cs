
namespace CollectCubes.Managers
{
    public static class GameManager
    {
        public static GameDifficulty GameDifficulty;
        
        public static int AI_Score;
        public static int playerScore;
        public static bool isGameStarted;

        public static void CheckWinner()
        {
            if (AI_Score > playerScore)
            {
                UI_Manager.Instance.OpenLosePanel();
                EventManager.OnGameLose();
            }
                
            else if (AI_Score < playerScore)
            {
                UI_Manager.Instance.OpenWinPanel();
                EventManager.OnGameSuccess();
            }

            else
            {
                UI_Manager.Instance.OpenDrawPanel();
                EventManager.OnGameDraw();
            }
                
        }

        public static void ResetValues()
        {
            AI_Score = 0;
            playerScore = 0;
            isGameStarted = false;
        }
    }

    public enum GameDifficulty
    {
        Easy,
        Medium,
        Hard
    }
}

