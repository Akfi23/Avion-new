using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class ObstacleMovementSystem : GameSystem
    {
        [SerializeField] private float obstacleSpeed;

        public override void OnUpdate()
        {
            foreach (var obstacle in game.Obstacles)
            {
                if(obstacle==null) continue;
                
                obstacle.transform.Translate(-Vector3.right * Time.deltaTime * obstacleSpeed);
            }
            
            foreach (var obstacle in game.Obstacles)
            {
                if (obstacle!=null &&obstacle.transform.position.x <= -6)
                {
                    DestroyImmediate(obstacle.gameObject);
                    
                    if (game.Obstacles.Remove(obstacle))
                    {
                        break;

                    }
                }
            }
        }
    }
}
