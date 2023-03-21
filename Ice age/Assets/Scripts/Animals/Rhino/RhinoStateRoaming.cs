using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomjyEnternainment.IceAge.Animals
{
    public class RhinoStateRoaming : AnimalStateRoaming
    {
        [SerializeField] private Rhino rhino;
        [SerializeField] private float roamingMinRadius;
        [SerializeField] private float roamingMaxRadius;

        [SerializeField] private float roamingMinTime;
        [SerializeField] private float roamingMaxTime;

        [SerializeField] private float roamingSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float targetMovingSpeed;

        private Coroutine coroutine;
        public override void Enter()
        {
            var x = GetRandomNumInRadius();
            var y = 0;
            var z = GetRandomNumInRadius();

            var roamingPoint = rhino.Tr.position + new Vector3(x, y, z);

            rhino.Controller.Speed = roamingSpeed;
            rhino.Controller.RotationSpeed = rotationSpeed;
            rhino.Controller.TargetMovingSpeed = targetMovingSpeed;
            rhino.Controller.Target.position = roamingPoint;

            rhino.GoToTargetPointInput.enabled = true;

            float roamingTime = Random.Range(roamingMinTime, roamingMaxTime);
            coroutine = StartCoroutine(EndRoamAfterSeconds(roamingTime));
        }

        private float GetRandomNumInRadius()
        {
            var a = Random.Range(roamingMinRadius, roamingMaxRadius);
            var mirror = Random.Range(0, 2);

            if (mirror == 1)
                a = -a;

            return a;
        }

        public override void Exit()
        {
            rhino.GoToTargetPointInput.enabled = false;
            StopCoroutine(coroutine);
        }

        public override void Tick()
        {
            
        }

        private IEnumerator EndRoamAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            rhino.Eat();
        }
    }
}