using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MammothPlayerInput : MonoBehaviour
{
    [SerializeField] private MammothController mammoth;

    private void Update()
    {
        var input = new Vector2();

        if (Input.GetKey(KeyCode.A))
        {
            input.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            input.x = 1;
        }
        else
        {
            input.x = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            input.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            input.y = -1;
        }
        else
        {
            input.y = 0;
        }

        mammoth.Input = input;
    }
}
