using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class OpangasScript : MonoBehaviour
{
    float lastTime;
    float delay;
    int chance;
    protected bool currentlyAttacking;
    protected RoomManager.RoomState lastAttackedRoom;

    [Header("Heya, wir brauchen die Infos für die Räume und so")]
    [Space(10)]
    [SerializeField] protected RoomInfosScript RoomInfos;

    [Space(20)]
    [Header("Audio Sachen halt")]
    [Space(10)]
    [SerializeField] AudioSource[] sounds;

   protected virtual void Start()
    {
        RoomInfos.FillDictionary();
        lastTime = Time.time;
        delay = Random.Range(5f, 10f);
        currentlyAttacking = false;

        //foreach (var entry in RoomInfos.AttackedRooms) Debug.Log($"Wir haben {entry.Key} der folgende Antwort hat ob er angegriffen wird: {entry.Value}");
    }

    protected virtual void Update()
    {
        if ((!currentlyAttacking && lastTime + delay < Time.time))
        {
            //Debug.Log("Opanga is on the Move!");
            RoomInfos.AttackedRooms[lastAttackedRoom] = false;
            lastTime = Time.time;
            delay = Random.Range(5f, 10f);
            chance = Random.Range(0, 100);
            currentlyAttacking = true;

            if (chance <= 60) // 60% für Mitte
            {
                Debug.Log("Opanga geht Mitte!");
                if (RoomInfos.AttackedRooms[RoomManager.RoomState.MM] == true) { currentlyAttacking = false; return; }
                transform.position = RoomInfos.RoomMMPosition;
                RoomInfos.AttackedRooms[RoomManager.RoomState.MM] = true;
                lastAttackedRoom = RoomManager.RoomState.MM;
                PlaySound();
                return;
            }
            if (chance <= 90) // 30% für Kreuz
            {
                // Da es 4 Möglichkeiten gibt muss es fair aufgeteilt werden
                chance = Random.Range(0, 100);
                switch (chance % 4)
                {
                    case 0:
                        if (RoomInfos.AttackedRooms[RoomManager.RoomState.LM] == true) { currentlyAttacking = false; return; }
                        transform.position = RoomInfos.RoomLMPosition;
                        RoomInfos.AttackedRooms[RoomManager.RoomState.LM] = true;
                        lastAttackedRoom = RoomManager.RoomState.LM;
                        break;
                    case 1:
                        if (RoomInfos.AttackedRooms[RoomManager.RoomState.MT] == true) { currentlyAttacking = false; return; }
                        transform.position = RoomInfos.RoomMTPosition;
                        RoomInfos.AttackedRooms[RoomManager.RoomState.MT] = true;
                        lastAttackedRoom = RoomManager.RoomState.MT;
                        break;
                    case 2:
                        if (RoomInfos.AttackedRooms[RoomManager.RoomState.ML] == true) { currentlyAttacking = false; return; }
                        transform.position = RoomInfos.RoomMLPosition;
                        RoomInfos.AttackedRooms[RoomManager.RoomState.ML] = true;
                        lastAttackedRoom = RoomManager.RoomState.ML;
                        break;
                    case 3:
                        if (RoomInfos.AttackedRooms[RoomManager.RoomState.RM] == true) { currentlyAttacking = false; return; }
                        transform.position = RoomInfos.RoomRMPosition;
                        RoomInfos.AttackedRooms[RoomManager.RoomState.RM] = true;
                        lastAttackedRoom = RoomManager.RoomState.RM;
                        break;
                }
                Debug.Log("Opanga greift Kreuzartig an!");
                PlaySound();
                return;
            }
            // 10% für Diagonal
            chance = Random.Range(0, 100);
            switch (chance % 4)
            {
                case 0:
                    if (RoomInfos.AttackedRooms[RoomManager.RoomState.LT] == true) { currentlyAttacking = false; return; }
                    transform.position = RoomInfos.RoomLTPosition;
                    RoomInfos.AttackedRooms[RoomManager.RoomState.LT] = true;
                    lastAttackedRoom = RoomManager.RoomState.LT;
                    break;
                case 1:
                    if (RoomInfos.AttackedRooms[RoomManager.RoomState.LL] == true) { currentlyAttacking = false; return; }
                    transform.position = RoomInfos.RoomLLPosition;
                    RoomInfos.AttackedRooms[RoomManager.RoomState.LL] = true;
                    lastAttackedRoom = RoomManager.RoomState.LL;
                    break;
                case 2:
                    if (RoomInfos.AttackedRooms[RoomManager.RoomState.RT] == true) { currentlyAttacking = false; return; }
                    transform.position = RoomInfos.RoomRTPosition;
                    RoomInfos.AttackedRooms[RoomManager.RoomState.RT] = true;
                    lastAttackedRoom = RoomManager.RoomState.RT;
                    break;
                case 3:
                    if (RoomInfos.AttackedRooms[RoomManager.RoomState.RL] == true) { currentlyAttacking = false; return; }
                    transform.position = RoomInfos.RoomRLPosition;
                    RoomInfos.AttackedRooms[RoomManager.RoomState.RL] = true;
                    lastAttackedRoom = RoomManager.RoomState.RL;
                    break;
            }
            Debug.Log("Opanga greift Diagonal an!");
            PlaySound();
        }
    }

    protected void PlaySound()
    {
        int soundIndex= Random.Range(0, sounds.Length - 1);
        float newPitch = Random.Range(1.25f, 2.5f);
        sounds[soundIndex].pitch = newPitch;
        sounds[soundIndex].Play();
    }
}
