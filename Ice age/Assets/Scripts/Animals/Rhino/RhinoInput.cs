using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomjyEnternainment.IceAge.Animals
{
    public class RhinoInput : MonoBehaviour
    {
        [SerializeField] private Rhino rhino;
        [SerializeField] private float movingDistance;

        private void Update()
        {
            Vector2 input = Vector2.zero;
            var distance = Vector3.Distance(rhino.Tr.position, rhino.Controller.Target.position);
            if(distance > movingDistance)
            {
                input.y = 1;
            }

            rhino.Controller.Input = input;
        }

        private void OnDisable()
        {
            rhino.Controller.Input = Vector2.zero;
        }
    }
}