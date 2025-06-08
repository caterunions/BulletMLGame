using UnityEngine;
using BulletMLLib;
using System.Collections.Generic;

public class CombatManager : MonoBehaviour, IBulletManager
{
    [SerializeField]
    private UnityBullet _bulletPrefab;

    private UnityBullet _topBullet;

    private Dictionary<Bullet, UnityBullet> _bullets = new Dictionary<Bullet, UnityBullet>();

    private BulletPattern Pattern { get
        {
            if (_pattern == null)
            {
                _pattern = new BulletPattern();
            }
            return _pattern;
        } 
    }
    private BulletPattern _pattern;

    private void Start()
    {
        Pattern.ParseXML("Assets/testpattern.xml");
        Debug.Log(Pattern.RootNode);
        Bullet top = new Bullet(this);
        _topBullet = Instantiate(_bulletPrefab);
        
        top.InitTopNode(Pattern.RootNode);

        _topBullet.Initialize(top);

        _bullets.Add(top, _topBullet);
    }

    public Bullet CreateBullet(Bullet source, bool top)
    {
        Bullet bullet = new Bullet(this);
        UnityBullet unityBullet = Instantiate(_bulletPrefab);
        unityBullet.Initialize(bullet);

        _bullets.Add(bullet, unityBullet);

        return bullet;
    }

    public Vector2 PlayerPosition(Bullet targettedBullet)
    {
        return Vector2.zero;
    }

    public void RemoveBullet(Bullet deadBullet)
    {
        Destroy(_bullets[deadBullet]);
        _bullets.Remove(deadBullet);
    }

    public void Trigger(Bullet source, string name)
    {
        throw new System.NotImplementedException();
    }
}
