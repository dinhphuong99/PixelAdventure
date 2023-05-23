using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float speed = 2.0f; // Tốc độ chuyển động của con lắc
    public float angle = 45.0f; // Góc ban đầu của con lắc
    public float length = 3.0f; // Chiều dài của dây
    [SerializeField] private float direct = 1.0f; // hướng ban đầu khi mới di chuyển
    public GameObject weight; // Vật nặng của con lắc
    public GameObject mount; // Điểm treo của con lắc
    private Vector3 pivot; // Vị trí neo của con lắc
    private Vector3 bob; // Vị trí của vật nặng

    public float GetAngle()
    {
        return this.angle;
    }

    void Start()
    {
        pivot = mount.transform.position; // Lưu lại vị trí neo của con lắc
        bob = weight.transform.position; // Lưu lại vị trí của vật nặng
    }

    void Update()
    {
        angle = direct*Mathf.Sin(Time.time * speed) * 45.0f; // Tính toán góc mới của con lắc
        // Tính toán vị trí mới của vật nặng
        float x = Mathf.Sin(angle * Mathf.Deg2Rad) * length;
        float y = Mathf.Cos(angle * Mathf.Deg2Rad) * length;
        bob = pivot + new Vector3(x, -y, 0);

        weight.transform.position = bob; // Đặt lại vị trí của vật nặng
    }
}
