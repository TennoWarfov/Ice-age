using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BomjyEnternainment.IceAge
{
    public class HitBox : MonoBehaviour
    {
        [SerializeField] private Health health;
        [SerializeField] private float damageMultiplier = 1;

        public UnityEvent OnHit => onHit;
        [SerializeField] private UnityEvent onHit = new UnityEvent();

        public void Hit(float damage)
        {
            health.TakeDamage(damage * damageMultiplier);

            OnHit.Invoke();
        }
    }
}