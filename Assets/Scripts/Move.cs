using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RotationPosition
{
    public Transform position;
    public float rotationAmount = -90.0f;
}

public class Move : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] Transform[] LastPositionsTransforms;
    [SerializeField] Vector3[] LastPositions;
    [SerializeField] float objectSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] RotationPosition[] rotationPositions;

    public int nextPosIndex, reversepositionindex;
    public Transform nextPos;
    Vector3 lastpos;
    bool shouldDestroy = false;
    public bool isMoving = false, isreversemoving = false;
    bool iseversemoving = false;
    Vector3 originalPosition;
    Quaternion originalRotation;
    public List<Transform> lastposition;

    void Start()
    {
        for (int i = 0; i < LastPositionsTransforms.Length; i++)
        {
            LastPositions[i] = LastPositionsTransforms[i].position;
        }
        LastPositions[0] = transform.position;
        lastposition.Add(transform);
        nextPosIndex = 0;
        nextPos = Positions[nextPosIndex];

        reversepositionindex = 0;
        lastpos = LastPositions[reversepositionindex];

        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void OnMouseDown()
    {
        if (!isMoving)
        {
            isMoving = true;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            MoveGameObject();
        }
        //if (iseversemoving)
        //{
        //    MoveBackwardGameObject();
        //}
    }

    void MoveGameObject()
    {

        if (shouldDestroy)
        {
            //Destroy(gameObject);
            return;
        }

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

            // SavePosition(transform); // Save the current position before moving to the next one

            if (isreversemoving)
                nextPosIndex = (nextPosIndex - 1) % Positions.Length;   
            else
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
        else
        {

            Vector3 moveDirection = (nextPos.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, nextPos.position, objectSpeed * Time.deltaTime);
        }
    }
    //void MoveBackwardGameObject()
    //{


    //    if (transform.position == lastpos)
    //    {

    //        foreach (var rotationPos in rotationPositions)
    //        {
    //            if (lastpos == rotationPos.position.position)
    //            {
    //                Rotate(rotationPos.rotationAmount);
    //                return;
    //            }
    //        }

    //        // SavePosition(transform); // Save the current position before moving to the next one

    //        reversepositionindex = (reversepositionindex - 1) % LastPositions.Length;



    //            lastpos = LastPositions[reversepositionindex];

    //    }
    //    else
    //    {

    //        Vector3 moveDirection = (lastpos - transform.position).normalized;
    //        transform.position = Vector3.MoveTowards(transform.position, lastpos, objectSpeed * Time.deltaTime);
    //    }
    //}

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
                reversepositionindex--;
                lastposition.Insert(0, Positions[nextPosIndex]);
                nextPos = Positions[nextPosIndex];
            }
        }
    }

    void reversemove()
    {
        //for (int i = reversepositionindex; i >= 0; i--)
        //{
        //    Debug.Log("Hy");
        //    if (i != 0)
        //    {
        //        Vector3 targetPosition = lastposition[reversepositionindex - 1].position;
        //        transform.position = Vector3.MoveTowards(transform.position, targetPosition, objectSpeed * Time.deltaTime);
        //    }

        //}
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Car"))
        {
            // Reset the game object's position and rotation
            //transform.position = originalPosition;
            //transform.rotation = originalRotation;
            //iseversemoving = true;
            //lastpos = lastposition[1];
            //nextPosIndex = (nextPosIndex - 1) % Positions.Length;
            isreversemoving =true;
            //isMoving = false;
            reversepositionindex = nextPosIndex;
            nextPosIndex = 0;
            nextPos = Positions[nextPosIndex];
        }
    }
}

