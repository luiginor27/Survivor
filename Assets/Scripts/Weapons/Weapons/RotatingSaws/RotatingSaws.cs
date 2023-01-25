using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Survivor.Weapons
{
    public class RotatingSaws : Weapon
    {
        [SerializeField] private float rotatingSpeed;
        [SerializeField] private float range;

        private bool initialized;

        protected override void Attack(Transform target)
        {
            if (!initialized) SpawnSaws();

            transform.Rotate(Vector3.forward * rotatingSpeed * Time.deltaTime);
        }

        private void SpawnSaws()
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(range, 0), bulletPrefab.transform.rotation, transform);
            Instantiate(bulletPrefab, transform.position - new Vector3(range, 0), bulletPrefab.transform.rotation, transform);
            Instantiate(bulletPrefab, transform.position + new Vector3(0, range), bulletPrefab.transform.rotation, transform);
            Instantiate(bulletPrefab, transform.position - new Vector3(0, range), bulletPrefab.transform.rotation, transform);
            initialized = true;
        }
    }
}