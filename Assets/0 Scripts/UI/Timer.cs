using CollectCubes.Managers;
using TMPro;
using UnityEngine;

namespace CollectCubes.UI
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private DataManager gameData;
        [SerializeField] private TMP_Text timerText;

        private void Start()
        {
            // ===== Event Assignments =====
            EventManager.onUpdate += CountDown;
            EventManager.onTimerStops += GameManager.CheckWinner;
        }

        private void CountDown()
        {
            if (gameData.countdownTime > 0f)
                gameData.countdownTime -= Time.deltaTime;
            else
            {
                gameData.countdownTime = 0f;
                EventManager.OnTimerStops();
                EventManager.onUpdate -= CountDown;
            }
                
            
            DisplayTimer(gameData.countdownTime);
        }

        private void DisplayTimer(float timeToDisplay)
        {
            if (timeToDisplay < 0)
                timeToDisplay = 0;

            var minutes = Mathf.FloorToInt(timeToDisplay / 60);
            var seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }
}

