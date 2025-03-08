using UnityEngine;

public class QuittingScript : MonoBehaviour
{
    float currentTime;
    float delay;

    private void OnEnable()
    {
        currentTime = Time.time;
        delay = 6;
    }

    private void Update()
    {
        if(currentTime + delay < Time.time)
        {
            Application.Quit();
            #if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}
