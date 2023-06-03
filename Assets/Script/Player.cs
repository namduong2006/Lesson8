using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletPosition;
    [SerializeField] Rigidbody rb;
    [SerializeField]private float speed = 1000f;
    public float speedtorquewheel = 1f;
    public float torque = 10f;
    public int damaged = 0;
    public float fuel = 100;
    public int capacity = 100;
    public int laps = 0;
    public float tocDo;
    [SerializeField] public Vector3[] pointlaps;
    private int point = 0;
    [SerializeField] public Vector3[] pointFuel;
    public int checkpoinfuel=0;
    public Transform wheel1;
    public Transform wheel2;
    public WheelCollider w1right;
    public WheelCollider w1left;
    public WheelCollider w2right;
    public WheelCollider w2left;
    public GameObject particle;
    public int coin;
    private ButtonUp buttonUp;
    private void Awake()
    {
        
        rb=GetComponent<Rigidbody>();
        coin = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        buttonUp = FindObjectOfType<ButtonUp>();
        rb.centerOfMass=new Vector3 (0,0.8f,0);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        
    }
    public void MovePlayer()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        // colider banh sau quay
        w2left.motorTorque = speedtorquewheel * v;
        w2right.motorTorque = speedtorquewheel * v;
        // colider banh truoc xoay
        w1left.steerAngle = torque * h;
        w1right.steerAngle = torque * h;
        // 2 banh truoc va sau quay
        wheel1.Rotate(speedtorquewheel * Input.GetAxis("Vertical"), 0, 0);
        wheel2.Rotate(speedtorquewheel * Input.GetAxis("Vertical"), 0, 0);
        //banh truoc xoay
        wheel1.localEulerAngles = new Vector3(wheel1.localEulerAngles.x,
        torque * Input.GetAxis("Horizontal"), wheel1.localEulerAngles.z);
        // xe chay khong dung rigidbody
        //transform.position += v * transform.forward * Speed * Time.deltaTime;
        //Vector3 vector3 = transform.eulerAngles;
        //vector3.y += h * Speed * Time.deltaTime * 4;
        //transform.eulerAngles = vector3;
        // xe chay dung rigidbody
        rb.AddForce(transform.forward * speed * v);
        rb.AddTorque(Vector3.up * torque * h);              
        // an Space de ban dan
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, bulletPosition.position, transform.rotation);
        }
        if (damaged > 99||fuel<0.01)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        float m = GetSpeed();
        if (m > 2)
        {
            particle.SetActive(true);
        }
        else particle.SetActive(false);
    }
    
    public void MoveUp()
    {
        Vector3 up =new Vector3(0,0,Time.deltaTime*10);
        transform.Translate(up);
        
    }
    public void MoveDown()
    {
        Vector3 down=Vector3.back;
        transform.Translate(down*Time.deltaTime*10);
    }
    public void MoveLeft()
    {       
        transform.Rotate(0f,Time.deltaTime*(-10),0f);       
    }
    public void MoveRight()
    {       
        transform.Rotate(0f,10*Time.deltaTime, 0f);      
    }
    public int GetLapCount()
    {       
        Vector3 checkpoint = pointlaps[point];
        if (Vector3.Distance(checkpoint, transform.position) < 5f)
        {
            point++;
            
            if (point == pointlaps.Length)
            {
                laps ++;
                point = 0;                
            }
        }
        return laps;
    }
    public float GetSpeed()
    {
       return tocDo = rb.velocity.magnitude;
    }
    public void OnTriggerEnter(Collider other)
    {
        Vector3 fuels = pointFuel[checkpoinfuel];
        if (other.CompareTag("Fuel"))
        {
            fuel += 25;
            other.transform.position = fuels;
            checkpoinfuel++;
            if (checkpoinfuel == pointFuel.Length) checkpoinfuel = 0;                      
        }
        if (other.CompareTag("Capacity"))
        {
            capacity += 10;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Damaged-"))
        {
            damaged -= 30;
            Destroy(other.gameObject);
        }
        if (damaged < 0) damaged = 0;                      
        if (fuel > capacity) fuel = capacity;
        if (other.CompareTag("Damaged0"))
        {
            damaged = 0;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Coin"))
        {
            coin++;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {       
        if (collision.transform.CompareTag("Damaged+"))
        {
            damaged += 5;
        }       
    }
    public int Getcoin()
    {       
        return coin;
    }
}
