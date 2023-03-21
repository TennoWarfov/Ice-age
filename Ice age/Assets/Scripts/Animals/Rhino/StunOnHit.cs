using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomjyEnternainment.IceAge.Animals
{
    public class StunOnHit : MonoBehaviour
    {
        [SerializeField] private Rhino rhino;
        [SerializeField] private HitBox hitBox;
        [SerializeField] private float stunChance;

        private void OnEnable()
        {
            hitBox.OnHit.AddListener(TryStun);
        }

        private void OnDisable()
        {
            hitBox.OnHit.RemoveListener(TryStun);
        }

        private void TryStun()
        {
            var value = Random.Range(1, 101);

            if (value <= stunChance)
            {
                rhino.Stun();
            }
        }
    }
}