using _Source.Code.Signals;
using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class GamePhaseSystem : GameSystem
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
            
            Debug.Log("PHASE " + game.CurrentPhase);
            _gamePhaseChangeSignal.Dispatch(game.CurrentPhase);
        }
    }
}
