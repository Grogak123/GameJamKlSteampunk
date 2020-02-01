using TMPro;
using UnityEngine;

public class inventarScript : MonoBehaviour
{
    
    private int scrap, feather, screw, gear, pump, clockwork, nucReactor, invUsed;


    /*
     * Anzahl der jeweiligen Items um das nächsthöhere zu craften
     */
    public int ScrapScrewFactor = 4;
    public int FeatherGearFactor = 4;
    public int pumpClockFactor = 4;

    public int maxInvSize = 20;


    public TextMeshProUGUI gearText;
    public TextMeshProUGUI featherText;
    public TextMeshProUGUI screwText;
    public TextMeshProUGUI scrapText;
    public TextMeshProUGUI clockworkText;
    public TextMeshProUGUI pumpText;
    public TextMeshProUGUI nucReactorText;


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

    /*
     * Hebt ein Item auf solange genug Platz ist. Gibt folgendes aus:
     *      - True: Wenn genug Platz im Inventar war und aufgehoben wurde
     *      - False: Wenn nicht genug Platz im Inventar war und  nicht aufgehoben wurde
     */
    public bool itemCollected (string name)
    {
        calcInvUsed();
        if(invUsed < maxInvSize)
        {
            switch (name)
            {
                case "Scrap":
                    scrap++;
                    scrapText.text = scrap.ToString();
                    break;
                case "Feather":
                    feather++;
                    featherText.text = feather.ToString();
                    break;
                case "Screw":
                    screw++;
                    screwText.text = screw.ToString();
                    break;
                case "Gear":
                    gear++;
                    gearText.text = gear.ToString();
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

    /*
     * Hilfsmethode um den belegten Inventarplatz zu berechnen
     */
    private void calcInvUsed()
    {
        invUsed = scrap + feather + screw + gear + pump + clockwork + nucReactor;
    }

    /*
     * Geht durch das Inventar durch und upgraded alle möglichen Items
     */
    public void itemUpgrade()
    {

        if (SCRAP>=ScrapScrewFactor && SCREW>=ScrapScrewFactor)
        {
            int scrapScrewMin = Mathf.Min(scrap, screw) / ScrapScrewFactor;
            pump += scrapScrewMin;
            scrap -= (scrapScrewMin * ScrapScrewFactor);
            screw -= (scrapScrewMin * ScrapScrewFactor);
            pumpText.text = pump.ToString();
            Debug.Log("Pumpen: " +pump);

        }
        if(FEATHER>=FeatherGearFactor && GEAR >= FeatherGearFactor)
        {
            int featherGearMin = Mathf.Min(feather, gear) / FeatherGearFactor;
            clockwork += featherGearMin;
            feather -= (featherGearMin * FeatherGearFactor);
            gear -= (featherGearMin * FeatherGearFactor);
            clockworkText.text = clockwork.ToString();
            Debug.Log("Gears: " + gear);
        }

        if(PUMP>=pumpClockFactor && CLOCKWORK >= pumpClockFactor)
        {
            int pumpClockMin = Mathf.Min(pump, clockwork) / pumpClockFactor;
            nucReactor += pumpClockMin;
            pump -= (pumpClockMin * pumpClockFactor);
            clockwork -= (pumpClockMin * pumpClockFactor);
            nucReactorText.text = nucReactor.ToString();
            Debug.Log("Reaktor " + nucReactor);
        }
    }
    /*
     * Get/SetMethoden in C#
     *   
     */
    public int SCRAP
    {
        get { return scrap; }
        set
        {
            if (value < 0)
                scrap = 0;
            else
                scrap = value;
        }
    }


    public int FEATHER
    {
        get { return feather; }
        set
        {
            if (value < 0)
                feather = 0;
            else
                feather = value;
        }
    }

    public int SCREW
    {
        get { return screw; }
        set
        {
            if (value < 0)
                screw = 0;
            else
                screw = value;
        }
    }


    public int GEAR
    {
        get { return gear; }
        set
        {
            if (value < 0)
                gear = 0;
            else
                gear = value;
        }
    }

    public int PUMP
    {
        get { return pump; }
        set
        {
            if (value < 0)
                pump = 0;
            else
                pump = value;
        }
    }

    public int CLOCKWORK
    {
        get { return clockwork; }
        set
        {
            if (value < 0)
                clockwork = 0;
            else
                clockwork = value;
        }
    }

    public int NUCREACTOR
    {
        get { return nucReactor; }
        set
        {
            if (value < 0)
                nucReactor = 0;
            else
                nucReactor = value;
        }
    }

    /*
     * Trigger für Knopfdruck erkenne und Items upgraden
     *
     */

    // Control Craftintable
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CraftTable" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Collision");
            itemUpgrade();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Feather"))
        {
            itemCollected("Feather");
            Debug.Log("Feather: " + FEATHER);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Gear"))
        {
            itemCollected("Gear");
            Debug.Log("Gear: " + GEAR);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Screw"))
        {
            itemCollected("Screw");
            Debug.Log("Screw: " + SCREW);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Scrap"))
        {
            itemCollected("Scrap");
            Debug.Log("Srap: " + SCRAP);
            Destroy(collision.gameObject);
        }

    }

    /*
     * Zerstört 1 Item abhängig davon welcher Name übergeben wurde
     */
    public void itemDestroy(string name)
    {

        switch (name)
        {
            case "Scrap":
                if(scrap>0)
                    scrap--;
                    scrapText.text = scrap.ToString();
                break;
            case "Feather":
                if(feather>0)
                    feather--;
                    featherText.text = feather.ToString();
                break;
            case "Screw":
                if(screw>0)
                    screw--;
                    screwText.text = screw.ToString();
                break;
            case "Gear":
                if(gear>0)
                    gear--;
                    gearText.text = gear.ToString();
                break;
            case "Pump":
                if(pump > 0)
                    pump--;
                    pumpText.text = pump.ToString();
                break;
            case "Clockwork":
                if(clockwork > 0)
                    clockwork--;
                    clockworkText.text = clockwork.ToString();
                break;
            case "nucReactor":
                if(nucReactor > 0)
                    nucReactor--;
                    nucReactorText.text = nucReactor.ToString();
                break;

            default:
                Debug.Log("Falscher Wert bei itemDestroyed im inventarScript übergeben: " + name);
                break;
        }

    }


    /*
     * Stielt zufällig entweder:
     *      - mit 30% Warscheinlichkeit 1 Tier2 Material (sofern verfügbar)
     *      - mit 70% Warscheinlichkeit 2-4 Tier1 Materialien
     * Stielt niemals mehr Materialien als im Inventar sind. 
     * Bei leerem Inventar passiert nichts
     * Werden z.B. versucht 4 Tier1 Materialien gestohlen aber nur 2 sind verfügbar, so werden diese beiden gestohlen
     */
    public void itemSteal()
    {
        float random = Random.Range(0.0f, 1.0f);
        bool stolen = false;
        if(random <= 0.3f)
        {

            if(clockwork>0 && pump>0)
            {
                int random2 = Random.Range(0, 2);
                if (random2 == 0)
                {
                    clockwork--;
                    stolen = true;
                }
                else
                {
                    pump--;
                    stolen = true;
                }
            }
            else if (clockwork > 0)
            {
                clockwork--;
                stolen = true;
            }
            else if (pump>0)
            {
                pump--;
                stolen = true;
            }


        }
        if (!stolen)
        {
            int max = scrap + feather + screw + gear;
            if (max > 0)
            {

                int random2 = Random.Range(2, 5);
                int i = 0;
                if (max > random2)
                {
                    while (i < random2)
                    {
                        int random3 = Random.Range(0, 4);
                        switch (random3)
                        {
                            case 0:
                                if (scrap > 0)
                                {
                                    scrap--;
                                    i++;
                                }
                                break;
                            case 1:
                                if (feather > 0)
                                {
                                    feather--;
                                    i++;
                                }
                                break;
                            case 2:
                                if (screw > 0)
                                {
                                    screw--;
                                    i++;
                                }
                                break;
                            case 3:
                                if (gear > 0)
                                {
                                    gear--;
                                    i++;
                                }
                                break;
                            default:
                                Debug.Log("Impossible error in itemSteal in inventarScript");
                                i++;
                                break;
                        }
                    }
                }
                else
                {
                    scrap = 0;
                    feather = 0;
                    screw = 0;
                    gear = 0;
                }

            }

        }
    }



}
