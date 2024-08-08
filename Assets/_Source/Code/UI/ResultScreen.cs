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
        
        public TMP_Text DistanceText;
        public TMP_Text XPText;
        public TMP_Text CoinsText;

        public override void Subscribe()
        {
            ContinueButton.onClick.AddListener(() =>
            {
                Bootstrap.Instance.ChangeGameState(GameStateID.Game);
            });
        }
    }
}
