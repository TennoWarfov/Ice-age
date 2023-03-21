using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomjyEnternainment.IceAge.Animals
{
    public class RhinoStateHarassment : AnimalState
    {
        [SerializeField] private Rhino rhino;

        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float targetMoveSpeed;

        [SerializeField] private float attackDistance;
        [SerializeField] private float attackAngle;

        [SerializeField] private float attackCooldown;
        private float attackElapsedTime;

        public Transform TargetToHarass { get; set; }
        public override void Enter()
        {
            if (TargetToHarass != null)
            {
                rhino.Controller.Speed = speed;
                rhino.Controller.RotationSpeed = rotationSpeed;
                rhino.Controller.TargetMovingSpeed = targetMoveSpeed;

                rhino.GoToTargetPointInput.enabled = true;
            }
            else
            {
                Debug.LogError("Entering harassment state without target. Use TargetToHarass {get; set;}");
            }
        }

        public override void Exit()
        {
            rhino.GoToTargetPointInput.enabled = false;
        }

        public override void Tick()
        {
            rhino.Controller.Target.position = TargetToHarass.position;

            if(CanAttack)
            {
                rhino.Attack(this);
                attackElapsedTime = 0;
            }
        }

        private bool CanAttack
        {
            get
            {
                return attackElapsedTime >= attackCooldown && IsPositionValidForAttack;
            }
        }

        private bool IsPositionValidForAttack
        {
            get
            {
                var distance = Vector3.Distance(rhino.Tr.position, TargetToHarass.position);
                var isDistanceValid = distance <= attackDistance;

                if (!isDistanceValid)
                    return false;

                var headDirection = rhino.Controller.DirectionToRealTarget;
                var targetDirection = TargetToHarass.position - rhino.Tr.position;
                var angle = Vector3.Angle(headDirection, targetDirection);

                var isAngleToTargetValid = angle < attackAngle;

                return isAngleToTargetValid;
            }
        }

        private void Update()
        {
            attackElapsedTime += Time.deltaTime;
        }
    }
}