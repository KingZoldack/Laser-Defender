using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    //Config Params
    [SerializeField]
    float _speed = 3.5f, _padding = 1f,_topPadding = 10f, _projectileSpeed = 20f, _projectileFiringPeriod = 0.5f;
    [SerializeField]
    GameObject _laserPrefab;

    Coroutine _firingCoroutine;

    float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetupMoveBounderies();
    }



    // Update is called once per frame
    void Update()
    {
        Movement();
        Fire();

    }

    void Movement()
    {
        var horizontalInput = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        var verticalInput = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        var xClamp = Mathf.Clamp(transform.position.x + horizontalInput, xMin, xMax);
        var yClamp = Mathf.Clamp(transform.position.y + verticalInput, yMin, yMax);
        transform.position = new Vector3(xClamp, yClamp, transform.position.z);
    }

    private void SetupMoveBounderies()
    {
        Camera gameCamrea = Camera.main;
        xMin = gameCamrea.ViewportToWorldPoint(new Vector3(0, 0, 1)).x + _padding;
        xMax = gameCamrea.ViewportToWorldPoint(new Vector3(1, 0, 1)).x - _padding;
        yMin = gameCamrea.ViewportToWorldPoint(new Vector3(0, 0, 1)).y + _padding;
        yMax = gameCamrea.ViewportToWorldPoint(new Vector3(0, 1, 1)).y - _topPadding;
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _firingCoroutine = StartCoroutine(FireConsistantly());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(_firingCoroutine);
        }
    }

    IEnumerator FireConsistantly()
    {
        while (true)
        {
            GameObject laser = Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _projectileSpeed);
            yield return new WaitForSeconds(_projectileFiringPeriod);
        }
    }
}
