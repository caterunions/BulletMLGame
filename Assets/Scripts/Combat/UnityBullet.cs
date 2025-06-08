using UnityEngine;
using BulletMLLib;

public class UnityBullet : MonoBehaviour
{
    private Bullet _bullet;

    public void Initialize(Bullet bullet)
    {
        _bullet = bullet;
    }

    private void Update()
    {
        transform.position = new Vector2(_bullet.X, _bullet.Y);
    }
}
