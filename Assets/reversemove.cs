using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reversemove : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float objectSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] RotationPosition[] rotationPositions;

    public int nextPosIndex;
    public Transform nextPos;

    bool shouldDestroy = false;
    public bool isMoving = false;
    Quaternion originalRotation;



    void Start()
    {
       
        nextPosIndex = 0;
        nextPos = Positions[nextPosIndex];
        originalRotation = transform.rotation;



    }

  

    void Update()
    {
        if (isMoving)
        {
            ReverseMoveGameObject();
        }
    }

    public void ReverseMoveGameObject()
    {

       

        if (transform.position == nextPos.position)
        {

            foreach (var rotationPos in rotationPositions)
            {
                if (nextPos == rotationPos.position)
                {
                    Rotate(rotationPos.rotationAmount);
                    return;
                }
            }

           

            nextPosIndex = (nextPosIndex + 1) % Positions.Length;


            if (nextPosIndex == 0)
            {
                /*shouldDestroy = true;*/
                isMoving = false;
                nextPos = Positions[nextPosIndex];
            }
            else
            {

                nextPos = Positions[nextPosIndex];
            }
        }
        else
        {

            Vector3 moveDirection = (nextPos.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, nextPos.position, objectSpeed * Time.deltaTime);
        }
    }
   
    void Rotate(float amount)
    {
        Quaternion targetRotation = Quaternion.Euler(0, 0, amount);
        float step = rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);

        if (transform.rotation == targetRotation)
        {


            nextPosIndex = (nextPosIndex + 1) % Positions.Length;

            if (nextPosIndex == 0)
            {
                shouldDestroy = true;
            }
            else
            {
               
                nextPos = Positions[nextPosIndex];
            }
        }
    }



   
}
