using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public float moveDistance = 50f; // Distance to move up or down
    public float moveSpeed = 5f; // Speed of elevator movement
    private int buttonPressCount = 0; // Track the number of button presses
    private bool isMoving = false; // Flag to prevent multiple button presses
    private bool isMovingUp = true; // Flag to track the direction of movement
    private int consecutivePressCount = 0; // Track the consecutive presses for the same direction
    public GameObject buttonObject; // Reference to the button object

    // Method to activate the elevator
    public void ActivateElevator()
    {
        if (!isMoving)
        {
            isMoving = true;
            // Increment the button press count
            buttonPressCount++;

            // Calculate the direction based on the current state of movement
            int direction = isMovingUp ? -1 : 1;

            // Calculate the target position
            Vector3 targetPosition = transform.position + Vector3.up * direction * moveDistance;

            // Move the elevator towards the target position with speed
            StartCoroutine(MoveElevator(targetPosition));

            // Increment the consecutive press count for the current direction
            consecutivePressCount++;

            // If reached two consecutive presses for the same direction, toggle the direction
            if (consecutivePressCount >= 2)
            {
                isMovingUp = !isMovingUp;
                consecutivePressCount = 0; // Reset the consecutive press count
            }
        }
    }

    // Coroutine to move the elevator smoothly
    IEnumerator MoveElevator(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Reset the flag once movement is complete
        isMoving = false;
    }
}
