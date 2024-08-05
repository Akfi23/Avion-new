using _Source.Code.Components;
using _Source.Code.Signals;
using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class HealthSystem : GameSystem
    {
        public override void OnInit()
        {
            Supyrb.Signals.Get<OnTriggerEnter2DSignal>().AddListener(GetDamage);
        }

        private void GetDamage(Transform parent, Transform other)
        {
            if(!other.TryGetComponent(out ObstacleComponent obstacle)) return;

            if(player.Health<1) return;
            
            player.Health--;
        }
    }
}
