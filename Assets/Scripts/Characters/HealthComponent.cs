using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Survivor.Characters
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private float initialHealth;

        public float Health { private set; get; }

        private SpriteRenderer spriteRenderer;
        private Color originalColor;

        private void Start()
        {
            Health = initialHealth;
            spriteRenderer = GetComponent<SpriteRenderer>();
            originalColor = spriteRenderer.color;
        }

        public void ReceiveDamage(float value)
        {
            StartCoroutine(ReceiveDamageCoroutine(value));
        }

        private IEnumerator ReceiveDamageCoroutine(float value)
        {
            Health -= value;

            if (Health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                SetColor(Color.red);
                yield return new WaitForSeconds(0.5f);
                SetColor(originalColor);
            }
        }

        private void SetColor(Color color) { spriteRenderer.color = color; }
    }
}