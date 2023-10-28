using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AstronautController : MonoBehaviour
{
    public Animator astronautAnimator;
    public AudioSource audioSource;
    public AudioClip welcomeClip;



    public static AstronautController instance;
    public float LERP = 0.1f;
    public Transform target;
    //public Transform target, itemTarget;
    [field: SerializeField] public int collectedCount { get; set; } = 0;

    public float movementThreshold = 0.3f;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        // Start with the welcome dialogue when the scene begins.
        astronautAnimator = GetComponent<Animator>();
        PlayWelcomeDialogue();
        StartCoroutine(StopWaving());
    }
    //private IEnumerator welcomeAudio()
    //{
    //    yield return new WaitForSeconds(3);
        
    //    PlaySound(welcomeClip);
    //}
    //private void FixedUpdate()
    //{
    //    astronautAnimator.SetBool("talking", audioSource.isPlaying);
    //}
    private void Update()
    {
        astronautAnimator.SetBool("talking", audioSource.isPlaying);

    }
    private IEnumerator GotToTarget()
    {
        var targetPosition = target.position;
        while (Vector3.Distance(transform.position, targetPosition) > movementThreshold)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, LERP);
            transform.LookAt(Camera.main.transform.position);
            yield return null;
        }
    }
    private IEnumerator StopWaving()
    {
        yield return new WaitForSeconds(2);
       // astronautAnimator.Stop("WavingGesture");
    }
    public void PlayWelcomeDialogue()
    {
        astronautAnimator.Play("WavingGesture");
        //astronautAnimator.SetBool("Wave", true);
        StartCoroutine(GotToTarget());
        PlaySound(welcomeClip);

    }

    private void PlaySound(AudioClip clip)
    {
        StartCoroutine(GotToTarget());

        audioSource.clip = clip;
        audioSource.Play();

    }

}
