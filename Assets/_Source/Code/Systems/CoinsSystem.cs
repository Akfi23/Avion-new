using _Source.Code.UI;
using DG.Tweening;
using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class CoinsSystem : GameSystemWithScreen<GameScreen>
    {
        public override void OnInit()
        {
            screen.CoinsCounterText.SetText(player.Money.ToString() + " $");
        }

        public override void OnUpdate()
        {
            if(game.CurrentPhase != GamePhase.MainGame) return;
            
            foreach (var obstacle in game.Obstacles)
            {
                if(obstacle==null) continue;
                if(obstacle.IsEarned) continue;
                if(obstacle.transform.position.x>-2) continue;

                player.Money += obstacle.CoinsPerEarn;
                obstacle.EarnObstacle();
                
                if(DOTween.IsTweening(screen.CoinsCounterText.transform)) continue;
                
                screen.CoinsCounterText.transform.DOPunchScale(Vector3.one * 0.05f, 0.15f).SetEase(Ease.OutFlash);
            }
            
            screen.CoinsCounterText.SetText(player.Money.ToString() + " $");
            game.CoinsPerRound = player.Money;
        }
    }
}
