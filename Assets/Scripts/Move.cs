using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class RotationPosition
{
    public Transform position;
    public float rotationAmount = -90.0f;
}

public class Move : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float objectSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] RotationPosition[] rotationPositions;

    int nextPosIndex;
    Transform nextPos;
    bool shouldDestroy = false;
    bool isMoving = false;
    Vector3 originalPosition;
    Quaternion originalRotation;

    void Start()
    {
        nextPosIndex = 0;
        nextPos = Positions[nextPosIndex];

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
    }

    void MoveGameObject()
    {
        if (shouldDestroy)
        {
            Destroy(gameObject);
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

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("Car"))
        {

            transform.position = originalPosition;
            transform.rotation = originalRotation;
            isMoving = false; 
            nextPosIndex = 0; 
            nextPos = Positions[nextPosIndex];
        }
    }
}
