using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BomjyEnternainment.IceAge.Animals
{
    public class Animal : MonoBehaviour
    {
        public Rigidbody Rb { get { return rb; } }
        [Header("Components")]
        [SerializeField] private Rigidbody rb;
        public Transform Tr { get { return tr; } }
        [SerializeField] private Transform tr;
        public Animator Animator { get { return animator; } }
        [SerializeField] private Animator animator;

        public AnimalController Controller { get { return controller; } }
        [SerializeField] private AnimalController controller;
        public AnimalStateMachine StateMachine => stateMachine;
        [SerializeField] private AnimalStateMachine stateMachine;

        public bool IsDead { get; set; }
        public virtual AnimalStateRoaming Roaming { get { return roaming; } }
        [Header("States")]
        [SerializeField] protected AnimalStateRoaming roaming;
        public virtual AnimalStateDeath Death { get { return death; } }
        [SerializeField] protected AnimalStateDeath death;

        public virtual void Roam()
        {
            StateMachine.SetNewState(Roaming);
        }

        public void Die()
        {
            IsDead = true;
            StateMachine.SetNewState(Death);
        }
    }
}