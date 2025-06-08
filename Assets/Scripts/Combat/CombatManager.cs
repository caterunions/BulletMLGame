using UnityEngine;
using BulletMLLib;

public class CombatManager : MonoBehaviour, IBulletManager
{
    [SerializeField]
    private UnityBullet _bulletPrefab;

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
    }

    public Bullet CreateBullet(Bullet source, bool top)
    {
        throw new System.NotImplementedException();
    }

    public Vector2 PlayerPosition(Bullet targettedBullet)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveBullet(Bullet deadBullet)
    {
        throw new System.NotImplementedException();
    }

    public void Trigger(Bullet source, string name)
    {
        throw new System.NotImplementedException();
    }
}
