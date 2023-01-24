using CollectCubes.Managers;
using DG.Tweening;
using UnityEngine;

namespace CollectCubes.AI
{
    public class Obstacle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out AI_Patrol patrol))
            {
                var transform1 = patrol.transform;
                EffectManager.Instance.SpawnAIExplosionEffect(transform1.position,transform1.rotation);
                patrol.gameObject.SetActive(false);
                EventManager.OnAI_Explodes();
                DOVirtual.DelayedCall(1f, () => patrol.gameObject.SetActive(true));
            }
            else if (other.gameObject.layer == LayerMask.NameToLayer("PlayerScope"))
            {
                var transform1 = other.transform;
                EffectManager.Instance.SpawnPlayerExplosionEffect(transform1.position,transform1.rotation);
                other.gameObject.SetActive(false);
                EventManager.OnPlayerExplodes();
                DOVirtual.DelayedCall(1f, () => other.gameObject.SetActive(true));
            }
        }
    }
}

