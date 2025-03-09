using UnityEngine;
using UnityEngine.SceneManagement;

public class ChainsawScript : MonoBehaviour
{
    float lastTime;
    float delay;
    float chance;
    bool killingBlow;
    [SerializeField] float minDelay,maxDelay;
    [SerializeField] RoomInfosScript RoomInfo;
    [SerializeField] AudioSource chainsawNoise;
    [SerializeField] AudioSource chainsawJumpScare;
    [SerializeField] GameObject JumpScareCanvas;
    RoomManager.RoomState currentlyAttacking;

    private void Start()
    {
        ButtonManager.TerminatingRoom += AreWeCooked;
        lastTime = Time.time;
        delay = Random.Range(minDelay,maxDelay);

    }

    private void Update()
    {
        if(currentlyAttacking == RoomManager.RoomState.None && lastTime + delay < Time.time)
        {
            RoomInfo.volume = 0.1f;
            chance = Random.Range(0, 101);
            switch(chance % 9)
            {
                case 0:
                    AttackRoom(RoomManager.RoomState.LT,RoomInfo.RoomLTPosition); break;
                case 1:
                    AttackRoom(RoomManager.RoomState.MT, RoomInfo.RoomMTPosition); break;
                case 2:
                    AttackRoom(RoomManager.RoomState.RT, RoomInfo.RoomRTPosition); break;
                case 3:
                    AttackRoom(RoomManager.RoomState.LM, RoomInfo.RoomLMPosition); break;
                case 4:
                    AttackRoom(RoomManager.RoomState.MM, RoomInfo.RoomMMPosition); break;
                case 5:
                    AttackRoom(RoomManager.RoomState.RM, RoomInfo.RoomRMPosition); break;
                case 6:
                    AttackRoom(RoomManager.RoomState.LL, RoomInfo.RoomLLPosition); break;
                case 7:
                    AttackRoom(RoomManager.RoomState.ML, RoomInfo.RoomMLPosition); break;
                case 8:
                    AttackRoom(RoomManager.RoomState.RL, RoomInfo.RoomRLPosition); break;
            }
            
        }
        if(currentlyAttacking != RoomManager.RoomState.None && !chainsawNoise.isPlaying)
        {
            chainsawJumpScare.Play();
            currentlyAttacking = RoomManager.RoomState.None;
            killingBlow = true;
            return;
        }
        if(killingBlow && !chainsawJumpScare.isPlaying)
        {
            SceneManager.LoadScene("Lose Screen");
        }
    }

    void AttackRoom(RoomManager.RoomState state, Vector3 position)
    {
        if (RoomInfo.AttackedRooms[state])
        {
            currentlyAttacking = RoomManager.RoomState.None;
            return;
            
        }
        currentlyAttacking = state;
        transform.position = position;
        RoomInfo.AttackedRooms[state] = true;
        chainsawNoise.Play();
    }
    private void AreWeCooked(RoomManager.RoomState state)
    {
        if (state != currentlyAttacking) return;
        ResetAttack();
    }

    private void ResetAttack()
    {
        chainsawNoise.Stop();
        RoomInfo.AttackedRooms[currentlyAttacking] = false;
        currentlyAttacking = RoomManager.RoomState.None;
        lastTime = Time.time;
        delay = Random.Range(minDelay, maxDelay);
    }

    
}
