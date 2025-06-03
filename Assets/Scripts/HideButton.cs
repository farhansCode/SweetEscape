using UnityEngine;

public class HideOnPC : MonoBehaviour
{
    void Start()
    {
#if !UNITY_ANDROID
        gameObject.SetActive(true);
#endif
    }
}
