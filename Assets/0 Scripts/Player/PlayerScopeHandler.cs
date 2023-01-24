using System.Collections.Generic;
using CollectCubes.Collectibles;
using UnityEngine;

namespace CollectCubes.Player
{
    public class PlayerScopeHandler : MonoBehaviour
    {
        // If the player collect a cube, it's isScoped property will be changed to true.
        // Hence, other players can not interact with that cube until the player stops holding it.

        private LayerMask _playerLayerMask;
        
        private List<ICollectible> _scopedCubes = new List<ICollectible>();

        private void Awake()
        {
            _playerLayerMask = LayerMask.NameToLayer("PlayerScope");
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!other.TryGetComponent(out CollectibleCube collectible))return;
            if (collectible.isScoped) return;
            
            collectible.isScoped = true;
            collectible.ChangeLayer(_playerLayerMask);
            
            _scopedCubes.Add(collectible);
        }
        
        private void OnTriggerExit(Collider other)
        {
            if(!other.TryGetComponent(out ICollectible collectible))return;
            
            collectible.isScoped = false;
            collectible.ChangeLayer(LayerMask.NameToLayer("Default"));

            _scopedCubes.Remove(collectible);
        }

        /// <summary>
        /// If the player hits an obstacle, this line will be executed
        /// </summary>
        private void OnDisable()
        {
            foreach (var scopedCube in _scopedCubes)
            {
                scopedCube.isScoped = false;
                scopedCube.ChangeLayer(LayerMask.NameToLayer("Default"));
            }

            _scopedCubes.RemoveRange(0,_scopedCubes.Count);
        }
    }
}

