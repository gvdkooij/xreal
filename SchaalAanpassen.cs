using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SchaalAanpassen : MonoBehaviour
{
    public InputActionReference buttonAction; // Sleep hier je InputAction in
    public GameObject targetObject; // Sleep hier het object in dat je wilt schalen
    public float scaleAmount = 0.1f; // Hoeveel groter of kleiner per druk

    // Richting van schaalverandering
    public enum SchaalRichting
    {
        Groter,
        Kleiner
    }

    public SchaalRichting richting = SchaalRichting.Groter;

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

        Vector3 huidigeSchaal = targetObject.transform.localScale;
        float factor = 1f;

        switch (richting)
        {
            case SchaalRichting.Groter:
                factor = 1 + scaleAmount;
                break;
            case SchaalRichting.Kleiner:
                factor = 1 - scaleAmount;
                break;
        }

        // Pas x en y tegelijk aan (houd verhouding)
        targetObject.transform.localScale = new Vector3(
            huidigeSchaal.x * factor,
            huidigeSchaal.y * factor,
            huidigeSchaal.z // z blijft hetzelfde, tenzij je ook die wilt aanpassen
        );
    }
}
