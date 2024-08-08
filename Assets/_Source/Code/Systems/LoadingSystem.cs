using _Source.Code.Components;
using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class LoadingSystem : GameSystem
    {
        public override void OnInit()
        {
            game.Airplane = FindObjectOfType<AirplaneComponent>();
            game.Lightning = FindObjectOfType<LightningComponent>();
            game.MainCamera = Camera.main;
        }
    }
}
