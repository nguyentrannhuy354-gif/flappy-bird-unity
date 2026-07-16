using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private void Update()

    {
        //dịch chuyển pipe sang bên trái, lấy vị trí hiện tại cộng thêm cột x, vì transform là 3D nên dùng vector3, time.deltatime là để tùy chỉnh theo frame
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}

