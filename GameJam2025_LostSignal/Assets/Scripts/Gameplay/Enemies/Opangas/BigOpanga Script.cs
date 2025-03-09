using UnityEngine;

public class BigOpangaScript : OpangasScript
{
    protected override void Update()
    {
        if (currentlyAttacking) attackScript.enabled = true;
        if (attackScript.enabled && !currentlyAttacking) attackScript.enabled = false;
        if ((!currentlyAttacking && lastTime + delay < Time.time))
        {
            ResetAttack();
            chance = Random.Range(0, 101);
            currentlyAttacking = true;
            RoomInfos.volume = 0.1f;
            // 60% Links Rechts
            if(chance <= 60)
            {
                chance = Random.Range(0, 100);
                switch(chance % 2)
                {
                    case 0:
                        AttackRoom(RoomManager.RoomState.LM, RoomInfos.RoomLMPosition);
                        break;
                    case 1:
                        AttackRoom(RoomManager.RoomState.RM, RoomInfos.RoomRMPosition);
                        break;
                }
                if (currentlyAttacking) PlaySound();
                return;
            }
            // 30% Links Rechts Außen
            if(chance <= 90)
            {
                chance = Random.Range(0, 100);
                switch(chance % 4) 
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
                PlaySound();
                return;
            }
            // 10% Mitte allgemein
            chance = Random.Range(0, 100);
            switch(chance % 3)
            {
                case 0:
                    AttackRoom(RoomManager.RoomState.MT, RoomInfos.RoomMTPosition);
                    break;
                case 1:
                    AttackRoom(RoomManager.RoomState.MM, RoomInfos.RoomMMPosition);
                    break;
                case 2:
                    AttackRoom(RoomManager.RoomState.ML, RoomInfos.RoomMLPosition);
                    break;
            }
            if (currentlyAttacking) PlaySound();
        }
    }

    protected override void PlaySound()
    {
        int soundIndex = Random.Range(0, sounds.Length - 1);
        float newPitch = Random.Range(0.45f, 0.75f);
        sounds[soundIndex].pitch = newPitch;
        sounds[soundIndex].Play();
    }
}
