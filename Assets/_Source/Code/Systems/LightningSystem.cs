using _Source.Code.Signals;
using _Source.Code.UI;
using DG.Tweening;
using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class LightningSystem : GameSystemWithScreen<GameScreen>
    {
        [SerializeField] private Vector3 targetPos;
        [SerializeField] private Vector2 timerBounds;
        [SerializeField] private float strikeChance;
        
        private OnTriggerEnter2DSignal _enterSignal;
        
        private float _timer;
        private bool _isRun;
        
        public override void OnInit()
        {
            _enterSignal = Supyrb.Signals.Get<OnTriggerEnter2DSignal>();
            Supyrb.Signals.Get<OnGamePhaseChangeSignal>().AddListener(OnGamePhaseChange);
        }

        public override void OnStateEnter()
        {
            _timer = Random.Range(timerBounds.x, timerBounds.y);
            _isRun = true;
        }

        public override void OnUpdate()
        {
            if(game.CurrentPhase != GamePhase.MainGame) return;
            if(!_isRun) return;
            
            _timer -= Time.deltaTime;
            
            if(_timer>0) return;

            _isRun = false;

            game.Lightning.transform.position = new Vector3(10,20,0);
            
            game.Lightning.transform.DOMove(targetPos, 1f).OnComplete(() =>
            {
                if (CanHit())
                {
                    game.Lightning.LightFX.Play();

                    if (game.CurrentPhase == GamePhase.MainGame)
                    {
                        _enterSignal.Dispatch(game.Airplane.transform,game.Lightning.transform);

                        if (player.HaveBody)
                        {
                            game.Airplane.SpriteRenderer.DOColor(Color.yellow, 0.3f).SetLoops(2, LoopType.Yoyo);
                        }
                    }
                }

                game.Lightning.transform.DOMove(new Vector3(-17,12), 1f).SetDelay(1f).OnComplete(() =>
                {
                    _timer = Random.Range(timerBounds.x, timerBounds.y);
                    _isRun = true;
                });
            });
        }
        
        private void OnGamePhaseChange(GamePhase phase)
        {
            if (game.CurrentPhase == GamePhase.MainGame)
            {
                _timer = Random.Range(timerBounds.x, timerBounds.y);
                _isRun = true;
            }
        }

        private bool CanHit()
        {
            return Random.Range(0, 100) < strikeChance;
        }
    }
}