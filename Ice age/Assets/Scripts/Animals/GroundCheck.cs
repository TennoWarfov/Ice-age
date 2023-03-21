using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomjyEnternainment.IceAge.Animals
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private Animal animal;

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.collider);
            if (collision.collider.CompareTag("Ground"))
            {
                animal.Controller.IsGrounded = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.CompareTag("Ground"))
            {
                animal.Controller.IsGrounded = false;
            }
        }
    }
}