using Survivor.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Survivor.Weapons
{
    public class WeaponManager : Singleton<WeaponManager>
    {
        private List<Weapon> weapons = new List<Weapon>();

        public void AddWeapon(Weapon weapon)
        {
            weapons.Add(weapon);
            weapon.transform.parent = transform;
            weapon.transform.localPosition = Vector3.zero;
        }

        private void Update()
        {
            UseWeapons();
        }

        private void UseWeapons()
        {
            foreach (Weapon weapon in weapons)
            {
                Transform closestEnemy = GetClosestEnemy();
                weapon.CheckAttack(closestEnemy);
            }
        }

        #region Range

        private List<GameObject> enemiesInRange = new List<GameObject>();

        public Transform GetClosestEnemy()
        {
            if (enemiesInRange.Count == 0) return null;

            float minDistance = float.MaxValue;
            Transform closestEnemy = null;

            foreach(GameObject enemy in enemiesInRange)
            {
                float distance = (enemy.transform.position - transform.position).magnitude;
                if(distance < minDistance)
                {
                    minDistance = distance;
                    closestEnemy = enemy.transform;
                }
            }

            return closestEnemy;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Enemy")
                enemiesInRange.Add(collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
                enemiesInRange.Remove(collision.gameObject);
        }

        #endregion
    }
}