using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    bool crewInformation = false;
    public GameObject crew;

    public void OnStartClick()
    {
        print("������ ���� �����ش�");
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
        print("setting�� �Ѿ��");    }
}
