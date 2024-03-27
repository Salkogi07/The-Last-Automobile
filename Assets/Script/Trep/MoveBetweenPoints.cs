using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public GameObject target;
    public Transform pointA; // ��� ����
    public Transform pointB; // ���� ����
    public float speed = 2.0f; // �̵� �ӵ�

    private Vector3 targetPosition;

    void Start()
    {
        // �ʱ� Ÿ�� ��ġ�� A �������� ����
        targetPosition = pointA.position;
    }

    void Update()
    {
        // ���� ��ġ���� Ÿ�� ��ġ���� �̵�
        target.transform.position = Vector3.MoveTowards(target.transform.position, targetPosition, speed * Time.deltaTime);

        // ���� ������Ʈ�� Ÿ�� ��ġ�� �����ߴٸ�
        if (target.transform.position == targetPosition)
        {
            // Ÿ�� ��ġ�� �ݴ�� ����
            if (targetPosition == pointA.position)
                targetPosition = pointB.position;
            else
                targetPosition = pointA.position;
        }
    }
}
