using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 弾の管理をするクラス
/// </summary>
public class BulletController : MonoBehaviour
{
    [SerializeField]
    private GameObject _muzzle;

    private BulletBase[] _Bullets;

    public void OnFire(InputAction.CallbackContext context)
    {

    }
}
