using UnityEngine;

public class PlayerCombat
{
    private int _bulletCounter;
    public int PlayerHealth = 3;
    public void ShootBullet(GameObject firePoint, GameObject[] bullets)
    {
        bullets[_bulletCounter].transform.position = firePoint.transform.position;
        bullets[_bulletCounter].SetActive(true);
        if (_bulletCounter < bullets.Length)
        {
            _bulletCounter++;
        }

        if (_bulletCounter == bullets.Length)
        {
            _bulletCounter = 0;
        }
    }
}
