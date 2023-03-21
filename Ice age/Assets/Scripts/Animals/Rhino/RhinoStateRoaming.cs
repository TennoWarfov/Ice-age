using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomjyEnternainment.IceAge.Animals
{
    public class RhinoStateRoaming : AnimalStateRoaming
    {
        [SerializeField] private Rhino rhino;
        [SerializeField] private float roamingRadius;
        [SerializeField] private float roamingSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float targetMovingSpeed;

        private Coroutine coroutine;
        public override void Enter()
        {
            var x = Random.Range(-roamingRadius, roamingRadius);
            var y = 0;
            var z = Random.Range(-roamingRadius, roamingRadius);

            var roamingPoint = rhino.Tr.position + new Vector3(x, y, z);

            rhino.Controller.Speed = roamingSpeed;
            rhino.Controller.RotationSpeed = rotationSpeed;
            rhino.Controller.TargetMovingSpeed = targetMovingSpeed;
            rhino.Controller.Target.position = roamingPoint;

            rhino.GoToTargetPointInput.enabled = true;

            coroutine = StartCoroutine(EndRoamAfterSeconds(3));
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