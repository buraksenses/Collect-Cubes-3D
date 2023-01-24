using CollectCubes.Managers;
using TMPro;
using UnityEngine;

namespace CollectCubes.UI
{
    public class AI_ScoreHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;

        private void Start()
        {
            // ===== Event Assignments =====
            EventManager.onAI_CollectCube += UpdateAIScore;
        }

        private void UpdateAIScore()
        {
            scoreText.text = (++GameManager.AI_Score).ToString();
        }
    }
}

