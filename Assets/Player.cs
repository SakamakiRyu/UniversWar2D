using UnityEngine;

namespace UniversWar
{
    [RequireComponent(typeof(PlayerStatus))]
    public class Player : MonoBehaviour, IHitable
    {
        [SerializeField]
        private PlayerStatus _status;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // 弾が当たった時の処理
            if (collision.collider.TryGetComponent<Bullet>(out var bullet))
            {
                OnHit();
            }
        }

        public void OnHit()
        {
            _status.AddDamage();
        }
    }
}
