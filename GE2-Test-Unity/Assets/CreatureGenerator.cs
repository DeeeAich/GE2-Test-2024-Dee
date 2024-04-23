using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreatureGenerator : MonoBehaviour
{

    [SerializeField] float length = 1, frequency = 0.5f, startAngle = 1f, baseSize = 0.5f, multiplier = 4f;

    [SerializeField] GameObject boidFront, boidFollower;
    Boid boid;

    bool paused = true;

    private void Awake()
    {




    }

    private void Update()
    {

        float sizeIncrease = Mathf.Sin(Time.deltaTime * frequency) * multiplier * baseSize;

        float objectScale = sizeIncrease * (sizeIncrease < 0 ? -1 : 1) + baseSize;

        boidFront.transform.localScale = new Vector3(objectScale, objectScale, objectScale);

        if (Input.GetKeyDown(KeyCode.P) && paused)
        {
            boid.StartBoid();
            paused = false;
        }

    }

    private void OnDrawGizmos()
    {
        
    }

}
