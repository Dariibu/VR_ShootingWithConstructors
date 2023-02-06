using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingUI : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    [SerializeField] Transform subject;

    void Update()
    {
        if (subject)
        {
            transform.position = playerCam.WorldToScreenPoint(subject.position);
        }
    }
}
