using UnityEngine;

public class FillRoomInfos : MonoBehaviour
{
    [SerializeField] RoomInfosScript RoomInfo;
    private void Start()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        RoomInfo.RoomLTPosition = children[0].position;
        RoomInfo.RoomMTPosition = children[1].position;
        RoomInfo.RoomRTPosition = children[2].position;
        RoomInfo.RoomLMPosition = children[3].position;
        RoomInfo.RoomMMPosition = children[4].position;
        RoomInfo.RoomRMPosition = children[5].position;
        RoomInfo.RoomLLPosition = children[6].position;
        RoomInfo.RoomMLPosition = children[7].position;
        RoomInfo.RoomRLPosition = children[8].position;
    }
}
