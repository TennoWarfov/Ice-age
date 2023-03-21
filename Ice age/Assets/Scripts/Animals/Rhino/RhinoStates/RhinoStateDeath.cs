using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomjyEnternainment.IceAge.Animals
{
    public class RhinoStateDeath : AnimalStateDeath
    {
        [SerializeField] private Rhino rhino;

        public override void Enter()
        {
            rhino.Controller.enabled = false;
            rhino.Rb.isKinematic = true;
            rhino.Controller.TurningRig.weight = 0;
            rhino.Animator.SetTrigger("Death");
        }
    }
}