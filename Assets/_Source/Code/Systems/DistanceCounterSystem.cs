using _Source.Code.Signals;
using _Source.Code.UI;
using DG.Tweening;
using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class DistanceCounterSystem : GameSystemWithScreen<GameScreen>
    {
        public float distanceMultiplier;
        public float xpPerDistance;
        public float mileStone;
        
        private float _tempDistance;
        
        public override void OnInit()
        {
            Supyrb.Signals.Get<OnGamePhaseChangeSignal>().AddListener(OnGamePhaseChange);
            screen.DistanceCounterText.SetText(player.Distance.ToString("0.00") + " Miles");
            screen.XPCounterText.SetText(player.XP.ToString() + " XP");
        }

        public override void OnUpdate()
        {
            if(game.CurrentPhase==GamePhase.SafeZone) return;
            if(game.Airplane.RB.bodyType != RigidbodyType2D.Kinematic) return;
            
            player.Distance += Time.deltaTime * distanceMultiplier;
            screen.DistanceCounterText.SetText(player.Distance.ToString("0.00") + " Miles");
            
            _tempDistance += Time.deltaTime * distanceMultiplier;

            game.XPPerRound = player.XP;
            game.DistancePerRound = player.Distance;
            
            if(_tempDistance<mileStone) return;

            player.XP+=xpPerDistance;
            
            screen.XPCounterText.SetText(player.XP.ToString() + " XP");
            screen.XPCounterText.transform.DOPunchScale(Vector3.one * 0.05f, 0.15f).SetEase(Ease.OutFlash);
            screen.DistanceCounterText.transform.DOPunchScale(Vector3.one * 0.05f, 0.15f).SetEase(Ease.OutFlash);

            _tempDistance = 0;
        }

        private void OnGamePhaseChange(GamePhase phase)
        {
            if (game.CurrentPhase == GamePhase.MainGame)
            {
                screen.DistancePanel.transform.DOScale(Vector3.one , 0.25f).SetEase(Ease.OutFlash);
            }
            else
            {
                screen.DistancePanel.transform.DOScale(Vector3.one * 0.5f , 0.25f).SetEase(Ease.InFlash);
            }
        }
    }
}
