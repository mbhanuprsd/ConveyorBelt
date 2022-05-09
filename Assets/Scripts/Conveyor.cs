using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Conveyor : MonoBehaviour
{
    public float speed;
    Rigidbody rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = rBody.position;
        rBody.position += Vector3.back * speed * Time.fixedDeltaTime;
        rBody.MovePosition(pos);
    }
}
