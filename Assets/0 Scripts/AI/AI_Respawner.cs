using CollectCubes.Managers;
using DG.Tweening;
using UnityEngine;

namespace CollectCubes.AI
{
    public class AI_Respawner : MonoBehaviour
    {
        private Vector3 _startPosition;
        private Quaternion _startRotation;

        private void Start()
        {
            _startPosition = transform.position;
            _startRotation = transform.rotation;

            // ===== Event Assignments =====
            EventManager.onAI_Explodes += SpawnAtStart;
        }

        private void SpawnAtStart()
        {
            DOVirtual.DelayedCall(1, () =>
            {
                transform.position = _startPosition;
                transform.rotation = _startRotation;
                EventManager.OnAI_Respawn();
            });
           
        }
    }
}

