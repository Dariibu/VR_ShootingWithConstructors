using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region parent
    Sniper mySniper;
    [SerializeField] GameObject go_sniper;

    Shorty myShorty;
    [SerializeField] GameObject go_shorty;

    [SerializeField] GameObject bullet, normalBullet, accumulatedBullet;
    Transform hand;
    #endregion

    [SerializeField] Gun currentGun;
    [SerializeField] float CDTimer;
    [SerializeField] ParticleSystem PS_Shoot;
    void Awake()
    {
        mySniper = new Sniper(1, 200, 0.2f, go_sniper);
        myShorty = new Shorty(3, 50, 1.5f, go_shorty);

        mySniper.gunFinger = hand;
        myShorty.gunFinger = hand;

        mySniper.PS_shooting = PS_Shoot;
        myShorty.PS_shooting = PS_Shoot;

        mySniper.cannon = mySniper.go.transform.GetChild(0);
        myShorty.cannon = myShorty.go.transform.GetChild(0);

        mySniper.GetThisGun();
        currentGun = mySniper;

        CDTimer = 10;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && mySniper != currentGun) // el 1 va a ser el sniper
        {
            currentGun.RemoveThisGun();
            mySniper.GetThisGun();
            currentGun = mySniper;
            bullet = normalBullet;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && myShorty != currentGun) // el 2 va a ser la shorty
        {
            currentGun.RemoveThisGun();
            myShorty.GetThisGun();
            currentGun = myShorty;
            bullet = accumulatedBullet;
        }
        if (Input.GetKey(KeyCode.Mouse0) && CDTimer >= currentGun.CD) //si click, dispara
        {
            Debug.Log(currentGun);
            currentGun.Shoot(bullet, currentGun.Daño);
            CDTimer = 0;
        }
        CDTimer += Time.deltaTime;
    }
}
