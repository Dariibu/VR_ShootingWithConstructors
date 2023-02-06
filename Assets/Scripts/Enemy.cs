using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [SerializeField] float HP;
    [SerializeField] Slider sl;
    Vector3 scale;

    private void Start()
    {
        scale = gameObject.transform.localScale;
        sl.maxValue = HP;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            HP -= collision.gameObject.GetComponent<accBullet>().damage;
            sl.value = HP;
            gameObject.transform.localScale -= gameObject.transform.localScale / 8;
            Invoke("reScale", 0.2f);

            if (HP <= 0)
            {
                Destroy(sl.gameObject);
                Destroy(this.gameObject);               
            }
        }
    }

    void reScale()
    {
        gameObject.transform.localScale = scale;
    }
}
