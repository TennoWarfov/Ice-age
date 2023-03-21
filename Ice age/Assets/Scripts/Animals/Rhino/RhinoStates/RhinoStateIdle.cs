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
            rhino.Controller.TurningRig.SetWeight(0f, 1f);

            rotationSpeed = rhino.Controller.RotationSpeed;
            rhino.Controller.RotationSpeed = 0;
        }

        public override void Exit()
        {
            StopCoroutine(coroutine);
            rhino.Controller.TurningRig.SetWeight(1f, 1f);
            rhino.Controller.RotationSpeed = rotationSpeed;
        }

        public override void Tick()
        {

        }

        private IEnumerator StopEatingAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);

            var num = Random.Range(1, 101);

            Debug.Log(num + " / " + roamChance);

            if (num < roamChance)
                rhino.Roam();
            else
                rhino.Eat();
        }
    }
}