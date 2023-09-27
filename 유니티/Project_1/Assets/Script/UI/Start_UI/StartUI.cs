using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    bool crewInformation = false;
    public GameObject crew;

    public void OnStartClick()
    {
        print("레벨을 먼저 보여준다");
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

    public void OnSettingClick()
    {
        print("setting을 넘어간다");    }
}
