using UnityEngine;
using UnityEngine.Events;

public class CameraShake : MonoBehaviour
{
    public UnityEvent shakeCamera;

    public void Shake()
    {
        shakeCamera.Invoke();
    }
}