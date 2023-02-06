using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accBullet : MonoBehaviour
{
    List<Vector3> directions = new List<Vector3>();
    [SerializeField] float amplify;

    [SerializeField] GameObject normalBullet, accumulatedBullet;
    bool explode = true;

    int chosen;
    [SerializeField] ParticleSystem PS_Explode;

    public float damage;
    private void Start()
    {
        Debug.Log(gameObject.name);
        //Debug.Log(accumulatedBullet.name + "(Clone)");
        directions.Add(new Vector3(1, 1, 0));
        directions.Add(new Vector3(1, 0, 1));
        directions.Add(new Vector3(0, 1, 1));
        directions.Add(new Vector3(1, 1, 1));

        PS_Explode = GameObject.Find("PS_Explode").GetComponent<ParticleSystem>(); //encontramos el efecto de choque en la escena para no instanciar.

        if (gameObject == accumulatedBullet)
        {
            explode = false;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(explode);
        if (collision.gameObject.tag != "Bala")
        {
            if (!explode)  //esto es para el arma fuerte: al chocar, salen varias balas normales de esta bala. Es una explosión de racimo.
            {
                int space = -2; //para dejar un espacio entre las balas.
                gameObject.transform.position += new Vector3(0, 2, 0); //y para que no estén al nivel del suelo.
                for (int i = 0; i <= 3; i++) //haremos 4 balas, para los 4 vectores que tenemos en la lista "directions".
                {
                    chosen = Random.Range(0, directions.Count - 1);
                    GameObject myBullet = Instantiate(normalBullet, transform.position + new Vector3(space, i, space), transform.rotation);
                    myBullet.GetComponent<accBullet>().damage = damage;
                    myBullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 200, 0));
                    myBullet.GetComponent<Rigidbody>().AddRelativeForce(directions[chosen] * amplify);
                    directions.RemoveAt(chosen); //lo quitamos de la lista para que no vayan en la misma dirección.
                    GameObject.Destroy(myBullet, 5f);
                    space += 1;
                }
                Explode();
            }

            Debug.Log(explode);

            if (explode) //si ya son balas normales, explotan al chocar.
            {
                Explode();
            }
        }
    }

    void Explode()
    {
        PS_Explode.gameObject.transform.position = transform.position;  //poner el efecto en la posición de choque.
        PS_Explode.Play();
        Destroy(this.gameObject);
    }

}
