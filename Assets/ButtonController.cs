using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public ElevatorController elevator; // Reference to the elevator controller

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider entering the trigger is Ellen
        if (other.CompareTag("Player"))
        {
            // Activate the elevator
            elevator.ActivateElevator();
        }
    }
}