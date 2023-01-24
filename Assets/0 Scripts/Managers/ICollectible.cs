using UnityEngine;

public interface ICollectible
{
   public bool isScoped { get; set; }
   public LayerMask LayerMask { get; set; }
   void ChangeColor(Material material);
   void Despawn();
   void ChangeLayer(LayerMask layerMask);
}
