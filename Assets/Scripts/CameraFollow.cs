using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow: MonoBehaviour
{
    public Transform target; //따라갈 대상인 플레이어
    public float smoothSpeed = 5f; //따라가는 속도
    public Vector2 minBounds; //카메라가 도달가능한 최소위치
    public Vector2 maxBounds; //카메라가 도달가능한 최대위치

   public Vector3 offset = new Vector3(0f, 0f, -10f); //카메라와 플레이어 간의 초기 위치

     void Start()
    {
        //초기 거리 설정
        offset = transform.position - target.position;
    }

    private void LateUpdate()   //캐릭터의 이동이 끝난 후 카메라가 이동할 수 있게
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z; //따라가야 할 위치를 계산, z값은 유지

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);
        
        //위치 제한을 적용시킴


        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        
    }

}
