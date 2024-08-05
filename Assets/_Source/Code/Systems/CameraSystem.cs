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
        private Camera _camera;
        
        public override void OnInit()
        {
            _camera = Camera.main;
            Supyrb.Signals.Get<OnGamePhaseChangeSignal>().AddListener(SetMainGameCameraPos);
        }

        public override void OnLateUpdate()
        {
            if(game.CurrentPhase==GamePhase.MainGame) return;
            
            _camera.transform.position =  Vector3.Lerp(_camera.transform.position, game.Airplane.transform.position + offset,
                Time.deltaTime * cameraSpeed);
        }

        private void SetMainGameCameraPos(GamePhase phase)
        {
            if(phase == GamePhase.SafeZone) return;
            
            _camera.transform.DOMove(game.Airplane.transform.position + mainGameOffset, 1f);
        }
    }
}
