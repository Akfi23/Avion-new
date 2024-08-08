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
        [SerializeField] private Sprite[] cloudSprites;
        [SerializeField] private int damageCloudChance;

        private float _timer;
        private int _count;
        private ObstacleComponent _obstacle;

        public override void OnInit()
        {
            Supyrb.Signals.Get<OnGamePhaseChangeSignal>().AddListener(OnGamePhaseChange);
            Supyrb.Signals.Get<OnTutorialStepEarnSignal>().AddListener(SpawnCloudForTutorial);
        }

        public override void OnUpdate()
        {
            if(player.TutorialStep<4) return;
            
            if(game.CurrentPhase==GamePhase.SafeZone) return;

            _timer -= Time.deltaTime;
            
            if(_timer>0) return;

            _count = Random.Range(1, 3);
            
            if (_count == 1)
            {
                _obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)],
                    new Vector3(12, spawnBounds[Random.Range(0, spawnBounds.Length)], 0),Quaternion.identity);
                
                game.Obstacles.Add(_obstacle);
                
                game.Obstacles[^1].SetSprite(cloudSprites[Random.Range(0,cloudSprites.Length)]);

                if (Random.Range(0, 100) < damageCloudChance)
                {
                    game.Obstacles[^1].MakeDamagable();
                }
                
                if(player.HaveRadar)
                    game.Obstacles[^1].ShowDamagableCloud();
            }
            else
            {
                int posIndex = Random.Range(0, spawnBounds.Length);
                
                for (int i = 0; i < _count; i++)
                {
                    if (i != 0)
                    {
                        int newPosIndex = Random.Range(0, spawnBounds.Length);

                        while (posIndex == newPosIndex)
                        {
                            newPosIndex = Random.Range(0, spawnBounds.Length);
                        }

                        posIndex = newPosIndex;
                    }
                    
                    _obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)],
                        new Vector3(12, spawnBounds[posIndex], 0),Quaternion.identity);

                    game.Obstacles.Add(_obstacle);
                    
                    game.Obstacles[^1].SetSprite(cloudSprites[Random.Range(0,cloudSprites.Length)]);

                    if (Random.Range(0, 100) < damageCloudChance)
                    {
                        game.Obstacles[^1].MakeDamagable();
                    }
                    
                    if(player.HaveRadar)
                        game.Obstacles[^1].ShowDamagableCloud();
                }
            }
            
            _timer = Random.Range(timerBounds.x,timerBounds.y);
        }

        private void OnGamePhaseChange(GamePhase phase)
        {
            if (game.CurrentPhase == GamePhase.MainGame)
            {
                _timer = Random.Range(0.25f,1f);
            }
        }

        private void SpawnCloudForTutorial()
        {
            _obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)],
                new Vector3(12, spawnBounds[Random.Range(0, spawnBounds.Length)], 0),Quaternion.identity);
                
            game.Obstacles.Add(_obstacle);
                
            game.Obstacles[^1].SetSprite(cloudSprites[Random.Range(0,cloudSprites.Length)]);
            
            game.Obstacles[^1].MakeDamagable();
        }
    }
}
