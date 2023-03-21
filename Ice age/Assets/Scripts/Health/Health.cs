using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BomjyEnternainment.IceAge
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth;

        private void Start()
        {
            HP = maxHealth;
        }

        public UnityEvent OnTookDamage => onTookDamage;
        [SerializeField] private UnityEvent onTookDamage;

        public UnityEvent OnDeath => onDeath;
        [SerializeField] private UnityEvent onDeath;

        public float HP { get { return hp; } private set { hp = value; } }
        private float hp;

        public void TakeDamage(float value)
        {
            HP -= value;

            OnTookDamage.Invoke();

            if (HP <= 0)
                OnDeath.Invoke();
        }
    }
}