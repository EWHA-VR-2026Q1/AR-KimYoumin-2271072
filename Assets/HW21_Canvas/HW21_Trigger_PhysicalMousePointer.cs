using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class HW21_Trigger_PhysicalMousePointer : MonoBehaviour
{
    private Camera mainCamera;

    [Header("Target Settings")]
    public GameObject targetInterfaceObject;

    public GameObject senderObject;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Pointer.current != null &&
            Pointer.current.press.wasPressedThisFrame)
        {
            Debug.Log("터치 입력 감지");

            Vector2 screenPosition =
                Pointer.current.position.ReadValue();

            if (EventSystem.current != null &&
                EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("UI 클릭됨");
                return;
            }

            Ray ray =
                mainCamera.ScreenPointToRay(screenPosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log($"오브젝트 클릭됨: {hit.transform.name}");
            }
        }
    }
}