using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NaarBovenScript : MonoBehaviour
{
    public InputActionReference buttonAction; // Sleep hier je InputAction in
    public GameObject sphere; // Sleep hier je GameObject in (de bol of ander object)
    public float moveAmount = 0.1f; // Hoeveel omhoog bij elke druk

    void OnEnable()
    {
        buttonAction.action.performed += OnButtonPressed;
    }

    void OnDisable()
    {
        buttonAction.action.performed -= OnButtonPressed;
    }

    private void OnButtonPressed(InputAction.CallbackContext context)
    {
        if (sphere != null)
        {
            // Verplaats de positie iets omhoog
            sphere.transform.position += Vector3.up * moveAmount;
        }
    }
}

