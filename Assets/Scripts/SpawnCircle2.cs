using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnCircle2 : MonoBehaviour
{
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private GameObject highlightPrefab;

    private GameObject currentHighlight;

    private void OnEnable()
    {
        rayInteractor.selectEntered.AddListener(OnSelectEntered);
        rayInteractor.selectExited.AddListener(OnSelectExited);
    }

    private void OnDisable()
    {
        rayInteractor.selectEntered.RemoveListener(OnSelectEntered);
        rayInteractor.selectExited.RemoveListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Hello Entered?");
        if (args.interactable && args.interactable.gameObject != currentHighlight)
        {
            currentHighlight = Instantiate(highlightPrefab, args.interactable.transform.position, args.interactable.transform.rotation, args.interactable.transform);
            Debug.Log("OnSelectEndered Ran");
        }
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        Debug.Log("Hello Exited?");
        if (args.interactable && args.interactable.gameObject == currentHighlight)
        {
            //Destroy(currentHighlight);
            //currentHighlight = null;
            Debug.Log("OnSelectExited Ran");
        }
    }
}
