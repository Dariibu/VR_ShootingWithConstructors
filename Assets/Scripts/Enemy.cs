using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [SerializeField] float HP;
    [SerializeField] Slider sl;

    private void Start()
    {
        sl.maxValue = HP;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            HP -= collision.gameObject.GetComponent<accBullet>().damage;
            sl.value = HP;

            if (HP <= 0)
            {
                Destroy(sl.gameObject);
                Destroy(this.gameObject);               
            }
        }
    }

}
