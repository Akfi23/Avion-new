using System;
using UnityEngine;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;

namespace Kuhpik
{
    /// <summary>
    /// Used to store player's data. Change it the way you want.
    /// </summary>
    [Serializable]
    public class PlayerData
    {
        public int Health=3;
        public int Money;
        public float XP;
        public float Distance;
        public bool HaveRadar;
        public bool HaveBody;
        public int HitToSkipBody;

        public int TutorialStep;
    }
}