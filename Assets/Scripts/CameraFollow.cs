using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    private Transform target;

    private float smoothSpeed = 10f;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (player != null && player.activeSelf)
        {
            target = player.transform;
        }
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
