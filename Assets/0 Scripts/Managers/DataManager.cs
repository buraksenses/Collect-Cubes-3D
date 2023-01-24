using UnityEngine;

namespace CollectCubes.Managers
{
    [CreateAssetMenu(fileName = "Game Data",menuName = "Create Game Data")]
    public class DataManager : ScriptableObject
    {
        public float characterSpeed;
        public float countdownTime;
        public int maxCubesAtATime;
    }
}

