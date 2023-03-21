using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace BomjyEnternainment.IceAge.Animals
{
    public class RhinoStateEating : AnimalState
    {
        [SerializeField] private Rhino rhino;
        [SerializeField] private float minEatingTime;
        [SerializeField] private float maxEatingTime;

        private float rotationSpeed;

        private Coroutine coroutine;
        public override void Enter()
        {
            var eatingTime = Random.Range(minEatingTime, maxEatingTime);
            coroutine = StartCoroutine(StopEatingAfterSeconds(eatingTime));

            rotationSpeed = rhino.Controller.RotationSpeed;
            rhino.Controller.RotationSpeed = 0;

            rhino.Animator.SetBool("Eating", true);
            rhino.Controller.TurningRig.SetWeight(0f, 1f);
        }

        public override void Exit()
        {
            StopCoroutine(coroutine);

            rhino.Controller.RotationSpeed = rotationSpeed;

            rhino.Animator.SetBool("Eating", false);
            rhino.Controller.TurningRig.SetWeight(1f, 1f);
        }

        public override void Tick()
        {

        }

        private IEnumerator StopEatingAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            rhino.Idle();
        }
    }
}