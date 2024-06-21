using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public InputReader InputReader;

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        this.transform.position = InputReader.MousePosition;
    }

}
