using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomjyEnternainment.IceAge.Animals
{
    public class RhinoStateAttack : AnimalState
    {
        [SerializeField] private Rhino rhino;
        [SerializeField] private float attackAnimationLength;

        public AnimalState StateToReturn { get; set; }

        public override void Enter()
        {
            if (StateToReturn != null)
            {
                Attack();
            }
            else
            {
                Debug.LogError("Attacking without state to return. Use StateToReturn {get; set;}");
            }
        }

        public override void Exit()
        {
            StopCoroutine(returningCoroutine);
        }

        public override void Tick()
        {
            
        }

        private Coroutine returningCoroutine;
        private void Attack()
        {
            rhino.Animator.SetTrigger("Attack");
            returningCoroutine = StartCoroutine(ReturnToPrevStateAfterSeconds(attackAnimationLength));
        }

        private IEnumerator ReturnToPrevStateAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            rhino.StateMachine.SetNewState(StateToReturn);
        }
    }
}