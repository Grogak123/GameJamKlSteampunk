using UnityEngine;

public class inventarScript : MonoBehaviour
{
    
    private sbyte scrap, feather, screw, gear, pump, clockwork, nucReactor;

    // Start is called before the first frame update
    void Start()
    {
        scrap = 0;
        feather = 0;
        screw = 0;
        gear = 0;
        pump = 0;
        clockwork = 0;
        nucReactor = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void itemCollected (string name)
    {
        switch(name)
        {
            case "Scrap":
                scrap++;
                break;
            case "Feather":
                feather++;
                break;
            case "Screw":
                screw++;
                break;
            case "Gear":
                gear++;
                break;
            default:
                Debug.Log("Falscher Wert bei itemCollected im inventarScript übergeben: " + name);
                break;
        }



    }
}
