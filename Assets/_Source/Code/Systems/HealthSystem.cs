using _Source.Code.Components;
using _Source.Code.Signals;
using _Source.Code.UI;
using DG.Tweening;
using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class HealthSystem : GameSystemWithScreen<GameScreen>
    {
        private OnDamageEarnSignal _damageSignal;
        
        public override void OnInit()
        {
            _damageSignal = Supyrb.Signals.Get<OnDamageEarnSignal>();
            Supyrb.Signals.Get<OnTriggerEnter2DSignal>().AddListener(GetDamage);
            
            screen.HPCounterText.SetText(player.Health.ToString() + " HP");
        }

        private void GetDamage(Transform parent, Transform other)
        {
            if(!other.TryGetComponent(out ObstacleComponent obstacle)) return;
            if(obstacle.IsEarned) return;
            if(player.Health<1) return;
            
            player.Health--;
            
            screen.HPCounterText.SetText(player.Health.ToString() + " HP");
            screen.HPCounterText.transform.DOPunchScale(Vector3.one * 0.15f, 0.1f).SetEase(Ease.OutCubic);
            
            _damageSignal.Dispatch();
        }
    }
}
