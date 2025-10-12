using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TransformAanpassen : MonoBehaviour
{
    public InputActionReference buttonAction; // Sleep hier je InputAction in
    public GameObject targetObject; // Het object dat je wilt aanpassen

    [Header("Verplaatsing (relatief)")]
    public float moveX = 0f;
    public float moveY = 0f;
    public float moveZ = 0f;

    [Header("Rotatie (graden)")]
    public float rotX = 0f;
    public float rotY = 0f;
    public float rotZ = 0f;

    [Header("Schaal (relatief)")]
    public float scaleX = 0f;
    public float scaleY = 0f;
    public float scaleZ = 0f;

    void OnEnable()
    {
        if(buttonAction != null)
            buttonAction.action.performed += PasTransformToe;
    }

    void OnDisable()
    {
        if(buttonAction != null)
            buttonAction.action.performed -= PasTransformToe;
    }

    private void PasTransformToe(InputAction.CallbackContext context)
    {
        if (targetObject == null) return;

        // Verplaatsing
        Vector3 moveDelta = new Vector3(moveX, moveY, moveZ);
        targetObject.transform.position += moveDelta;

        // Rotatie
        Vector3 rotDelta = new Vector3(rotX, rotY, rotZ);
        targetObject.transform.Rotate(rotDelta, Space.Self);

        // Schaal
        Vector3 newScale = targetObject.transform.localScale;
        newScale.x *= 1 + scaleX;
        newScale.y *= 1 + scaleY;
        newScale.z *= 1 + scaleZ;
        targetObject.transform.localScale = newScale;
    }
}
