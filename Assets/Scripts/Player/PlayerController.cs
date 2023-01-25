using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Survivor.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;

        private float horizontalInput;
        private float verticalInput;

        void Update()
        {
            GetInputs();
            Move();
        }

        private void GetInputs()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }

        private void Move()
        {
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime);
        }
    }
}