using UnityEngine;

public class itemAttachScript : MonoBehaviour
{
    private string itemName;
    private inventarScript invScript;
    GameObject mainChar;

    void Start()
    {
        mainChar = GameObject.Find("MainCharacter");
        itemName = gameObject.tag;
        invScript = (inventarScript)mainChar.GetComponent(typeof(inventarScript));
        Debug.Log(mainChar);
        Debug.Log(itemName);
        Debug.Log(invScript);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (invScript.itemCollected(itemName))
        {
            Destroy(gameObject);
        }
    }
}
