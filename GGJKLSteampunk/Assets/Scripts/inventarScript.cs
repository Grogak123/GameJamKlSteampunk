﻿using UnityEngine;

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
                Debug.Log("Falscher Wert bei itemDestroyed im inventarScript übergeben: " + name);
                break;
        }

    }

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
