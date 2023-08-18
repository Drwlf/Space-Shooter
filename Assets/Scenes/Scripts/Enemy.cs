using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]

    private float _speed = 4.0f;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0.57f, 7.61f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);



        if (transform.position.y < -6.09f)
        {
            float randomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            other.transform.GetComponent<Player>().Damage();
            Destroy(this.gameObject);
            Debug.Log("Hit: " + other.transform.name);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

}
