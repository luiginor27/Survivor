using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Survivor.Characters.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float speed;

        [SerializeField] private float combatDistance;
        [SerializeField] private float hitStrength;
        [SerializeField] private float hitCooldown;

        private Transform player;

        private enum EnemyState
        {
            CHASE, COMBAT, WAIT
        }

        private EnemyState enemyState;

        private float counter;

        public void Initialize(Transform player)
        {
            this.player = player;
            enemyState = EnemyState.CHASE;
        }

        private void Update()
        {
            counter += Time.deltaTime;

            switch (enemyState)
            {
                case EnemyState.CHASE:
                    ChasePlayer(); break;

                case EnemyState.COMBAT:
                    HitPlayer(); break;
            }

            CheckState();
        }

        private void ChasePlayer()
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            transform.Translate(direction * speed * Time.deltaTime);
        }

        private void HitPlayer()
        {
            if (counter >= hitCooldown)
            {
                Debug.Log("Hit");
                player.GetComponent<HealthComponent>().ReceiveDamage(hitStrength);
                counter = 0;
            }
        }

        private void CheckState()
        {
            if (player == null)
            {
                enemyState = EnemyState.WAIT;
            }
            else
            {
                float playerDistance = (player.position - transform.position).magnitude;

                if (playerDistance <= combatDistance)
                {
                    enemyState = EnemyState.COMBAT;
                }
                else
                {
                    enemyState = EnemyState.CHASE;
                }
            }
        }

    }
}