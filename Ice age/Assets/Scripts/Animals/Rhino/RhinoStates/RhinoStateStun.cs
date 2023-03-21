using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomjyEnternainment.IceAge.Animals
{
    public class RhinoStateStun : AnimalState
    {
        [SerializeField] private Rhino rhino;
        [SerializeField] private float stunTime;

        private float movingSpeed;
        private float rotationSpeed;

        public AnimalState PrevState { get; set; }
        public override void Enter()
        {
            if (PrevState == null)
                Debug.LogError("Entering stun without state to return. Use PrevState {get; set;} ");
            else
            {
                Stun();
            }
        }

        public override void Exit()
        {
            rhino.Controller.Speed = movingSpeed;
            rhino.Controller.RotationSpeed = rotationSpeed;

            StopCoroutine(returningCoroutine);
        }

        public override void Tick()
        {
            
        }

        private Coroutine returningCoroutine;
        private void Stun()
        {
            rhino.Animator.SetTrigger("Hit");
            returningCoroutine = StartCoroutine(ReturnToPrevStateAfterSeconds(stunTime));

            movingSpeed = rhino.Controller.Speed;
            rotationSpeed = rhino.Controller.RotationSpeed;
            rhino.Controller.Speed = 0;
            rhino.Controller.RotationSpeed = 0;
        }

        private IEnumerator ReturnToPrevStateAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            rhino.StateMachine.SetNewState(PrevState);
        }
    }
}
