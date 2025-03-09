using UnityEngine;
using UnityEngine.SceneManagement;

public class FakerAttackScript : MonoBehaviour
{
    float lastTime;
    [SerializeField] float TimeTillAttack;
    bool killing;

    [Header("Death Thingy")]
    [SerializeField] AudioSource Jumpscare;
    [SerializeField] GameObject JumpscareCanvas;

    private void Start()
    {
        killing = false;
    }
    private void OnEnable()
    {
        lastTime = Time.time;
    }

  

    private void Update()
    {
        if(!killing && lastTime + TimeTillAttack < Time.time)
        {
            GetComponent<FakersScript>().enabled = false;
            transform.position = new Vector3(0, 6.5f, -0.3f);
            JumpscareCanvas.SetActive(true);
            Jumpscare.Play();
            killing = true;
        }
        if (killing && !Jumpscare.isPlaying) SceneManager.LoadScene("Lose Screen");
    }

}
