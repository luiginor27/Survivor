using Survivor.Characters.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Survivor.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected float shootCooldown;

        [SerializeField] protected GameObject bulletPrefab;

        protected float counter;

        public void CheckAttack(Transform target)
        {
            counter += Time.deltaTime;
            if (counter >= shootCooldown)
            {
                Attack(target);
            }
        }

        protected abstract void Attack(Transform target);

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Player player = collision.gameObject.GetComponent<Player>();
                player.weaponManager.AddWeapon(this);
            }
        }
    }
}