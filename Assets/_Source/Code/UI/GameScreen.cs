using Kuhpik;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Code.UI
{
    public class GameScreen : UIScreen
    {
        public MovementButtonHandler MovementTopButton;
        public MovementButtonHandler MovementDownButton;
        
        [Space(40)]
        public TMP_Text DistanceCounterText;
        public TMP_Text XPCounterText;
        public TMP_Text CoinsCounterText;
        public TMP_Text HPCounterText;

        [Space(40)]
        public Button RadarButton;
        public Button BodyButton;
        public Button RepairButton;

        [Space(10)]
        public TMP_Text RadarPrice;
        public TMP_Text BodyPrice;
        public TMP_Text RepairPrice;
    }
}