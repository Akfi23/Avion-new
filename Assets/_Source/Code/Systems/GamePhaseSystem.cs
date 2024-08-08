using _Source.Code.Signals;
using _Source.Code.UI;
using DG.Tweening;
using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class GamePhaseSystem : GameSystemWithScreen<GameScreen>
    {
        private OnGamePhaseChangeSignal _gamePhaseChangeSignal;
        
        public override void OnInit()
        {
            _gamePhaseChangeSignal=Supyrb.Signals.Get<OnGamePhaseChangeSignal>();
            Supyrb.Signals.Get<OnTriggerExit2DSignal>().AddListener(ChangeGameState);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            game.CurrentPhase = GamePhase.SafeZone;
        }

        private void ChangeGameState(Transform parent, Transform other)
        {
            if(!other.TryGetComponent(out ZoneBorderComponent zoneBorder)) return;
            
            game.CurrentPhase = game.Airplane.transform.position.y > other.transform.position.y
                ? GamePhase.MainGame : GamePhase.SafeZone;
            
            screen.Info.rectTransform.DOAnchorPosX(game.CurrentPhase== GamePhase.MainGame ? -1250:55, 1f);
            
            Debug.Log("PHASE " + game.CurrentPhase);
            _gamePhaseChangeSignal.Dispatch(game.CurrentPhase);
        }
    }
}
