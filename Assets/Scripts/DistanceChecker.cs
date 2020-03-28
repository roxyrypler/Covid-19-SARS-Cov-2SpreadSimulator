using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    InfectionDecider InfectionDeciderScript;

    GameObject[] Humans;

    LineRenderer LR;

    public Material InrangeColor;
    public Material DangerRangeColor;

    [HideInInspector]
    public bool CanCheck;


    void Start()
    {
        //LR = GetComponent<LineRenderer>();
        InfectionDeciderScript = GetComponent<InfectionDecider>();
    }

    public void CustomUpdate()
    {
        CheckDistance();
    }

    public void GetAllHumans()
    {
        Humans = GameObject.FindGameObjectsWithTag("Human");
    }

    void CheckDistance()
    {
        for (int i = 0; i < Humans.Length; i++)
        {
            float Distance = Vector3.Distance(Humans[i].transform.position, transform.position);
            if (Distance <= 2 && Distance > 0.1f)
            {
                if (CanCheck)
                {
                    if (Humans[i].GetComponent<InfectionDecider>().AmIInfected)
                    {
                        InfectionDeciderScript.BecomesInfected();
                        print("checking if infected");
                        CanCheck = false;
                    }
                }


                Debug.DrawLine(transform.position, Humans[i].transform.position, Color.red);
            }
            else if (Distance <= 5 && Distance > 0.1f)
            {
                Debug.DrawLine(transform.position, Humans[i].transform.position, Color.green);
            }
        }
    }
}
