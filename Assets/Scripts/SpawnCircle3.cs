using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using System.Collections;

public class SpawnCircle3 : MonoBehaviour
{
    public GameObject circlePrefab;
    //public XRController controller;
    public LayerMask layerMask;
    public GameObject dragLCtrlHere;

    private GameObject circle;

    private InputData _inputData;

    private ActionBasedController ABcontrollerL;
    private float buttonPressed;

    public GameObject CubeTest;
    public bool cubeCastable;
    private bool spawnomatic = true;


    private void Start()
    {
        ABcontrollerL = dragLCtrlHere.GetComponent<ActionBasedController>();
        Debug.Log("ABControllerL IS::::::: " + ABcontrollerL);
        //StartCoroutine(Delay1());
        cubeCastable = CubeTest.GetComponent<XRSimpleInteractable>();
        Debug.Log("START spawnomatic: " + spawnomatic);
    }

    
    private void Update()
    {
        buttonPressed = ABcontrollerL.selectAction.action.ReadValue<float>();
        Debug.Log("spawnomatic: " + spawnomatic);

        RaycastHit hit;
        


        if (spawnomatic)
        {
            bool isHit = Physics.Raycast(ABcontrollerL.transform.position, ABcontrollerL.transform.forward, out hit, Mathf.Infinity);
            if (isHit)
            {
                if (circle == null)
                {
                    circle = Instantiate(circlePrefab, hit.point, Quaternion.identity);
                    Debug.Log("Tried to Spawn Circle and isHit:" + isHit);

                    StartCoroutine(Delay1());
                }
                else
                {
                    circle.transform.position = hit.point;
                    circle.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                    Debug.Log("ELSE ELSE ELSE ELSE & isHit::" + isHit);
                }
            }
            else if (circle != null)
            {
                Destroy(circle);
            }
        }

        
    }

    IEnumerator Delay1()
    {
        
        yield return 300;
        spawnomatic = false;
        Debug.Log("yielded 300");
        yield return 100;
        spawnomatic = true;
        Destroy(circle);
        Debug.Log("yielded 100");
    }
    //isHit = false;
    
}
