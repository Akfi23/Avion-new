using System;
using _Source.Code.UI;
using Kuhpik;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Source.Code.Systems
{
    public class PlayerMovementSystem : GameSystemWithScreen<GameScreen>
    {
        [SerializeField] private Vector2 airplaneVelocity;
        
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
