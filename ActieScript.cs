using UnityEngine;

public class ActieScript : MonoBehaviour
{
    public GameObject targetObject;
    public ActieType actieType;

    // --- Rotatie ---
    public RotatieAs rotatieAs;
    public RichtingRotatie rotatieRichting;
    public float rotatieGraden = 90f;

    // --- Verplaatsing ---
    public VerplaatsRichting verplaatsRichting;
    public float verplaatsAfstand = 1f;

    // --- Vergroting ---
    public VergrootType vergrootType;
    public float schaalFactor = 1.2f;

    [ContextMenu("Voer Actie Uit")]
    public void VoerActieUit()
    {
        if (targetObject == null)
        {
            Debug.LogWarning("Geen target object opgegeven!");
            return;
        }

        Transform t = targetObject.transform;

        switch (actieType)
        {
            case ActieType.Rotatie:
                Vector3 as = Vector3.zero;
                switch (rotatieAs)
                {
                    case RotatieAs.X: as = Vector3.right; break;
                    case RotatieAs.Y: as = Vector3.up; break;
                    case RotatieAs.Z: as = Vector3.forward; break;
                }

                float richting = (rotatieRichting == RichtingRotatie.Linksom) ? -1f : 1f;
                t.Rotate(as, rotatieGraden * richting, Space.Self);
                break;

            case ActieType.Verplaatsing:
                Vector3 verplaats = Vector3.zero;
                switch (verplaatsRichting)
                {
                    case VerplaatsRichting.Boven: verplaats = Vector3.up; break;
                    case VerplaatsRichting.Onder: verplaats = Vector3.down; break;
                    case VerplaatsRichting.Links: verplaats = Vector3.left; break;
                    case VerplaatsRichting.Rechts: verplaats = Vector3.right; break;
                    case VerplaatsRichting.Voren: verplaats = Vector3.forward; break;
                    case VerplaatsRichting.Achteren: verplaats = Vector3.back; break;
                }

                t.position += verplaats * verplaatsAfstand;
                break;

            case ActieType.Vergroting:
                float factor = (vergrootType == VergrootType.Vergroten) ? schaalFactor : 1f / schaalFactor;
                t.localScale *= factor;
                break;
        }

        Debug.Log($"Actie '{actieType}' uitgevoerd op {targetObject.name}");
    }
}

// --- ENUMS ---

public enum ActieType { Rotatie, Verplaatsing, Vergroting }

public enum RotatieAs { X, Y, Z }

public enum RichtingRotatie { Linksom, Rechtsom }

public enum VerplaatsRichting { Boven, Onder, Links, Rechts, Voren, Achteren }

public enum VergrootType { Vergroten, Verkleinen }
