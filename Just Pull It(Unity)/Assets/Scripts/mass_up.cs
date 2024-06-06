using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class mass_up : MonoBehaviour
{
    public UnityEngine.UI.Slider slider;
    public float sliderDuration = 12f;
    public float resetValue = 12f;
    private Coroutine currentSliderCoroutine;

    public Rigidbody playerRigidbody;
    public GameObject playerGameObject;
    [SerializeField] float Massup;
    [SerializeField] float Massdown;
    [SerializeField] float powerupDuration;
    private bool isPowerupActive = false;
    private float playermass;

    AudioManager audiomanager;

    private void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerGameObject = GameObject.Find("Player");
        playermass = playerRigidbody.mass;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mass-up"))
        {
            Destroy(other.gameObject);
            audiomanager.PlaySFX(audiomanager.Om_Nom);

            if (!isPowerupActive)
            {
                isPowerupActive = true;
                StartCoroutine(MassUpForDuration());
            }
        }

        if (other.gameObject.CompareTag("Mass-Down"))
        {
            Destroy(other.gameObject);  
            audiomanager.PlaySFX(audiomanager.Eating);

            if (!isPowerupActive)
            {
                isPowerupActive = true;
                StartCoroutine(MassDownForDuration());
            }

        }
    }

    /*private void MassUpPlayer()
    {
        playerRigidbody.mass = Massup;
    }
    */
    IEnumerator MassUpForDuration()
    {
        playerRigidbody.mass = Massup;
        yield return new WaitForSeconds(powerupDuration);
        playerRigidbody.mass = playermass;
        isPowerupActive = false;
    }

    /*private void MassDownPlayer()
    {
        playerRigidbody.mass = Massdown;
    }
    */
    IEnumerator MassDownForDuration()
    {
        playerRigidbody.mass = Massdown;
        yield return new WaitForSeconds(powerupDuration);
        playerRigidbody.mass = playermass;
        isPowerupActive = false;
    }

}