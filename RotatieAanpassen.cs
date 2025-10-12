using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotatieAanpassen : MonoBehaviour
{
    public InputActionReference buttonAction; // Sleep hier je InputAction in
    public GameObject targetObject; // Sleep hier het object in dat je wilt roteren
    public float rotationAmount = 10f; // Hoeveel graden per druk

    // Kies de as en richting van rotatie
    public enum RotatieRichting
    {
        LinksOm_X,
        RechtsOm_X,
        LinksOm_Y,
        RechtsOm_Y,
        LinksOm_Z,
        RechtsOm_Z
    }

    public RotatieRichting richting = RotatieRichting.RechtsOm_Y;

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
        if (targetObject == null) return;

        Vector3 rotatie = Vector3.zero;

        switch (richting)
        {
            case RotatieRichting.LinksOm_X:
                rotatie = Vector3.left * rotationAmount;
                break;
            case RotatieRichting.RechtsOm_X:
                rotatie = Vector3.right * rotationAmount;
                break;
            case RotatieRichting.LinksOm_Y:
                rotatie = Vector3.down * rotationAmount;
                break;
            case RotatieRichting.RechtsOm_Y:
                rotatie = Vector3.up * rotationAmount;
                break;
            case RotatieRichting.LinksOm_Z:
                rotatie = Vector3.back * rotationAmount;
                break;
            case RotatieRichting.RechtsOm_Z:
                rotatie = Vector3.forward * rotationAmount;
                break;
        }

        targetObject.transform.Rotate(rotatie, Space.Self);
    }
}
