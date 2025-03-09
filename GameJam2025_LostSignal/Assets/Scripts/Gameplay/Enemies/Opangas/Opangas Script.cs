using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class OpangasScript : MonoBehaviour
{
    protected float lastTime;
    protected float delay;
    protected int chance;
    protected bool currentlyAttacking;
    [HideInInspector]
    public RoomManager.RoomState lastAttackedRoom;
    protected OpangasAttack attackScript;
    [SerializeField] float minDelay;
    [SerializeField] float maxDelay;

    [Header("Heya, wir brauchen die Infos für die Räume und so")]
    [Space(10)]
    [SerializeField] protected RoomInfosScript RoomInfos;

    [Space(20)]
    [Header("Audio Sachen halt")]
    public AudioSource[] sounds;

   protected virtual void Start()
    {
        ButtonManager.TerminatingRoom += AreWeCooked;
        lastTime = Time.time;
        delay = Random.Range(minDelay, maxDelay);
        currentlyAttacking = false;
        attackScript = GetComponent<OpangasAttack>();

        //foreach (var entry in RoomInfos.AttackedRooms) Debug.Log($"Wir haben {entry.Key} der folgende Antwort hat ob er angegriffen wird: {entry.Value}");
    }

    protected virtual void Update()
    {

        if (currentlyAttacking)
        {
            RoomInfos.volume = 0.1f;
            attackScript.enabled = true;
        }
        else RoomInfos.volume = 0;
        if (attackScript.enabled && !currentlyAttacking) attackScript.enabled = false;
        if ((!currentlyAttacking && lastTime + delay < Time.time))
        {
            //Debug.Log("Opanga is on the Move!");
            ResetAttack();
            chance = Random.Range(0, 101);
            currentlyAttacking = true;
            // 60% für Mitte
            if (chance <= 60)
            {
                //Debug.Log("Opanga geht Mitte!");
                AttackRoom(RoomManager.RoomState.MM, RoomInfos.RoomMMPosition);
                if(currentlyAttacking) PlaySound();
                return;
            }
            // 30% für Kreuz
            if (chance <= 90) 
            {
                // Da es 4 Möglichkeiten gibt muss es fair aufgeteilt werden
                chance = Random.Range(0, 100);
                switch (chance % 4)
                {
                    case 0:
                        AttackRoom(RoomManager.RoomState.LM, RoomInfos.RoomLMPosition);
                        break;
                    case 1:
                        AttackRoom(RoomManager.RoomState.MT, RoomInfos.RoomMTPosition);
                        break;
                    case 2:
                        AttackRoom(RoomManager.RoomState.ML, RoomInfos.RoomMLPosition);
                        break;
                    case 3:
                        AttackRoom(RoomManager.RoomState.RM, RoomInfos.RoomRMPosition);
                        break;
                }
                //Debug.Log("Opanga greift Kreuzartig an!");
                if (currentlyAttacking) PlaySound();
                return;
            }
            // 10% für Diagonal
            chance = Random.Range(0, 100);
            switch (chance % 4)
            {
                case 0:
                    AttackRoom(RoomManager.RoomState.LT, RoomInfos.RoomLTPosition);
                    break;
                case 1:
                    AttackRoom(RoomManager.RoomState.LL, RoomInfos.RoomLLPosition);
                    break;
                case 2:
                    AttackRoom(RoomManager.RoomState.RT, RoomInfos.RoomRTPosition);
                    break;
                case 3:
                    AttackRoom(RoomManager.RoomState.RL, RoomInfos.RoomRLPosition);
                    break;
            }
            //Debug.Log("Opanga greift Diagonal an!");
            if (currentlyAttacking) PlaySound();
        }
    }

    protected virtual void AttackRoom(RoomManager.RoomState targetedRoom, Vector3 newPosition)
    {
        if (RoomInfos.AttackedRooms[targetedRoom] == true) 
        {
            currentlyAttacking = false;
            RoomInfos.volume = 0;
            return; 
        };
        transform.position = newPosition;
        RoomInfos.AttackedRooms[targetedRoom] = true;
        lastAttackedRoom = targetedRoom;
    }
    protected virtual void AreWeCooked(RoomManager.RoomState state)
    {
        if (state != lastAttackedRoom) return;
        ResetAttack();
    }

    protected virtual void ResetAttack()
    {
        RoomInfos.AttackedRooms[lastAttackedRoom] = false;
        lastTime = Time.time;
        delay = Random.Range(minDelay,maxDelay);
        currentlyAttacking = false;
    }

    protected virtual void PlaySound()
    {
        int soundIndex= Random.Range(0, sounds.Length - 1);
        float newPitch = Random.Range(1.25f, 2.5f);
        sounds[soundIndex].pitch = newPitch;
        sounds[soundIndex].Play();
    }
}
