using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomjyEnternainment.IceAge.Animals
{
    public class AnimalStateMachine : MonoBehaviour
    {
        [field: SerializeField] public AnimalState CurrentState { get; private set; }

        private void Start()
        {
            if (CurrentState != null)
                CurrentState.Enter();
        }

        public void SetNewState(AnimalState newState)
        {
            CurrentState.Exit();
            CurrentState.NotifiyExited();

            CurrentState = newState;

            newState.Enter();
            newState.NotifiyEntered();
        }

        private void Update()
        {
            CurrentState.Tick();
        }
    }
}