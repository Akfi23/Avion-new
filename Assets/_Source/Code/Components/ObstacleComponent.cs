using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Source.Code.Components
{
    public class ObstacleComponent : MonoBehaviour
    {
        [SerializeField] private int coinsPerEarn;
        [SerializeField] private bool isEarned;
        [SerializeField][EnumPaging] private ObstacleType type;

        public int CoinsPerEarn => coinsPerEarn;
        public bool IsEarned => isEarned;
        public ObstacleType Type => type;

        public bool EarnObstacle()
        {
            isEarned = true;
            return isEarned;
        }
    }
}
