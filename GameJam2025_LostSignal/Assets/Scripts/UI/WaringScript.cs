using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaringScript : MonoBehaviour
{
    [SerializeField] OptionsScript optionFile;
    Image panel;

    private void Start()
    {
        panel = GetComponent<Image>();
    }

    private void Update()
    {
        switch(optionFile.mistakes)
        {
            case 0:
                panel.color = Color.green; break;
            case 1:
                panel.color = Color.yellow; break;
            case 2:
                panel.color = Color.red; break;
            case 3:
                SceneManager.LoadScene("Lose Screen"); break;
            default:
                SceneManager.LoadScene("Lose Screen"); break;
        }
    }
}
