using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace BomjyEnternainment.IceAge.Animals
{
    public class RigWeightController : MonoBehaviour
    {
        [SerializeField] private Rig rig;

        private Coroutine weightMovingCoroutine;
        public void SetWeight(float targetValue, float speed)
        {
            if (weightMovingCoroutine != null)
                StopCoroutine(weightMovingCoroutine);

            weightMovingCoroutine = StartCoroutine(MoveWeight(targetValue, speed));
        }

        private IEnumerator MoveWeight(float targetValue, float speed)
        {
            var i = 0f;
            var initialWeight = rig.weight;
            while(i != 1)
            {
                i = Mathf.MoveTowards(i, 1, speed * Time.deltaTime);
                rig.weight = Mathf.Lerp(initialWeight, targetValue, i);
                yield return null;
            }
        }
    }
}