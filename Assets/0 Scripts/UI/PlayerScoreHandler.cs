using CollectCubes.Managers;
using TMPro;
using UnityEngine;

namespace CollectCubes.UI
{
    public class PlayerScoreHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;

        private void Start()
        {
            // ===== Event Assignments =====
            EventManager.onPlayerCollectCube += UpdatePlayerScore;
        }

        private void UpdatePlayerScore()
        {
            scoreText.text = (++GameManager.playerScore).ToString();
        }
    }
}

