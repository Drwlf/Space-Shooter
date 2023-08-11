using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]

    private float speed = 3.5f;
    
    [SerializeField]
    private GameObject _laserPrefab;


    // Start is called before the first frame update
    void Start()
    {
        // take the current position = new position ( 0, 0, 0)
        transform.position = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        CalculatedMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_laserPrefab,transform.position, Quaternion.identity);
            

            

        }
    }
        void CalculatedMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

       

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime);
            
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

}
