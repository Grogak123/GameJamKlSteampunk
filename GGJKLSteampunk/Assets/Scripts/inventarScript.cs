using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //Wie Viel Stuff ma pro Baum brauch

    public int Level0Screw;
    public int Level0Gear;
    public int Level0Feather;
    public int Level0Scrap;
    public int Level1Clockwork;
    public int Level1Pump;
    public int Level2NucReactor;

    public GameObject Tree0;
    public GameObject Tree1;
    public GameObject Tree2;

    private bool _Tree0Condition01 = false;
    private bool _Tree0Condition02 = false;
    private bool _Tree0Condition03 = false;
    private bool _Tree0Condition04 = false;

    private bool _Tree1Condition01 = false;
    private bool _Tree1Condition02 = false;

    private bool _Tree2Condition01 = false;

    public GameObject Gear;
    public GameObject Screw;
    public GameObject Feather;
    public GameObject Scrap;


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
            screwText.text = screw.ToString();
            scrapText.text = scrap.ToString();


        }
        if(FEATHER>=FeatherGearFactor && GEAR >= FeatherGearFactor)
        {
            int featherGearMin = Mathf.Min(feather, gear) / FeatherGearFactor;
            clockwork += featherGearMin;
            feather -= (featherGearMin * FeatherGearFactor);
            gear -= (featherGearMin * FeatherGearFactor);
            clockworkText.text = clockwork.ToString();
            featherText.text = feather.ToString();
            gearText.text = gear.ToString();

        }

        if(PUMP>=pumpClockFactor && CLOCKWORK >= pumpClockFactor)
        {
            int pumpClockMin = Mathf.Min(pump, clockwork) / pumpClockFactor;
            nucReactor += pumpClockMin;
            pump -= (pumpClockMin * pumpClockFactor);
            clockwork -= (pumpClockMin * pumpClockFactor);
            nucReactorText.text = nucReactor.ToString();
            pumpText.text = pump.ToString();
            clockworkText.text = clockwork.ToString();

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



    //public int Level0Screw;
    //public int Level0Gear;
    //public int Level0Feather;
    //public int Level0Scrap;
    //public int Level1Clockwork;
    //public int Level1Pump;
    //public int Level2NucReactor;

    //public GameObject Tree0;
    //public GameObject Tree1;
    //public GameObject Tree2;

    void TreeUpgrade()
    {
        if(Tree0.activeSelf == true && FEATHER > 0 && Level0Feather > 0)
        {
            Level0Feather -= 1;
            FEATHER -= 1;
            featherText.text = FEATHER.ToString();

            if(Level0Feather <= 0)
            {
                _Tree0Condition01 = true;
              
            }
            
        }

        if (Tree0.activeSelf == true && SCREW > 0 && Tree0.activeSelf == true && Level0Screw > 0)
        {
            Level0Screw -= 1;
            SCREW -= 1;
            screwText.text = SCREW.ToString();
            if (Level0Screw<= 0)
            {
                _Tree0Condition02 = true;
            }
        }

        if (Tree0.activeSelf == true && GEAR > 0 && Tree0.activeSelf == true && Level0Gear > 0)
        {
            Level0Gear -= 1;
            GEAR -= 1;
            gearText.text = GEAR.ToString();

            if (Level0Gear <= 0)
            {
                _Tree0Condition03 = true;
            }
        }

        if (Tree0.activeSelf == true && SCRAP > 0 && Tree0.activeSelf == true && Level0Scrap > 0)
        {
            Level0Scrap -= 1;
            SCRAP -= 1;
            scrapText.text = SCRAP.ToString();

            if (Level0Scrap <= 0)
            {
                _Tree0Condition04 = true;
            }
        }

        if (_Tree0Condition01 == true && _Tree0Condition02 == true && _Tree0Condition03 == true && _Tree0Condition04)
        {
            Tree0.SetActive(false);
            Tree1.SetActive(true);
        }

        if (Tree1.activeSelf == true && PUMP > 0 && Level1Pump > 0)
        {
            Level1Pump -= 1;
            PUMP -= 1;
            pumpText.text = PUMP.ToString();

            if (Level1Pump <= 0)
            {
                _Tree1Condition01 = true;

            }

        }

        if (Tree1.activeSelf == true && CLOCKWORK > 0 && Level1Clockwork > 0)
        {
            Level1Clockwork -= 1;
            CLOCKWORK-= 1;
            clockworkText.text = CLOCKWORK.ToString();

            if (Level1Clockwork <= 0)
            {
                _Tree1Condition02 = true;

            }

        }


        if (_Tree1Condition01 == true && _Tree1Condition02 == true)
        {
            Tree1.SetActive(false);
            Tree2.SetActive(true);
        }

        if (Tree2.activeSelf == true && NUCREACTOR > 0 && Level2NucReactor > 0)
        {
            Level2NucReactor -= 1;
            NUCREACTOR -= 1;
            nucReactorText.text = NUCREACTOR.ToString();

            if (Level2NucReactor <= 0)
            {
                _Tree2Condition01 = true;

            }

        }


        if (_Tree2Condition01 == true)
        {
            SceneManager.LoadScene("Win");
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

            itemUpgrade();
        }

        if (collision.gameObject.tag == "Tree" && Input.GetKeyDown(KeyCode.E))
        {

            TreeUpgrade();
        }

        if (collision.gameObject.tag == "GearPlant" && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Instantiate(Gear, collision.transform.position + new Vector3(Random.Range(1.0f,4.0f),0,0), collision.transform.rotation );
            GameObject.Instantiate(Gear, collision.transform.position + new Vector3(Random.Range(1.0f,4.0f),0,0), collision.transform.rotation );
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "FeatherPlant" && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Instantiate(Feather, collision.transform.position + new Vector3(Random.Range(1.0f, 4.0f), 0, 0), collision.transform.rotation);
            GameObject.Instantiate(Feather, collision.transform.position + new Vector3(Random.Range(1.0f, 4.0f), 0, 0), collision.transform.rotation);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "ScrapPlant" && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Instantiate(Scrap, collision.transform.position + new Vector3(Random.Range(1.0f, 4.0f), 0, 0), collision.transform.rotation);
            GameObject.Instantiate(Scrap, collision.transform.position + new Vector3(Random.Range(1.0f, 4.0f), 0, 0), collision.transform.rotation);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "ScrewPlant" && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Instantiate(Screw, collision.transform.position + new Vector3(Random.Range(1.0f, 4.0f), 0, 0), collision.transform.rotation);
            GameObject.Instantiate(Screw, collision.transform.position + new Vector3(Random.Range(1.0f, 4.0f), 0, 0), collision.transform.rotation);
            Destroy(collision.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Feather"))
        {
            itemCollected("Feather");

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Gear"))
        {
            itemCollected("Gear");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Screw"))
        {
            itemCollected("Screw");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Scrap"))
        {
            itemCollected("Scrap");
            Destroy(collision.gameObject);
        }

    }

    /*
     * Zerstört 1 Item abhängig davon welcher Name übergeben wurde
     * Wird für die UI benutzt, bitte nimmer ändern :)
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
            case "NucReactor":
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
                    clockworkText.text = clockwork.ToString();
                    stolen = true;
                }
                else
                {
                    pump--;
                    pumpText.text = pump.ToString();
                    stolen = true;
                }
            }
            else if (clockwork > 0)
            {
                clockwork--;
                clockworkText.text = clockwork.ToString();
                stolen = true;
            }
            else if (pump>0)
            {
                pump--;
                pumpText.text = pump.ToString();
                stolen = true;
            }


        }
        if (!stolen)
        {
            int max = scrap + feather + screw + gear;

            if (max > 0)
            {

                int random2 = Random.Range(1, 4);

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
                                    scrapText.text = scrap.ToString();
                                    i++;
                                }
                                break;
                            case 1:
                                if (feather > 0)
                                {
                                    feather--;
                                    featherText.text = feather.ToString();
                                    i++;
                                }
                                break;
                            case 2:
                                if (screw > 0)
                                {
                                    screw--;
                                    screwText.text = screw.ToString();
                                    i++;
                                }
                                break;
                            case 3:
                                if (gear > 0)
                                {
                                    gear--;
                                    gearText.text = gear.ToString();
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
                    scrapText.text = scrap.ToString();
                    featherText.text = feather.ToString();
                    screwText.text = screw.ToString();
                    gearText.text = gear.ToString();
                }

            }

        }
    }



}
