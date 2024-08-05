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
                game.Airplane.transform.Translate(Vector2.up * Time.deltaTime * airplaneVelocity.y);
            }

            if (screen.MovementDownButton.IsPressed)
            {
                game.Airplane.transform.Translate(Vector2.up * Time.deltaTime * -airplaneVelocity.y);
            }
        }
    }
}
