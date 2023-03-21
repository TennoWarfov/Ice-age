using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomjyEnternainment.IceAge.Animals
{
    public class AnnoyOnHit : MonoBehaviour
    {
        [SerializeField] private HitBox hitBox;
        [SerializeField] private Irritability irritability;
        [SerializeField] private float annoymentValue;

        private void OnEnable()
        {
            hitBox.OnHit.AddListener(Annoy);
        }

        private void OnDisable()
        {
            hitBox.OnHit.RemoveListener(Annoy);
        }

        private void Annoy()
        {
            irritability.Annoy(annoymentValue);
        }
    }
}