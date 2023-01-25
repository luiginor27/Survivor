using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Survivor.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform level;
        [SerializeField] private Transform player;
        [SerializeField] private GameObject basicEnemyPrefab;

        [Header("Spawn Parameters")]
        [SerializeField] private int spawnCount;
        [SerializeField] private float spawnCooldown;
        [SerializeField] private float spawnMargin;


        private float leftLimit, rightLimit, topLimit, bottomLimit;

        private float counter;

        private void Start()
        {
            InitializeLimits();
        }

        private void InitializeLimits()
        {
            leftLimit = level.position.x - (level.localScale.x / 2) + spawnMargin;
            rightLimit = level.position.x + (level.localScale.x / 2) - spawnMargin;
            topLimit = level.position.y - (level.localScale.y / 2) + spawnMargin;
            bottomLimit = level.position.y + (level.localScale.y / 2) - spawnMargin;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, new Vector3(rightLimit * 2, bottomLimit * 2, 0));
        }

        void Update()
        {
            CheckSpawn();
        }

        private void CheckSpawn()
        {
            counter += Time.deltaTime;

            if (counter >= spawnCooldown)
            {
                SpawnEnemies();
                counter = 0;
            }
        }

        private void SpawnEnemies()
        {
            Vector3 spawnCenter = Vector3.zero;

            spawnCenter.x = Random.Range(leftLimit, rightLimit);
            spawnCenter.y = Random.Range(topLimit, bottomLimit);

            GameObject enemy = Instantiate(basicEnemyPrefab, spawnCenter, basicEnemyPrefab.transform.rotation);
            enemy.GetComponent<EnemyController>().Initialize(player);
        }
    }
}