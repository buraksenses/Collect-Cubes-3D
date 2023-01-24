using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CollectCubes.Managers
{
    public class UI_Manager : Singleton<UI_Manager>
    {
        [Header("Scriptable Object References")] 
        [SerializeField] private DataManager gameData;
        
        [Header("UI Panel References")] 
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private GameObject drawPanel;
        [SerializeField] private GameObject gameSettingsPanel;

        [Header("Game Settings Slider References")] 
        [SerializeField] private Slider playerSpeedSlider;
        [SerializeField] private Slider timerValueSlider;
        [SerializeField] private Slider maxCubesAtATimeSlider;

        private void Start()
        {
            // ===== Loading Saved Game Settings =====
            playerSpeedSlider.value = gameData.characterSpeed;
            timerValueSlider.value = gameData.countdownTime;
            maxCubesAtATimeSlider.value = gameData.maxCubesAtATime;
        }

        #region Start Panel Button Methods

        public void GameModeEasyButtonOnClick(GameObject panel)
        {
            DifficultyButtonOnclick(GameDifficulty.Easy,panel);
        }
    
        public void GameModeMediumButtonOnClick(GameObject panel)
        {
            DifficultyButtonOnclick(GameDifficulty.Medium,panel);
        }
    
        public void GameModeHardButtonOnClick(GameObject panel)
        {
            DifficultyButtonOnclick(GameDifficulty.Hard,panel);
        }

        private void DifficultyButtonOnclick(GameDifficulty gameDifficulty, GameObject panel)
        {
            GameManager.GameDifficulty = gameDifficulty;
            EventManager.OnGameDifficultySelected();
            panel.SetActive(false);
            gameSettingsPanel.SetActive(true);
        }

        #endregion

        #region Lose Panel Button Methods

        public void RetryButtonOnClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }

        #endregion

        #region Win Panel Button Methods

        public void RestartButtonOnClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }

        #endregion

        #region Draw Panel Button Methods

        public void DrawRetryButtonOnClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }

        #endregion

        #region Game Settings Methods

        public void OnPlayerSpeedChanged()
        {
            gameData.characterSpeed = playerSpeedSlider.value;
        }

        public void OnTimerValueChanged()
        {
            gameData.countdownTime = timerValueSlider.value;
        }

        public void OnMaxCubeAtATimeValueChanged()
        {
            gameData.maxCubesAtATime = (int)maxCubesAtATimeSlider.value;
        }

        public void PlayButtonOnClick(GameObject panel)
        {
            GameManager.isGameStarted = true;
            GameSaveManager.Instance.SaveGame();
            panel.SetActive(false);
        }

        #endregion

        public void OpenWinPanel()
        {
            winPanel.SetActive(true);
        }
        
        public void OpenLosePanel()
        {
            losePanel.SetActive(true);
        }

        public void OpenDrawPanel()
        {
            drawPanel.SetActive(true);
        }
    }
}

