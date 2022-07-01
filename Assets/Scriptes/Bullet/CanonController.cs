using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 砲台の管理をするコンポーネント
/// 現状、砲台は3つ。
/// </summary>
public class CanonController : MonoBehaviour
{
    #region Define
    /// <summary>
    /// 砲台
    /// </summary>
    [System.Serializable]
    public class Canon
    {
        public string Name;
        public BulletsDate.Type Type;
        public BulletsDate.Size Size;
        public Transform Muzzle;
    }

    private const int MAIN_CANON_INDEX = 0;
    private const int SUB1_CANON_INDEX = 1;
    private const int SUB2_CANON_INDEX = 2;
    #endregion

    #region Field
    [SerializeField]
    private BulletsDate _bulletsDate;

    [SerializeField]
    private BulletController _bulletPrefab;

    [SerializeField]
    private Canon[] CanonsArray;
    #endregion

    /// <summary>
    /// InputSystemに呼ばれる処理(Fire1)
    /// </summary>
    /// <param name="context"></param>
    public void OnFire1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Fire(MAIN_CANON_INDEX);
        }
    }

    /// <summary>
    /// InputSystemに呼ばれる処理(Fire2)
    /// </summary>
    /// <param name="context"></param>
    public void OnFire2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Fire(SUB1_CANON_INDEX);
        }
    }

    /// <summary>
    /// InputSystemに呼ばれる処理(Fire3)
    /// </summary>
    /// <param name="context"></param>
    public void OnFire3(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Fire(SUB2_CANON_INDEX);
        }
    }

    /// <summary>
    /// 弾を発射する
    /// </summary>
    /// <param name="CanonIndex">CanonのIndex</param>
    private void Fire(int CanonIndex)
    {
        // 発射する弾の情報
        var bullet = CanonsArray[CanonIndex];
        // 弾のデータを取得
        var date = _bulletsDate.GetBulletDate(bullet.Type, bullet.Size);

        if (date is not null)
        {
            // 弾を生成
            var go = Instantiate(_bulletPrefab, bullet.Muzzle.position, Quaternion.identity).GetComponent<BulletController>();
            // 弾を発射
            go.Fire(Vector2.right, date.Speed);
        }
    }

    private void OnValidate()
    {

    }
}
