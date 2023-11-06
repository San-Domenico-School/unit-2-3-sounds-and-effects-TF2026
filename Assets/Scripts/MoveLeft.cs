using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30f;
    private float leftBound = -15f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
