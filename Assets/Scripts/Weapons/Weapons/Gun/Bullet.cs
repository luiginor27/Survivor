using Survivor.Characters.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Survivor.Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float damage;

        private Transform target;

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        private void Update()
        {
            ChaseTarget();
        }

        private void ChaseTarget()
        {
            if (target == null) WeaponManager.Instance.GetClosestEnemy();
            else
            {
                Vector3 direction = target.position - transform.position;
                direction.Normalize();

                transform.Translate(direction * speed * Time.deltaTime);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.health.ReceiveDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}