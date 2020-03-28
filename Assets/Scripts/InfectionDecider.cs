using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionDecider : MonoBehaviour
{
    public Material HealthyMaterial;
    public Material InfectedMaterial;
    public Material CuredMaterial;

    
    Renderer RendererMain;

    public bool AmIInfected;
    int GetInfectedProb;

    int CheckTick;

    void Start()
    {
        RendererMain = GetComponent<Renderer>();
        RendererMain.material = HealthyMaterial;
        if (AmIInfected)
        {
            BecomCertainInfected();
        }
        StartCoroutine(ResetAllBools());
    }

    public void ProbabillityOfGettingInfected()
    {
        GetInfectedProb = Random.Range(0, 100);

        if (GetInfectedProb >= 90)
        {
            AmIInfected = true;
            RendererMain.material = InfectedMaterial;
        }
    }

    public void BecomesInfected()
    {
        ProbabillityOfGettingInfected();
    }

    public void BecomesHealthy()
    {
        RendererMain.material = CuredMaterial;
    }

    public void BecomCertainInfected()
    {
        AmIInfected = true;
        RendererMain.material = InfectedMaterial;
    }

    IEnumerator ResetAllBools()
    {
        yield return new WaitForSeconds(1);
        GameObject[] AllHumans = GameObject.FindGameObjectsWithTag("Human");
        for (int i = 0; i < AllHumans.Length; i++)
        {
            AllHumans[i].GetComponent<DistanceChecker>().CanCheck = true;
        }
        StartCoroutine(ResetAllBools());
    }
}
