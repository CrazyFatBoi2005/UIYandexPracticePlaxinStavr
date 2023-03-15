using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform_;
    
    private void Start()
    {
        gameObject.transform.LookAt(playerTransform_);
    }
    
}
