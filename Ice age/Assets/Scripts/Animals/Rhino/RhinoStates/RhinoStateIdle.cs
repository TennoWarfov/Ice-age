using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace BomjyEnternainment.IceAge.Animals
{
    public class RhinoStateIdle : AnimalState
    {
        [SerializeField] private Rhino rhino;
        [SerializeField] private float minIdleTime;
        [SerializeField] private float maxIdleTime;

        [SerializeField] private float roamChance;

        private float rotationSpeed;

        private Coroutine coroutine;
        public override void Enter()
        {
            var idleTime = Random.Range(minIdleTime, maxIdleTime);
            coroutine = StartCoroutine(StopEatingAfterSeconds(idleTime));
            rhino.Controller.TurningRig.weight = 0;

            rotationSpeed = rhino.Controller.RotationSpeed;
            rhino.Controller.RotationSpeed = 0;
        }

        public override void Exit()
        {
            StopCoroutine(coroutine);
            rhino.Controller.TurningRig.weight = 1;
            rhino.Controller.RotationSpeed = rotationSpeed;
        }

        public override void Tick()
        {

        }

        private IEnumerator StopEatingAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);

            var num = Random.Range(1, 101);
            if (num < roamChance)
                rhino.Roam();
            else
                rhino.Eat();
        }
    }
}