using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ChatManager chatManager;
    public GameObject collectablePrefab;
    public Vector2 delayRange; // range of time inbetween items
    public GameObject currCollectable; // when the player types command check this 

    private void Start() {
        StartCoroutine(InstantiateOvertime());    
    }

    public IEnumerator InstantiateOvertime() {
        float delay = Random.Range(delayRange.x, delayRange.y);
        yield return new WaitForSecondsRealtime(delay);
        Vector2 randomLocation = new Vector2(Random.Range(-9f, 9f), Random.Range(-5f, 5f));
        currCollectable = Instantiate(collectablePrefab, randomLocation, Quaternion.identity);
        currCollectable.GetComponent<Collectable>().gameManager = this;
        Debug.Log("Item Instantiated");
    }

    public void Collect() {
        if(currCollectable == null)
            return;

         Collectable collectable = currCollectable.GetComponent<Collectable>();
         collectable.Dispose();
    }
}