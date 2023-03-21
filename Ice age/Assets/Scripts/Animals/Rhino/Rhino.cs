using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BomjyEnternainment.IceAge.Animals
{
    public class Rhino : Animal
    {
        public RhinoInput GoToTargetPointInput => goToTargetPointInput;
        [Header("Rhino")]
        [SerializeField] private RhinoInput goToTargetPointInput;
        [SerializeField] private Irritability Irritability => irritability;
        [SerializeField] private Irritability irritability;
        public Health Health => health;
        [SerializeField] private Health health;

        [Header("States")]
        [SerializeField] private RhinoStateIdle idle;
        [SerializeField] private RhinoStateStun stun;
        [SerializeField] private RhinoStateRoar roar;
        [SerializeField] private RhinoStateEating eating;
        [SerializeField] protected RhinoStateAttack attack;
        [SerializeField] protected RhinoStateRunning running;
        [SerializeField] protected RhinoStateHarassment harassment;

        [Header("Irritability")]
        [SerializeField] private float harassmentIrritability;
        [SerializeField] private float roamingIrritability;

        public Transform CurrentTarget { get; set; }
        [Header("Trash")]
        public Transform tempTarget;

        public void Eat()
        {
            StateMachine.SetNewState(eating);
        }

        public void Attack(AnimalState stateToReturn)
        {
            attack.StateToReturn = stateToReturn;
            StateMachine.SetNewState(attack);
        }

        public void Harassment(Transform target)
        {
            harassment.TargetToHarass = target;
            StateMachine.SetNewState(harassment);
        }

        public void Idle()
        {
            StateMachine.SetNewState(idle);
        }

        public void Stun()
        {
            if (StateMachine.CurrentState != stun)
            {
                stun.PrevState = StateMachine.CurrentState;
                StateMachine.SetNewState(stun);
            }
        }

        public void Roar()
        {
            if (StateMachine.CurrentState != roar)
            {
                roar.PrevState = StateMachine.CurrentState;
                StateMachine.SetNewState(roar);
            }
        }

        private void Start()
        {
            Irritability.IrritabilityLevelChanged.AddListener(IrritabilityChanged);
        }

        public bool ReactToIrritability { get { return StateMachine.CurrentState != stun && StateMachine.CurrentState != roar; } }

        private void IrritabilityChanged(float irritability)
        {
            if (ReactToIrritability)
            {
                if (irritability > harassmentIrritability)
                {
                    if (StateMachine.CurrentState != harassment)
                        Harassment(tempTarget);
                }
                else if (irritability <= roamingIrritability)
                {
                    if (StateMachine.CurrentState == harassment)
                        Idle();
                }
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Harassment(tempTarget);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Roam();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Die();
            }
        }
    }
}