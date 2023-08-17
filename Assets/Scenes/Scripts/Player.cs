using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;
    [SerializeField]
    private GameObject _Laser;
    [SerializeField]
    private float _fireRate = 0.2f;
    private float _nextfire = -0.08f;
    [SerializeField]
    private int _lives = 3;


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

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextfire)
        {
            FireLaser();

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

    void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextfire)

            _nextfire = Time.time + _fireRate;
        Instantiate(_Laser, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
    }
    public void Damage()
    {
        _lives--;
        if (_lives < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
