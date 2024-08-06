using _Source.Code.UI;
using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class PlayerMovementSystem : GameSystemWithScreen<GameScreen>
    {
        [SerializeField] private Vector2 airplaneVelocity;

        public override void OnStateEnter()
        {
            game.Airplane.RB.bodyType = RigidbodyType2D.Kinematic;
            game.Airplane.RB.velocity=Vector2.zero;
            game.Airplane.RB.angularVelocity = 0;
            game.Airplane.Collider.enabled = true;

            game.Airplane.transform.rotation = Quaternion.Euler(Vector3.zero);
            game.Airplane.transform.position = new Vector3(-1.5f, -4f, 0f);
        }

        public override void OnUpdate()
        {
            if (screen.MovementTopButton.IsPressed)
            {
                if(game.Airplane.transform.position.y +(Time.deltaTime * airplaneVelocity.y) >10 ) return;
                game.Airplane.transform.Translate(Vector2.up * Time.deltaTime * airplaneVelocity.y);
            }

            if (screen.MovementDownButton.IsPressed)
            {
                if(game.Airplane.transform.position.y +(Time.deltaTime * -airplaneVelocity.y) <-4 ) return;

                game.Airplane.transform.Translate(Vector2.up * Time.deltaTime * -airplaneVelocity.y);
            }
        }
    }
}
