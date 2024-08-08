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
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Color damageColor;
        public int CoinsPerEarn => coinsPerEarn;
        public bool IsEarned => isEarned;
        public ObstacleType Type => type;
        public SpriteRenderer SpriteRenderer => spriteRenderer;

        public bool EarnObstacle()
        {
            isEarned = true;
            return isEarned;
        }

        public void MakeDamagable()
        {
            type = ObstacleType.DamagedCloud;
            isEarned = false;
        }

        public void SetSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }

        public void ShowDamagableCloud()
        {
            if(type!= ObstacleType.DamagedCloud) return;
            
            spriteRenderer.color = damageColor;
        }
    }
}
