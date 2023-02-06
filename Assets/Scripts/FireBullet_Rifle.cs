using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBullet_Rifle : MonoBehaviour
{
    [SerializeField] string GunType;
    [SerializeField] GameManager gm;
    [SerializeField] GameObject bulletPref;

    Sniper thisSniper;
    Shorty thisShorty;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Manager").GetComponent<GameManager>();
        thisSniper = gm.mySniper;
        thisShorty = gm.myShorty;

        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    private void Update()
    {
        thisSniper.timer += Time.deltaTime;
        thisShorty.timer += Time.deltaTime;
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        if (GunType == "Sniper")
        {
            thisSniper.Shoot(bulletPref, thisSniper.Daño);
        }
        else if (GunType == "Shorty")
        {
            Debug.Log("short");
            thisShorty.Shoot(bulletPref, thisShorty.Daño);
        }

    }
}
