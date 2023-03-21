using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BomjyEnternainment.IceAge.Animals
{
    public abstract class AnimalState : MonoBehaviour
    {
        public UnityEvent OnEnter => onEnter;
        [SerializeField] private UnityEvent onEnter;
        public UnityEvent OnExit => onExit;
        [SerializeField] private UnityEvent onExit;

        public void NotifiyEntered()
        {
            OnEnter.Invoke();
        }

        public void NotifiyExited()
        {
            OnExit.Invoke();
        }

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Tick();
    }
}
