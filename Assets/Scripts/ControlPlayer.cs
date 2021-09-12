using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private Vector3 position;
    private Quaternion lastLocalRotation;
    private float horizontalAngle;
    private float verticalAngle;
    [SerializeField] float rotationSpeed = 6;
    private float[] horizontalLimits = {-4,4};
    private float[] verticalLimits = {-9,10};
    private float ammunition;
    private float reloadTime = 1.5f;
    [SerializeField] AudioSource sounds;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sounds = GetComponent<AudioSource>();
        position = transform.position;
        ammunition = 5;
    }

    public float GetAmmunition()
    {
        return ammunition;
    }


    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetGameover() == false)
        {
            RotateHorizontal();
            RotateVertical();
            transform.localPosition = position;
            transform.localRotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0);
            lastLocalRotation = transform.localRotation;
            HandleLeftClick();
        }
        else
        {
            transform.localRotation = lastLocalRotation;
            transform.position = position;
        }
    }

    void HandleLeftClick()
    {
        if (Input.GetMouseButtonDown(0)) //left click
        {
            if (ammunition > 0)
            {
                ammunition -= 1;
                sounds.Play();
            }
            if (ammunition == 0)
                StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        ammunition = 5;
    }


    private void RotateHorizontal()
    {

        horizontalAngle += -Input.GetAxis("Mouse X") * rotationSpeed * -Time.deltaTime;
        horizontalAngle = Mathf.Clamp(horizontalAngle, horizontalLimits[0], horizontalLimits[1]);
        //transform.localRotation = Quaternion.AngleAxis(horizontalAngle, Vector3.up);
    }

    private void RotateVertical()
    {
        verticalAngle += Input.GetAxis("Mouse Y") * rotationSpeed * -Time.deltaTime;
        verticalAngle = Mathf.Clamp(verticalAngle, verticalLimits[0], verticalLimits[1]);
        //transform.localRotation = Quaternion.AngleAxis(verticalAngle, Vector3.right);
    }
}
