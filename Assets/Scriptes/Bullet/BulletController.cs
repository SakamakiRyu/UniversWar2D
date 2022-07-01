using System;
using UnityEngine;

/// <summary>
/// 弾の物理挙動を管理するクラス
/// </summary>
[RequireComponent(typeof(Rigidbody2D), (typeof(CircleCollider2D)))]
public class BulletController : MonoBehaviour
{
    #region Field
    [SerializeField]
    private Rigidbody2D _rb2d;

    [SerializeField]
    private CircleCollider2D _collider;
    #endregion

    #region Unity Fucntion
    private void Start()
    {
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
        }
    }

    private void OnValidate()
    {
        if (_rb2d is null)
        {
            TryGetComponent(out _rb2d);
            _rb2d.gravityScale = 0f;
        }

        if (_collider is null)
        {
            TryGetComponent(out _collider);
            if (_collider)
            {
                _collider.isTrigger = true;
            }
        }
    }
    #endregion

    #region Public Fucntion
    /// <summary>
    /// 弾が発射された時の処理
    /// </summary>
    /// <param name="dir">発射の方向</param>
    public void Fire(Vector2 dir, float speed)
    {
        _rb2d.velocity = dir * speed;
    }
    #endregion
}
