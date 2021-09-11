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

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        position = transform.position;
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
        }
        else
        {
            transform.localRotation = lastLocalRotation;
            transform.position = position;
        }
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
