using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VerplaatsInRichting : MonoBehaviour
{
    public InputActionReference buttonAction; // Sleep hier je InputAction in
    public GameObject sphere; // Sleep hier je GameObject in (de bol of ander object)
    public float moveAmount = 0.1f; // Hoeveel per druk

    // Keuzemenu voor richting
    public enum Richting
    {
        Links,
        Rechts,
        Omhoog,
        Omlaag,
        Vooruit,
        Achteruit
    }

    public Richting richting = Richting.Omhoog;

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
        if (sphere == null) return;

        Vector3 moveDir = Vector3.zero;

        switch (richting)
        {
            case Richting.Links:
                moveDir = Vector3.left;
                break;
            case Richting.Rechts:
                moveDir = Vector3.right;
                break;
            case Richting.Omhoog:
                moveDir = Vector3.up;
                break;
            case Richting.Omlaag:
                moveDir = Vector3.down;
                break;
            case Richting.Vooruit:
                moveDir = Vector3.forward;
                break;
            case Richting.Achteruit:
                moveDir = Vector3.back;
                break;
        }

        sphere.transform.position += moveDir * moveAmount;
    }
}
