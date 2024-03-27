using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public GameObject target;
    public Transform pointA; // 출발 지점
    public Transform pointB; // 도착 지점
    public float speed = 2.0f; // 이동 속도

    private Vector3 targetPosition;

    void Start()
    {
        // 초기 타겟 위치는 A 지점으로 설정
        targetPosition = pointA.position;
    }

    void Update()
    {
        // 현재 위치에서 타겟 위치까지 이동
        target.transform.position = Vector3.MoveTowards(target.transform.position, targetPosition, speed * Time.deltaTime);

        // 만약 오브젝트가 타겟 위치에 도착했다면
        if (target.transform.position == targetPosition)
        {
            // 타겟 위치를 반대로 변경
            if (targetPosition == pointA.position)
                targetPosition = pointB.position;
            else
                targetPosition = pointA.position;
        }
    }
}
