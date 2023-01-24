using System;
using UnityEngine;

namespace CollectCubes.Managers
{
    public class EventManager : MonoBehaviour
    { 
        public static event Action onUpdate, onFixedUpdate;
        public static event Action onTimerStops,onPlayerCollectCube,onAI_CollectCube;
        public static event Action onAI_Explodes,onPlayerExplodes,onAI_Respawn,onPlayerRespawn;
        public static event Action onGameDifficultySelected;

        public static event Action onGameFail, onGameSuccess,onGameDraw;

        private static void ResetEvents()
        {
            onUpdate = null;
            onFixedUpdate = null;
            onTimerStops = null;
            onPlayerCollectCube = null;
            onAI_CollectCube = null;
            onAI_Explodes = null;
            onGameDifficultySelected = null;
            onAI_Respawn = null;
            onPlayerExplodes = null;
            onPlayerRespawn = null;
            onGameFail = null;
            onGameSuccess = null;
            onGameDraw = null;
        }

        private void Awake()
        {
            ResetEvents();
        }

        private void Start()
        {
            GameManager.ResetValues();
        }

        private void Update()
        {
            if(GameManager.isGameStarted)
                onUpdate?.Invoke();
        }

        private void FixedUpdate()
        {
            onFixedUpdate?.Invoke();
        }

        public static void OnTimerStops()
        {
            onTimerStops?.Invoke();
        }

        public static void OnPlayerCollectCube()
        {
            onPlayerCollectCube?.Invoke();
        }

        public static void OnAI_CollectCube()
        {
            onAI_CollectCube?.Invoke();
        }

        public static void OnAI_Explodes()
        {
            onAI_Explodes?.Invoke();
        }
        
        public static void OnPlayerExplodes()
        {
            onPlayerExplodes?.Invoke();
        }

        public static void OnGameDifficultySelected()
        {
            onGameDifficultySelected?.Invoke();
        }

        public static void OnAI_Respawn()
        {
            onAI_Respawn?.Invoke();
        }
        
        public static void OnPlayerRespawn()
        {
            onPlayerRespawn?.Invoke();
        }

        public static void OnGameSuccess()
        {
            onGameSuccess?.Invoke();
        }

        public static void OnGameDraw()
        {
            onGameDraw?.Invoke();
        }

        public static void OnGameLose()
        {
            onGameFail?.Invoke();
        }
    }
}

