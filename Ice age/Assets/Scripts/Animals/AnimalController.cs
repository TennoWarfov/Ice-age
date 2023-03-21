using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace BomjyEnternainment.IceAge.Animals
{
    public class AnimalController : MonoBehaviour
    {
        [SerializeField] private Animal animal;

        public float Speed { get { return speed; } set { speed = value; } }
        [Header("Parameters")]
        [SerializeField] private float speed;
        public float RotationSpeed { get { return rotationSpeed; } set { rotationSpeed = value; } }
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float inputMovingSpeed;

        [Header("Animations")]
        [SerializeField] private Transform turningRigTarget;
        [SerializeField] private float radius;
        public RigWeightController TurningRig => turningRig;
        [SerializeField] private RigWeightController turningRig;
        public float TargetMovingSpeed { get { return targetMovingSpeed; } set { targetMovingSpeed = value; } }
        [SerializeField] private float targetMovingSpeed;

        [SerializeField] private float zConstraint;
        [SerializeField] private float xConstraint;

        public bool IsGrounded { get; set; }

        private float initialY;

        public Transform Target { get; private set; }
        private Transform realTarget;

        private int movingSpeedHash = Animator.StringToHash("MovingSpeed");

        public Vector2 Input { get; set; }

        private void Awake()
        {
            initialY = animal.Tr.InverseTransformPoint(turningRigTarget.position).y;

            Target = new GameObject().transform;
            Target.name = "RhinoeEthalonTarget";

            realTarget = new GameObject().transform;
            realTarget.name = "RhinoRealTarget";
        }

        private void FixedUpdate()
        {
            MoveRealTarget();
            PoseTarget();
            if (IsGrounded)
            {
                Move(speed, Input.y);
                Rotations();
            }

            animal.Animator.SetFloat(movingSpeedHash, animal.Rb.velocity.magnitude);
        }

        private void MoveRealTarget()
        {
            realTarget.position = Vector3.Lerp(realTarget.position, Target.position, targetMovingSpeed);
        }

        [SerializeField] private float parabolaMultiplier = 2f;
        [SerializeField] private float parabolaIncrease = 1.5f;
        private void PoseTarget()
        {
            var direction = animal.Tr.InverseTransformPoint(realTarget.position);
            var pos = direction.normalized * radius;


            pos.x = Mathf.Clamp(pos.x, -xConstraint, xConstraint);
            pos.y = initialY;


            if (pos.z < zConstraint) {
                var x = pos.x / radius;
                pos.z = Mathf.Cos(x) * radius;
            }

            turningRigTarget.position = animal.Tr.TransformPoint(pos);
        }

        private void OnDrawGizmos()
        {
            //DrawTargetPoint();
        }

        private void DrawTargetPoint()
        {
            Gizmos.color = Color.black;
            //Gizmos.DrawSphere(turningRigTarget.position, 0.1f);

            Vector3[] points = new Vector3[50];

            var x = -1f;
            for(int i = 0; i < points.Length; i++)
            {
                points[i] = new Vector3(x, 0, Mathf.Cos(x));
                x += 1f / 25f;
            }

            for(int i = 0; i < points.Length -1; i++)
            {
                Gizmos.DrawLine(points[i], points[i + 1]);
            }
        }

        public Vector3 DirectionToRealTarget { get { return realTarget.position - animal.Tr.position; } }
        private void Move(float speed, float multiplier)
        {
            animal.Rb.velocity = DirectionToRealTarget.normalized * speed * multiplier;
        }

        private void Rotations()
        {
            var targetPos = realTarget.position;
            targetPos.y = 0;
            var trPos = animal.Tr.position;
            trPos.y = 0;
            var targetRot = Quaternion.LookRotation(targetPos - trPos);
            animal.Tr.rotation = Quaternion.Lerp(animal.Tr.rotation, targetRot, rotationSpeed);
        }
    }
}