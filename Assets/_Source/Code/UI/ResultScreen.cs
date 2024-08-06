using DG.Tweening;
using Kuhpik;
using TMPro;
using UnityEngine.UI;

namespace _Source.Code.UI
{
    public class ResultScreen : UIScreen
    {
        public Image Panel;
        public Button ContinueButton;
        public TMP_Text LoseText;

        public override void Subscribe()
        {
            ContinueButton.onClick.AddListener(() =>
            {
                Bootstrap.Instance.ChangeGameState(GameStateID.Game);
            });
        }

        public override void Open()
        {
            base.Open();

            Panel.DOFade(0.7f, 1f).SetDelay(1.5f).OnComplete(() => { ContinueButton.gameObject.SetActive(true); });
            LoseText.DOFade(1, 1f).SetDelay(1.5f);
        }

        public override void Close()
        {
            base.Close();

            Panel.DOFade(0, 0.05f);
            LoseText.DOFade(0, 0.05f);
            ContinueButton.gameObject.SetActive(false);
        }
    }
}
