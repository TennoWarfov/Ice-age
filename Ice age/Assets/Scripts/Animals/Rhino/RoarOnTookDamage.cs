using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomjyEnternainment.IceAge.Animals
{
    public class RoarOnTookDamage : MonoBehaviour
    {
        [SerializeField] private Rhino rhino;
        [SerializeField] private float roarChance;

        private void OnEnable()
        {
            rhino.Health.OnTookDamage.AddListener(TryStun);
        }

        private void OnDisable()
        {
            rhino.Health.OnTookDamage.RemoveListener(TryStun);
        }

        private void TryStun()
        {
            var value = Random.Range(1, 101);

            if (value <= roarChance)
            {
                rhino.Roar();
            }
        }
    }
}