using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameManager gameManager;
    public SpriteRenderer sprite;
    public Vector2 fadeRange;
    public float fadeTime;
    public float elapsedTime;

    private void Start() {
        fadeTime = Random.Range(fadeRange.x, fadeRange.y);
        StartCoroutine(FadeOut());    
    }

    public IEnumerator FadeOut() {
        //float elapsedTime = 0;
        float startValue = sprite.color.a;
        while(elapsedTime < fadeTime) {
            float newAlpha = Mathf.Lerp(startValue, 0, elapsedTime / fadeTime);
            Color newColor = sprite.color;
            newColor.a = newAlpha;
            sprite.color = newColor;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Dispose();
    }

    //tell gamemanger the curent collectable is destroyed
    public void Dispose() {
        Debug.Log("Collectable Destroyed");
        gameManager.currCollectable = null;
        Destroy(gameObject);
    }
}
