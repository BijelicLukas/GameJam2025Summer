using UnityEngine;

public class FillRoomInfos : MonoBehaviour
{
    [SerializeField] RoomInfosScript RoomInfo;
    private void Start()
    {
        //int count = 0;
        Transform[] children = GetComponentsInChildren<Transform>();
        //foreach (Transform child in children) { Debug.Log($"{child.name} ist die {count} Stelle und hat die Position {child.position}"); count++; }
        RoomInfo.RoomLTPosition = children[1].position;
        RoomInfo.RoomMTPosition = children[2].position;
        RoomInfo.RoomRTPosition = children[3].position;
        RoomInfo.RoomLMPosition = children[4].position;
        RoomInfo.RoomMMPosition = children[5].position;
        RoomInfo.RoomRMPosition = children[6].position;
        RoomInfo.RoomLLPosition = children[7].position;
        RoomInfo.RoomMLPosition = children[8].position;
        RoomInfo.RoomRLPosition = children[9].position;

        RoomInfo.FillDictionary();
    }
}
