using _Source.Code.Signals;
using _Source.Code.UI;
using DG.Tweening;
using Kuhpik;

namespace _Source.Code.Systems
{
    public class TutorialSystem : GameSystemWithScreen<GameScreen>
    {
        public override void OnInit()
        {
            screen.ContinueTutorialButton.onClick.AddListener(() =>
            {
                player.TutorialStep++;
                screen.TutorialPanel.gameObject.SetActive(false);
                Supyrb.Signals.Get<OnTutorialStepEarnSignal>().Dispatch();
            });

            Supyrb.Signals.Get<OnTutorialStepEarnSignal>().AddListener(HandleTutorStep);
        }

        public override void OnStateEnter()
        {
            HandleTutorStep();
        }

        private void HandleTutorStep()
        {
            if (player.TutorialStep == 0)
            {
                game.Airplane.transform.DOMoveY(8, 3f).OnComplete(() =>
                {
                    screen.TutorialPanel.gameObject.SetActive(true);
                });
            }
            else if(player.TutorialStep == 1)
            {
                if(player.Money<1) return;

                screen.TutorailText.SetText("You are a cool pilot and successfully avoid obstacles. But you may encounter a dangerous cloud and it will cause you damage.");
                screen.TutorialPanel.gameObject.SetActive(true);
            }
            else if(player.TutorialStep == 2)
            {
                game.Airplane.transform.DOMoveY(-2.5f, 3f).OnComplete(() =>
                {
                    screen.TutorailText.SetText("By avoiding dangerous obstacles you can earn coins, and the longer you fly you will get XP.");
                    screen.TutorialPanel.gameObject.SetActive(true);
                });
            }
            else if(player.TutorialStep == 3)
            {
                screen.TutorailText.SetText("As you earn coins and XP, you can spend on boosters to upgrade your aircraft! Check out the boosters in our store.");
                screen.TutorialPanel.gameObject.SetActive(true);
            }
            else if(player.TutorialStep == 4)
            {
                screen.ShopPanel.gameObject.SetActive(true);
                player.TutorialStep++;
            }
        }
    }
}
