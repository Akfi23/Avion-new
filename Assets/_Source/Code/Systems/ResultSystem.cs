using _Source.Code.UI;
using Kuhpik;

namespace _Source.Code.Systems
{
    public class ResultSystem : GameSystemWithScreen<ResultScreen>
    {
        public override void OnStateEnter()
        {
            screen.XPText.SetText(game.XPPerRound.ToString("0.00"));
            screen.CoinsText.SetText("+ " + game.CoinsPerRound);
            screen.DistanceText.SetText(game.DistancePerRound.ToString());

            game.CoinsPerRound = 0;
            game.XPPerRound = 0;
            game.DistancePerRound = 0;
        }
    }
}
