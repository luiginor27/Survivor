using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Survivor.Weapons
{
    public class Gun : Weapon
    {
        protected override void Attack(Transform target)
        {
            if (target == null) return;
            
            GameObject bullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            bullet.GetComponent<Bullet>().SetTarget(target);
            counter = 0;
        }
    }
}