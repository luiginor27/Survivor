using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Survivor
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private float initialHealth;

        public float Health { private set; get; }

        private void Start()
        {
            Health = initialHealth;
        }

        public void ReceiveDamage(float value)
        {
            Health -= value;
            if(Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}