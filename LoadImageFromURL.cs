using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class LoadImageFromURL : MonoBehaviour
{
    [Header("Instellingen")]
    public string imageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3f/Placeholder_view_vector.svg.png";
    public SpriteRenderer targetSpriteRenderer; // 👈 Dit zorgt voor het veld in de Inspector

    void Start()
    {
        StartCoroutine(DownloadImage());
    }

    IEnumerator DownloadImage()
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f)
            );

            targetSpriteRenderer.sprite = sprite; // 👈 Hier wordt hij gebruikt
        }
        else
        {
            Debug.LogError("Afbeelding laden mislukt: " + request.error);
        }
    }
}
