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
        }

        public override void OnStateEnter()
        {
            screen.SetHearts(player.Health);
        }

        public override void OnStateExit()
        {
            player.Health = 3;
        }
        

        private void GetDamage(Transform parent, Transform other)
        {
            if(!other.TryGetComponent(out ObstacleComponent obstacle)) return;
            if(obstacle.IsEarned) return;
            if(player.Health<1) return;
            if(obstacle.Type == ObstacleType.Cloud) return;

            if (obstacle.Type == ObstacleType.Lightning)
            {
                if (player.HaveBody)
                {
                    player.HitToSkipBody--;

                    screen.BodyCount.SetText(player.HitToSkipBody.ToString());

                    if (player.HitToSkipBody < 1)
                    {
                        player.HaveBody = false;
                        screen.BodyBoosterIcon.gameObject.SetActive(false);
                    }
                    
                    return;
                }
            }
            
            obstacle.ShowDamagableCloud();
            
            player.Health--;
            
            screen.SetHearts(player.Health);
            screen.HPPanel.transform.DOPunchScale(Vector3.one * 0.15f, 0.1f).SetEase(Ease.OutCubic);
            
            _damageSignal.Dispatch();

            if (player.Health < 1)
            {
                game.Airplane.RB.bodyType = RigidbodyType2D.Dynamic;
                game.Airplane.RB.AddForce(Vector2.right * 100);
                game.Airplane.RB.AddTorque(13);
                game.Airplane.Collider.enabled = false;
                
                Bootstrap.Instance.ChangeGameState(GameStateID.Result);
            }
        }
    }
}
