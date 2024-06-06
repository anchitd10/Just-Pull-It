using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

//using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using static UnityEditor.Timeline.TimelinePlaybackControls;

public class pull_up : MonoBehaviour
{
    private Camera mainCamera;

    public Rigidbody rb;
    public GameObject player;

    [SerializeField] float speed;
    [SerializeField] float upForce = 0.0f;
    //private bool isHolding = false;
    //private bool isTouching = false;
    private InputAction touchAction;

    public GameObject EndMenuUI;

    AudioManager audiomanager;

    private void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        //audiomanager = FindObjectOfType<AudioManager>();
        if (audiomanager == null)
        {
            Debug.LogError("AudioManager not found or AudioManager GameObject is missing the 'Audio' tag.");
        }

        /*touchAction = new InputAction("TouchPress");
        touchAction.Enable();

        touchAction.performed += _ => isHolding = true;
        touchAction.canceled += _ => isHolding = false;*/
    }

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        /*Vector3 forwardMove = transform.forward * speed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMove);*/
    }

    void Update()
    {
        //touchInput();

        if (Input.GetKey(KeyCode.Space))
        {
            applyUpwardForce();
        }

        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == UnityEngine.TouchPhase.Began || touch.phase == UnityEngine.TouchPhase.Moved || touch.phase == UnityEngine.TouchPhase.Stationary)
            {
                isTouching = true;
                applyUpwardForce();
                Debug.Log("Touch detected");
            }
            else if (touch.phase == UnityEngine.TouchPhase.Ended)
            {
                isTouching = false;
            }
        }
        // If no touches, reset the flag
        else
        {
            isTouching = false;
        }*/
        
        /*if (touchAction.triggered) // Check for touch press event
        {
            applyUpwardForce();
        }
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Object"))
        {
            Debug.Log("Object collided with trigger."); 
            //Destroy(collision.gameObject);
            audiomanager.PlaySFX(audiomanager.Crash);
            Debug.Log("Object destroyed.");
            EndMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void applyUpwardForce()
    {
        rb.AddForce(Vector3.up * upForce, ForceMode.Impulse);
    }





    /*private void touchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                applyUpwardForce();
            }
        }
    }*/

    /*private void touchInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastFromTouch(ray);
        }
        //if (Input.GetMouseButtonDown(0))
        //{
           // Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
         //   RaycastFromTouch(ray);
        //}
    }
    private void RaycastFromTouch(Ray ray)
    {
        RaycastHit hit;
        int layerMask = 1 << 9;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            GameObject tappedObject = hit.collider.gameObject;
            applyUpwardForce();
        }
    }*/
}

