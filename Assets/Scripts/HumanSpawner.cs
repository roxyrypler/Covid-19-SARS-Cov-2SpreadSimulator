using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class HumanSpawner : MonoBehaviour
{
    public GameObject Human;

    public InputField InputField01;
    public Button StartSimulationButton;

    GameObject[] AllHumans;

    bool isRunningSimulation;


    private void Start()
    {
        StartSimulationButton.onClick.AddListener(RemoveAllHumans);
    }

    private void Update()
    {
        if (isRunningSimulation)
        {
            for (int i = 0; i < AllHumans.Length; i++)
            {
                AllHumans[i].GetComponent<DistanceChecker>().CustomUpdate();
            }
        }
    }

    void ClickStartSimulationButton()
    {

        if (!Regex.IsMatch(InputField01.text, "[^0-9]"))
        {
            print(InputField01.text);
            if (int.TryParse(InputField01.text, out int TotHumans))
            {
                if (TotHumans <= 100)
                {
                    for (int i = 0; i < TotHumans; i++)
                    {
                        float RandX = Random.Range(1, 19);
                        float YPos = 0.61f;
                        float RandZ = Random.Range(0, -19);
                        Instantiate(Human, new Vector3(RandX, YPos, RandZ), Quaternion.identity);
                    }

                    AllHumans = GameObject.FindGameObjectsWithTag("Human");

                    if (AllHumans != null)
                    {
                        for (int i = 0; i < AllHumans.Length; i++)
                        {
                            if (i == AllHumans.Length - 1)
                            {
                                AllHumans[i].GetComponent<InfectionDecider>().AmIInfected = true;
                            }
                            AllHumans[i].GetComponent<DistanceChecker>().GetAllHumans();
                        }
                    }
                    isRunningSimulation = true;
                }
                else
                {
                    print("Too many for now?");
                }
            }
        }else
        {
            print("Only accepts numbers");
        }
    }

    void RemoveAllHumans()
    {
        isRunningSimulation = false;
        StartCoroutine(RemoveDelay());
    }

    IEnumerator RemoveDelay()
    {
        GameObject[] AllHumans = GameObject.FindGameObjectsWithTag("Human");

        if (AllHumans != null)
        {
            if (AllHumans.Length != 0)
            {
                for (int i = 0; i < AllHumans.Length; i++)
                {
                    Destroy(AllHumans[i]);
                }
            }
        }
        yield return new WaitForSeconds(1);

        ClickStartSimulationButton();
    }
}
