using _Source.Code.Components;
using _Source.Code.Signals;
using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class ObstacleSpawnSystem : GameSystem
    {
        [SerializeField] private float[] spawnBounds;
        [SerializeField] private Vector2 timerBounds;
        [SerializeField] private ObstacleComponent[] obstaclePrefabs;

        private float _timer;
        private bool _isRun;
        private int _count;
        private ObstacleComponent _obstacle;

        public override void OnInit()
        {
            Supyrb.Signals.Get<OnGamePhaseChangeSignal>().AddListener(OnGamePhaseChange);
        }

        public override void OnUpdate()
        {
            if(!_isRun) return;

            _timer -= Time.deltaTime;
            
            if(_timer>0) return;

            _count = Random.Range(1, 3);
            
            if (_count == 1)
            {
                _obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)],
                    new Vector3(8, spawnBounds[Random.Range(0, spawnBounds.Length)], 0),Quaternion.identity);
                
                game.Obstacles.Add(_obstacle);
            }
            else
            {
                for (int i = 0; i < _count; i++)
                {
                    _obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)],
                        new Vector3(8, spawnBounds[Random.Range(0, spawnBounds.Length)], 0),Quaternion.identity);
                    
                    game.Obstacles.Add(_obstacle);
                }
            }
            
            _timer = Random.Range(timerBounds.x,timerBounds.y);
        }

        private void OnGamePhaseChange(GamePhase phase)
        {
            if (game.CurrentPhase == GamePhase.MainGame)
            {
                _timer = Random.Range(timerBounds.x,timerBounds.y);
                _isRun = true;
            }
            else
            {
                _isRun = false;
            }
        }
    }
}