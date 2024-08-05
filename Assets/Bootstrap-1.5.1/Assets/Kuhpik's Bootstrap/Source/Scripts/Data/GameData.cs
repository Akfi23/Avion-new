using System;
using System.Collections.Generic;
using _Source.Code.Components;

namespace Kuhpik
{
    /// <summary>
    /// Used to store game data. Change it the way you want.
    /// </summary>
    [Serializable]
    public class GameData
    {
        public GamePhase CurrentPhase = GamePhase.SafeZone;
        public AirplaneComponent Airplane;
        public List<ObstacleComponent> Obstacles = new List<ObstacleComponent>();
    }
}