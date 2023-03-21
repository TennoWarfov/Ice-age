using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Irritability : MonoBehaviour
{
    [SerializeField] private float calmDownPerSecond;
    public UnityEvent<float> IrritabilityLevelChanged => irritabilityLevelChanged;
    [SerializeField] private UnityEvent<float> irritabilityLevelChanged;
    public float IrritabiltyLevel 
    { 
        get { return irritabilityLevel; } 
        private set 
        {
            bool valueChanged = irritabilityLevel != value;
            irritabilityLevel = Mathf.Clamp(value, 0f, 1f);

            if (valueChanged) 
                IrritabilityLevelChanged.Invoke(irritabilityLevel);
        } 
    }
    private float irritabilityLevel;

    public void Annoy(float value)
    {
        IrritabiltyLevel += value;
    }

    public void CalmDown(float value)
    {
        IrritabiltyLevel -= value;
    }

    private void Update()
    {
        IrritabiltyLevel -= calmDownPerSecond * Time.deltaTime;
    }
}
