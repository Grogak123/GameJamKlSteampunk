using UnityEngine;

public class inventarScript : MonoBehaviour
{
    
    private int scrap, feather, screw, gear, pump, clockwork, nucReactor, invUsed;


    public int ScrapScrewFactor = 4;
    public int FeatherGearFactor = 4;
    public int pumpClockFactor = 4;
    public int maxInvSize = 20;


    void Start()
    {
        scrap = 0;
        feather = 0;
        screw = 0;
        gear = 0;
        pump = 0;
        clockwork = 0;
        nucReactor = 0;
        invUsed = 0;
    }

    void Update()
    {
        
    }

    public bool itemCollected (string name)
    {
        calcInvCapacity();
        if(invUsed < maxInvSize)
        {
            switch (name)
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
            return true;
        }
        else
        {
            return false;
        }

    }

    private void calcInvCapacity()
    {
        invUsed = scrap + feather + screw + gear + pump + clockwork + nucReactor;
    }

    public void itemUpgrade()
    {
        
        if (scrap>=ScrapScrewFactor && screw>=ScrapScrewFactor)
        {
            int scrapScrewMin = Mathf.Min(scrap, screw) / ScrapScrewFactor;
            pump += scrapScrewMin;
            scrap -= (scrapScrewMin * ScrapScrewFactor);
            screw -= (scrapScrewMin * ScrapScrewFactor);

        }
        if(feather>=FeatherGearFactor && gear >= FeatherGearFactor)
        {
            int featherGearMin = Mathf.Min(feather, gear) / FeatherGearFactor;
            clockwork += featherGearMin;
            feather -= (featherGearMin * FeatherGearFactor);
            gear -= (featherGearMin * FeatherGearFactor);
        }

        if(pump>=pumpClockFactor && clockwork >= pumpClockFactor)
        {
            int pumpClockMin = Mathf.Min(pump, clockwork) / pumpClockFactor;
            nucReactor += pumpClockMin;
            pump -= (pumpClockMin * pumpClockFactor);
            clockwork -= (pumpClockMin * pumpClockFactor);
        }
    }

    public void itemDestroy(string name)
    {

        switch (name)
        {
            case "Scrap":
                if(scrap>0)
                    scrap--;
                break;
            case "Feather":
                if(feather>0)
                    feather--;
                break;
            case "Screw":
                if(screw>0)
                    screw--;
                break;
            case "Gear":
                if(gear>0)
                    gear--;
                break;
            case "Pump":
                if(pump > 0)
                    pump--;
                break;
            case "Clockwork":
                if(clockwork > 0)
                    clockwork--;
                break;
            case "nucReactor":
                if(nucReactor > 0)
                    nucReactor--;
                break;

            default:
                Debug.Log("Falscher Wert bei itemCollected im inventarScript übergeben: " + name);
                break;
        }

    }

}
