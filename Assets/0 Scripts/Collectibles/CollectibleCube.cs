using CollectCubes.Managers;
using DG.Tweening;
using EZ_Pooling;
using UnityEngine;

namespace CollectCubes.Collectibles
{
    public class CollectibleCube : MonoBehaviour,ICollectible
    { 
        private MeshRenderer _meshRenderer; 
        private Rigidbody _rigidbody;
        
        public bool isScoped { get; set; }
        public LayerMask LayerMask { get; set; }
        
        public Material[] sharedMaterials;

        private void Awake()
        {
            //Component Assignment
            _meshRenderer = GetComponent<MeshRenderer>();
            _rigidbody = GetComponent<Rigidbody>();
            
            //Property Assignment
            LayerMask = LayerMask.NameToLayer("Default");

            //Assigning default material to the cube
            _meshRenderer.sharedMaterial = sharedMaterials[0];
        }

        public void ChangeColor(Material material)
        {
            //Changing cube's material when it is stacked
            _meshRenderer.sharedMaterial = material;
        }

        public void Despawn()
        {
            OnCollected();

            // Removing the cube from the spawnedCubes list when it is stacked
            SpawnManager.Instance.spawnedCubes.Remove(transform);
            
            DOVirtual.DelayedCall(.2f, () =>
            {
                _rigidbody.isKinematic = true;
            });
            
            DOVirtual.DelayedCall(1f, () =>
            {
                EZ_PoolManager.Despawn(transform);
                ResetValues();
            });
        }

        public void ChangeLayer(LayerMask layerMask)
        {
            gameObject.layer = layerMask;
        }

        private void ResetValues()
        {
            _rigidbody.isKinematic = false;
            //_meshRenderer.material.color = Random.ColorHSV(0f,1f,1f,1f,.5f,1f);
            _meshRenderer.sharedMaterial = sharedMaterials[0];
            gameObject.layer = LayerMask.NameToLayer("Default");
        }

        /// <summary>
        /// Get called when the cube is collected.
        /// </summary>
        private void OnCollected()
        {
            if(gameObject.layer == LayerMask.NameToLayer("PlayerScope"))
                EventManager.OnPlayerCollectCube();
            
            else if(gameObject.layer == LayerMask.NameToLayer("AIScope"))
                EventManager.OnAI_CollectCube();
        }

        private LayerMask CheckLayer()
        {
            return gameObject.layer;
        }
    }
}

