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
        public int Health;
        public int Money;
        public int XP;
        public bool HaveRadar;
        public bool HaveBody;
    }
}