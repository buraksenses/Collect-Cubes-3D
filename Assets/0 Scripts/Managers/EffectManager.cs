using DG.Tweening;
using EZ_Pooling;
using UnityEngine;

namespace CollectCubes.Managers
{
    public class EffectManager : Singleton<EffectManager>
    {
        [SerializeField] private Transform AIExplosionEffect;
        [SerializeField] private Transform playerExplosionEffect;

        public void SpawnAIExplosionEffect(Vector3 pos,Quaternion rot)
        {
            var spawnedEffect = EZ_PoolManager.Spawn(AIExplosionEffect, pos, rot);
            DOVirtual.DelayedCall(1, () =>
            {
                EZ_PoolManager.Despawn(spawnedEffect);
            });
        }
        
        public void SpawnPlayerExplosionEffect(Vector3 pos,Quaternion rot)
        {
            var spawnedEffect = EZ_PoolManager.Spawn(playerExplosionEffect, pos, rot);
            DOVirtual.DelayedCall(1, () =>
            {
                EZ_PoolManager.Despawn(spawnedEffect);
            });
        }
    }
}

