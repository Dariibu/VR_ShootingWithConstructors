using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDummies : MonoBehaviour
{
    [SerializeField] List<GameObject> myDummies = new List<GameObject>();

    public static int allDead = 0;
    public void ResetTheDummies()
    {

        if (allDead == 3)
        {
            GameObject dummie1 = Instantiate(myDummies[0], myDummies[0].transform.position, myDummies[0].transform.rotation);
            GameObject dummie2 = Instantiate(myDummies[1], myDummies[1].transform.position, myDummies[1].transform.rotation);
            GameObject dummie3 = Instantiate(myDummies[2], myDummies[2].transform.position, myDummies[2].transform.rotation);

            dummie1.SetActive(true);
            dummie2.SetActive(true);
            dummie3.SetActive(true);

            allDead = 0;
        }

    }

}
