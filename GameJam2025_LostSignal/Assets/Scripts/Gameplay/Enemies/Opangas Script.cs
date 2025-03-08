using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class OpangasScript : MonoBehaviour
{
    float lastTime;
    float delay;
    int chance;
    bool currentlyAttacking;

    [Header("Heya, wir brauchen die Infos für die Räume und so")]
    [Space(10)]
    [SerializeField] RoomInfosScript RoomInfos;

    [Space(20)]
    [Header("Audio Sachen halt")]
    [Space(10)]
    [SerializeField] AudioSource[] sounds;

    private void Start()
    {
        lastTime = Time.time;
        delay = Random.Range(5f, 10f);
        currentlyAttacking = false;
    }

    private void Update()
    {
        if(!currentlyAttacking && lastTime + delay < Time.time)
        {
            //Debug.Log("Opanga is on the Move!");
            lastTime = Time.time;
            delay = Random.Range(5f, 10f);
            chance = Random.Range(0, 100);
            currentlyAttacking = true;

            if(chance <= 60) // 60% für Mitte
            {
                //Debug.Log("Opanga geht Mitte!");
                transform.position = RoomInfos.RoomMMPosition;
                RoomInfos.AttackingRoomMMPosition = true;
                PlaySound();
                return;
            }
            if(chance <= 90) // 30% für Kreuz
            {
                // Da es 4 Möglichkeiten gibt muss es fair aufgeteilt werden
                chance = Random.Range(0, 100);
                switch(chance % 4)
                {
                    case 0:
                        transform.position = RoomInfos.RoomLMPosition;
                        RoomInfos.AttackingRoomLMPosition = true;
                        break;
                    case 1:
                        transform.position = RoomInfos.RoomMTPosition;
                        RoomInfos.AttackingRoomMTPosition = true;
                        break;
                    case 2:
                        transform.position = RoomInfos.RoomMLPosition;
                        RoomInfos.AttackingRoomMLPosition = true;
                        break;
                    case 3:
                        transform.position = RoomInfos.RoomRMPosition;
                        RoomInfos.AttackingRoomRMPosition = true;
                        break;
                }
                //Debug.Log("Opanga greift Kreuzartig an!");
                PlaySound();
                return;
            }
            // 10% für Diagonal
            chance = Random.Range(0, 100);
            switch (chance % 4)
            {
                case 0:
                    transform.position = RoomInfos.RoomLTPosition;
                    RoomInfos.AttackingRoomLTPosition = true;
                    break;
                case 1:
                    transform.position = RoomInfos.RoomLLPosition;
                    RoomInfos.AttackingRoomLLPosition = true;
                    break;
                case 2:
                    transform.position = RoomInfos.RoomRTPosition;
                    RoomInfos.AttackingRoomRTPosition = true;
                    break;
                case 3:
                    transform.position = RoomInfos.RoomRLPosition;
                    RoomInfos.AttackingRoomRLPosition = true;
                    break;
            }
            //Debug.Log("Opanga greift Diagonal an!");
            PlaySound();
        }
    }

    private void PlaySound()
    {
        int soundIndex= Random.Range(0, sounds.Length - 1);
        float newPitch = Random.Range(1.25f, 2.5f);
        sounds[soundIndex].pitch = newPitch;
        sounds[soundIndex].Play();
    }
}
