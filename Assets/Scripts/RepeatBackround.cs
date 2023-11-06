using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackround : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth = 56.4f;

    // Start is called before the first frame update
    private void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
