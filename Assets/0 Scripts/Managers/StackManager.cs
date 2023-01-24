using UnityEngine;

namespace CollectCubes.Managers
{
    public class StackManager : MonoBehaviour
    {
        [SerializeField] private Material collectedMaterial;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out ICollectible collectible)) return;
            
            collectible.isScoped = false;
            collectible.Despawn();
            collectible.ChangeColor(collectedMaterial);
        }
    }
}

