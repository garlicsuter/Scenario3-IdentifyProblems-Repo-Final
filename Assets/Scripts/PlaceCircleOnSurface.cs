using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using TMPro;

public class PlaceCircleOnSurface : MonoBehaviour
{
    public GameObject circlePrefab;
    private GameObject currentCircle;

    public TextMeshProUGUI leftScoreDisplay;
    public TextMeshProUGUI rightScoreDisplay;
    private InputData _inputData;
    private float _leftMaxScore = 0f;
    private float _rightMaxScore = 0f;
    private float triggerValue;
    private GameObject _theLeftController;

    public InputHelpers.Button button;

    void Start()
    {
        _inputData = GetComponent<InputData>();
        Debug.Log("Started inputData: " + _inputData);
        _theLeftController = GameObject.Find("LeftHand Controller");
        Debug.Log("LeftCtrl: " + _theLeftController);
    }

    private void Update()
    {
        //if (_inputData._leftController.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        //{
        //    //_leftMaxScore = theFloat;
        //    leftScoreDisplay.text = triggerValue.ToString("#.00");
        //    Debug.Log("triggerValue: " + triggerValue);
        //}

        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed))
        {
            //_leftMaxScore = theFloat;
            leftScoreDisplay.text = triggerPressed.ToString();
            Debug.Log("triggerPressed: " + triggerPressed);

            RaycastHit hitInfo;
            bool hit = Physics.Raycast(_theLeftController.transform.position, _theLeftController.transform.forward, out hitInfo);

            if (hit)
            {
                Debug.Log("hit!");

                if (currentCircle == null)
                {
                    currentCircle = Instantiate(circlePrefab, hitInfo.point, Quaternion.identity);
                    Debug.Log("hit and null!");
                }
                else
                {
                    currentCircle.transform.position = hitInfo.point;
                }
            }

        }

        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton))
        {
            //_leftMaxScore = theFloat;
            rightScoreDisplay.text = Abutton.ToString();
            Debug.Log("A button: " + Abutton);
        }     
    }
}
