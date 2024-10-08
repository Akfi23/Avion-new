using System;
using _Source.Code.Signals;
using _Source.Code.UI;
using DG.Tweening;
using Kuhpik;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Source.Code.Systems
{
    public class ShopSystem : GameSystemWithScreen<GameScreen>
    {
        public int RadarPrice;
        public int BodyPrice;
        public float RepairPriceMultiplier;

        public void OnApplicationFocus(bool hasFocus)
        {
            Bootstrap.Instance.SaveGame();
        }

        public override void OnInit()
        {
            Supyrb.Signals.Get<OnGamePhaseChangeSignal>().AddListener(OnGamePhaseChange);
            UpdateButtonStatus();
            
            screen.RadarButton.onClick.AddListener(BuyRadar);
            screen.BodyButton.onClick.AddListener(BuyBody);
            screen.RepairButton.onClick.AddListener(BuyRepair);
        }

        public override void OnStateEnter()
        {
            screen.RadarButton.image.rectTransform.DOAnchorPosX(20, 0.5f).SetEase(Ease.OutFlash);
            screen.BodyButton.image.rectTransform.DOAnchorPosX(20, 0.5f).SetEase(Ease.OutFlash);
            screen.RepairButton.image.rectTransform.DOAnchorPosX(20, 0.5f).SetEase(Ease.OutFlash);
            
            UpdateBoosterIcons();
        }

        private void UpdateBoosterIcons()
        {
            screen.BodyBoosterIcon.gameObject.SetActive(player.HaveBody);
            screen.RadarBoosterIcon.gameObject.SetActive(player.HaveRadar);
            screen.RepairBoosterIcon.gameObject.SetActive(player.Health >= 3);
        }

        public override void OnStateExit()
        {
            screen.RadarButton.image.rectTransform.DOAnchorPosX(-300, 0.5f).SetEase(Ease.InFlash);
            screen.BodyButton.image.rectTransform.DOAnchorPosX(-300, 0.5f).SetEase(Ease.InFlash);
            screen.RepairButton.image.rectTransform.DOAnchorPosX(-300, 0.5f).SetEase(Ease.InFlash);
        }

        private void UpdateButtonStatus()
        {
            screen.RadarButton.interactable = !player.HaveRadar  && RadarPrice <= player.Money;
            screen.BodyButton.interactable = !player.HaveBody && BodyPrice <= player.Money;
            screen.RepairButton.interactable = player.Health < 3 && RepairPriceMultiplier * player.Distance <= player.Money;
            
            UpdatePriceInfo();
            
            UpdateBoosterIcons();
        }

        private void UpdatePriceInfo()
        {
            screen.CoinsCounterText.SetText(player.Money.ToString() + " $");

            screen.RadarPrice.SetText(RadarPrice.ToString());
            screen.BodyPrice.SetText(BodyPrice.ToString());
            screen.RepairPrice.SetText(Mathf.RoundToInt(RepairPriceMultiplier * player.Distance).ToString());
        }

        private void BuyRadar()
        {
            if(player.Money<RadarPrice) return;

            player.Money -= RadarPrice;
            player.HaveRadar = true;
            
            UpdateButtonStatus();
        }

        private void BuyBody()
        {
            if(player.Money<BodyPrice) return;
            
            player.Money -= BodyPrice;
            player.HaveBody = true;
            player.HitToSkipBody = 2;
            
            screen.BodyCount.SetText(player.HitToSkipBody.ToString());
            
            UpdateButtonStatus();
        }

        private void BuyRepair()
        {
            var price = Mathf.RoundToInt(RepairPriceMultiplier * player.Distance * player.Money);
            
            if(player.Money<price) return;

            player.Money -= price;
            player.Health = 3;
            
            UpdateButtonStatus();
        }

        private void OnGamePhaseChange(GamePhase phase)
        {
            if (game.CurrentPhase == GamePhase.MainGame)
            {
                screen.ShopButton.image.rectTransform.DOAnchorPosY(300, 0.5f).SetEase(Ease.InFlash);
            }
            else
            {
                screen.ShopButton.image.rectTransform.DOAnchorPosY(-43, 0.5f).SetEase(Ease.OutFlash);
            }
            
            UpdateButtonStatus();
        }
    }
}
