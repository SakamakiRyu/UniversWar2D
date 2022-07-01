using UnityEngine;

/// <summary>
/// 弾の基底クラス
/// </summary>
[RequireComponent(typeof(Rigidbody2D), (typeof(CircleCollider2D)))]
public abstract class BulletBase : MonoBehaviour
{
    #region Field
    [SerializeField]
    protected BulletDate.Type _type;

    [SerializeField]
    protected BulletDate _bulletDate;

    [SerializeField]
    protected Rigidbody2D _rb2d;
    #endregion

    #region Abstract Fucntion
    /// <summary>
    /// 弾が発射された時の処理
    /// </summary>
    /// <param name="dir">発射の方向</param>
    public abstract void Fired(Vector2 dir);

    /// <summary>
    /// 弾があたった際の処理
    /// </summary>
    protected abstract void OnHit();
    #endregion

    #region Unity Fucntion
    protected virtual void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            OnHit();
        }
    }

    private void OnValidate()
    {
        if (_rb2d is null)
        {
            TryGetComponent(out _rb2d);
        }
    }
    #endregion
}
