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
        public Image XPPanel;
        public Image HPPanel;
        public Image CoinsPanel;
        public Image DistancePanel;
        
        [Space(40)]
        public TMP_Text DistanceCounterText;
        public TMP_Text XPCounterText;
        public TMP_Text CoinsCounterText;
        public Image[] HPHearts;

        [Space(40)]
        public Button RadarButton;
        public Button BodyButton;
        public Button RepairButton;

        [Space(10)]
        public TMP_Text RadarPrice;
        public TMP_Text BodyPrice;
        public TMP_Text RepairPrice;
        public TMP_Text BodyCount;

        [Space(40)]
        public Image BodyBoosterIcon;
        public Image RepairBoosterIcon;
        public Image RadarBoosterIcon;

        [Space(10)]
        public Button ShopButton;
        public Image ShopPanel;
        public Button CloseShopButton;

        [Space(40)] 
        public Image Alimiter;
        
        public override void Subscribe()
        {
            ShopPanel.gameObject.SetActive(false);

            CloseShopButton.onClick.AddListener(() =>
            {
                ShopPanel.gameObject.SetActive(false);
            });
            
            ShopButton.onClick.AddListener(() =>
            {
                ShopPanel.gameObject.SetActive(true);
            });
        }

        public void SetHearts(int hp)
        {
            for (int i = 0; i < HPHearts.Length; i++)
            {
                    HPHearts[i].gameObject.SetActive(i<hp);
            }
        }
    }
}