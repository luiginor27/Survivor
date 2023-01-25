using Survivor.Characters.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Survivor.Weapons
{
    public class Saw : MonoBehaviour
    {
        [SerializeField] private float hitDamage;
        [SerializeField] private float hitCooldown;

        private List<Enemy> enemiesInRange = new List<Enemy>();
        private float counter;

        private void Update()
        {
            counter += Time.deltaTime;
            CheckHitEnemies();
        }

        private void CheckHitEnemies()
        {
            if (counter >= hitCooldown && enemiesInRange.Count > 0)
            {
                HitEnemiesInRange();
                counter = 0;
            }
        }

        private void HitEnemiesInRange()
        {
            int index = 0;
            for (int i = 0; i < enemiesInRange.Count; i++)
            {
                Enemy enemy = enemiesInRange[index];

                if (enemy == null) enemiesInRange.RemoveAt(index);
                else
                {
                    enemy.health.ReceiveDamage(hitDamage);
                    Debug.Log("Hit");
                    index++;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.health.ReceiveDamage(hitDamage);
                Debug.Log("HitEnter");

                enemiesInRange.Add(enemy);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemiesInRange.Remove(enemy);
            }
        }
    }
}