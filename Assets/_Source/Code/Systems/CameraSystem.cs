using _Source.Code.Signals;
using DG.Tweening;
using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class CameraSystem : GameSystem
    {
        [SerializeField] private Vector3 offset;
        [SerializeField] private Vector3 mainGameOffset;
        [SerializeField] private float cameraSpeed;
        
        public override void OnInit()
        {
            Supyrb.Signals.Get<OnGamePhaseChangeSignal>().AddListener(SetMainGameCameraPos);
            Supyrb.Signals.Get<OnDamageEarnSignal>().AddListener(ShakeCamera);
        }

        public override void OnLateUpdate()
        {
            if(game.CurrentPhase==GamePhase.MainGame) return;
            
            game.MainCamera.transform.position =  Vector3.Lerp(game.MainCamera.transform.position, game.Airplane.transform.position + offset,
                Time.deltaTime * cameraSpeed);
        }

        private void SetMainGameCameraPos(GamePhase phase)
        {
            if(phase == GamePhase.SafeZone) return;
            
            game.MainCamera.transform.DOMove(game.Airplane.transform.position + mainGameOffset, 1f);
        }

        private void ShakeCamera()
        {
            game.MainCamera.DOShakePosition(0.1f, (Vector3.right + Vector3.up)*0.25f);
        }
    }
}
