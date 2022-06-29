using UnityEngine;

/// <summary>
/// 弾の基底クラス
/// </summary>
[RequireComponent(typeof(Rigidbody2D), (typeof(CircleCollider2D)))]
public abstract class BulletBase : MonoBehaviour
{
    [SerializeField]
    protected float _bulletSpeed;

    [SerializeField]
    protected Rigidbody2D _rb2d;

    /// <summary>
    /// 弾を発射する
    /// </summary>
    /// <param name="dir">発射の方向</param>
    public abstract void Fire(Vector2 dir);

    /// <summary>
    /// 弾があった際の処理
    /// </summary>
    protected abstract void OnHit();

    protected abstract void OnBecameInvisible();

    protected virtual void OnTriggerEnter2D()
    {
        OnHit();
    }
}
