using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

public class CreatureGenerator : MonoBehaviour
{

    [SerializeField] float length = 1, frequency = 0.5f, startAngle = 1f, baseSize = 0.5f, multiplier = 4f;

    [SerializeField] GameObject boidFront, boidFollower;
    Boid boid;

    bool paused = true;

    public int testAngle;

    private void Awake()
    {

        float zScale = 0;

        for(int i = 0; i < length; i++)
        {
            GameObject boidPiece;


            float sizeChange = multiplier * baseSize * Mathf.Sin(frequency * ((i + 1) / length) * Mathf.PI * 360);

            float size = sizeChange + baseSize;

            if (size < 0)
                size *= -1;

            if (i == 0)
            {

                boidPiece = GameObject.Instantiate(boidFront, transform.position, transform.rotation, null);

                boid = boidPiece.GetComponent<Boid>();

                zScale += size / 2;

                boid.GetComponent<SpineAnimator>().bones = new GameObject[(int)length-1];
                
            }
            else
            {
                boidPiece = GameObject.Instantiate(boidFollower, transform.position + transform.forward * (-zScale - size/2), transform.rotation, null);

                zScale += size;

                boid.GetComponent<SpineAnimator>().bones.SetValue(boidPiece, i - 1);
            }

            boidPiece.transform.localScale = new Vector3(size, size, size);

        }


    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.P) && paused)
        {
            boid.StartBoid();
            paused = false;
        }

    }

    private void OnDrawGizmos()
    {
        float zScale = 0;

        for (int i = 0; i < length; i++)
        {

            float sizeChange = multiplier * baseSize * Mathf.Sin(frequency * ((i + 1) / length) * 90);

            float size = sizeChange + baseSize;

            if(size < 0)
                size *= -1;

            if (i != 0)
                zScale += size / 2;

            Gizmos.DrawCube(transform.position + transform.forward * -zScale, new Vector3(size, size, size));

            
            zScale += size/2;
      


        }
    }

}
