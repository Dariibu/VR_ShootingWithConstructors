using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun
{
    float Distancia;

    float distanceMultiplier = 10;

    public float CD, Daño;
    public GameObject go;

    public Transform cannon;
    public Transform gunFinger;
    public AudioSource as_gun;

    public ParticleSystem PS_shooting;
    public Gun(float daño, float distancia, float cD, GameObject go)
    {
        Daño = daño;
        Distancia = distancia;
        CD = cD;
        this.go = go;
    }
    public void Shoot(GameObject bullet, float damage)
    {
        GameObject myBullet = Object.Instantiate(bullet, cannon.transform.position, cannon.transform.rotation);
        myBullet.GetComponent<accBullet>().damage = damage;
        myBullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-Distancia * distanceMultiplier, 0, 0));
        PS_shooting.gameObject.transform.position = cannon.transform.position;
        PS_shooting.gameObject.transform.rotation = cannon.transform.rotation;
        PS_shooting.Play();
        GameObject.Destroy(myBullet, 5f);
        //as_gun.clip = shoot;
        //as_gun.Play();
        //Recoil();
    }

    public void GetThisGun() //ponerlo en la posición y rotación correctas.
    {
        go.SetActive(true);
    }

    public void RemoveThisGun()
    {
        go.SetActive(false);
    }

    void Recoil()
    {
        go.GetComponent<Animation>().Play();
    }

    public void SayAll()
    {
        Debug.Log(Daño + " " + Distancia + " " +CD + " "+ go);
    }
}
