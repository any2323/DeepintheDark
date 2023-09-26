using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    bool crewInformation = false;
    public GameObject crew;

    public void OnStartClick()
    {
        print("다음으로 넘어간다");
    }

    public void OnCrewClick()
    {

        if (!crewInformation)
        {
            crewInformation = true;
            crew.SetActive(crewInformation);
        }
        else
        {
            crewInformation= false;
            crew.SetActive(crewInformation);
        }
    }
}
