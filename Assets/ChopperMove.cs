using UnityEngine;

public class ChopperMove : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotationSpeed = 10;

    float vertical;
    float horizonal;

    Vector3 moveVector;
    Vector3 rotationVector;

    Rigidbody rb;
    Transform fuselage;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fuselage = this.gameObject.transform.GetChild(0);
    }
    // Update is called once per frame
    void Update()
    {
        MoveChopper();
        RotateFuselage();       
    }
    void FixedUpdate()
    { 
        rb.AddRelativeForce(moveVector);
        rb.AddTorque(rotationVector);
    }
    private void MoveChopper()
    {
        vertical = Input.GetAxis("Vertical") ;
        horizonal = Input.GetAxis("Horizontal") ;

        moveVector = new Vector3(0, 0, vertical  * moveSpeed * 100);
        rotationVector = new Vector3(0, horizonal * rotationSpeed, 0);
    }
    private void RotateFuselage()
    {
        float pitch = Mathf.Abs(vertical) > 0 ? vertical * 30 : 0;
        float roll = Mathf.Abs(horizonal) > 0 ? horizonal * -60 : 0;

        Quaternion rotationTarget = Quaternion.Euler(pitch, 0, roll);
        Quaternion rotation = Quaternion.Lerp(fuselage.transform.localRotation, rotationTarget, Time.deltaTime * 2);

        fuselage.transform.localRotation = rotation;
    }
}
