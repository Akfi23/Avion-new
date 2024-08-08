using _Source.Code.UI;
using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class PlayerMovementSystem : GameSystemWithScreen<GameScreen>
    {
        [SerializeField] private float airplaneVelocity;
        public float yPos;

        public override void OnStateEnter()
        {
            game.Airplane.RB.bodyType = RigidbodyType2D.Kinematic;
            game.Airplane.RB.velocity=Vector2.zero;
            game.Airplane.RB.angularVelocity = 0;
            game.Airplane.Collider.enabled = true;

            game.Airplane.transform.rotation = Quaternion.Euler(Vector3.zero);
            game.Airplane.transform.position = new Vector3(-1.5f, -2.5f, 0f);
        }

        public override void OnUpdate()
        {
            if (screen.MovementTopButton.IsPressed)
            {
                if(game.Airplane.transform.position.y +(Time.deltaTime * airplaneVelocity) >10 ) return;
                game.Airplane.transform.Translate(Vector2.up * Time.deltaTime * airplaneVelocity);
            }

            if (screen.MovementDownButton.IsPressed)
            {
                if(game.Airplane.transform.position.y +(Time.deltaTime * -airplaneVelocity) <-2.5f ) return;

                game.Airplane.transform.Translate(Vector2.up * Time.deltaTime * -airplaneVelocity);
            }
            
            if (game.Airplane.transform.position.y < 5)
            {
                yPos = (game.Airplane.transform.position.y - (-2.5f)) / (10 - (-2.5f));
                yPos /= 2f;
            }
            else
            {
                yPos = (0.3f + (game.Airplane.transform.position.y - 5) / (10 - 5) * (1 - 0.3f));
            }
            
            screen.Alimiter.rectTransform.anchoredPosition = new Vector2(0, DenormalizeAlimiterPos());
        }

        private float DenormalizeAlimiterPos()
        {
            return Mathf.Clamp01(yPos) * 600 - 300;
        }
    }
}
