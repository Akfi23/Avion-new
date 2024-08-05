using UnityEngine;

namespace _Source.Code.Components
{
    public class ObstacleComponent : MonoBehaviour
    {
        [SerializeField] private int coinsPerEarn;
        [SerializeField] private float xpPerEarn;
        [SerializeField] private bool isEarned;

        public int CoinsPerEarn => coinsPerEarn;
        public float XpPerEarn => xpPerEarn;
        public bool IsEarned => isEarned;

        public bool EarnObstacle()
        {
            isEarned = true;
            return isEarned;
        }
    }
}
