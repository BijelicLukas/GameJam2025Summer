using UnityEngine;
using UnityEngine.SceneManagement;

public class OpangasKillScript : MonoBehaviour
{
    [SerializeField] AudioSource Jumpscare;

    private void OnEnable()
    {
        GetComponent<OpangasScript>().enabled = false;
        GetComponent<OpangasAttack>().enabled = false;
        transform.position = new Vector3(0, 6.5f, -0.3f);
        Jumpscare.Play();
    }
    private void Update()
    {
        if(!Jumpscare.isPlaying)
        {
            SceneManager.LoadScene("Lose Screen");
        }
    }


}
