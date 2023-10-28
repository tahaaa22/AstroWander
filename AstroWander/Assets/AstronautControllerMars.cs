using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class AstronautControllerMars : MonoBehaviour
{
   
    public Animator astronautAnimator;
    public AudioSource audioSource;
    public AudioClip welcomeClip;
    
    public AudioClip finalClip;
    public GameObject holographicPanel1;
    public GameObject holographicPanel2;
    public VideoPlayer videoPlayer1;


    public static AstronautControllerMars instance;
    public float LERP = 0.1f;
    public Transform target;

    public float movementThreshold = 0.3f;

    public bool isPlayingDialogue = false;
    public bool hasPlayedFinalDialogue = false;
    public bool shouldPlayFinalDialogue = false;
    public bool audio1 = true; // set false when audio finished
    public bool isVideoPlaying = true;
    public bool midclip1 = true; // set false when audio finished

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
    private void Start()
    {
        // Start with the welcome dialogue when the scene begins.
        astronautAnimator = GetComponent<Animator>();
        holographicPanel1.SetActive(false);
        holographicPanel2.SetActive(false);
        PlayWelcomeDialogue();
        StartCoroutine(StopWaving());
    }
    private void Update()
    {
        astronautAnimator.SetBool("talking", audioSource.isPlaying);

        if (audioSource.isPlaying == false && audio1)
        {
            ///play video
            holographicPanel1.SetActive (true);
            videoPlayer1.Play(); // Play the video
            audio1 = false; // set false when audio finished
            shouldPlayFinalDialogue = true;
        }

        if (shouldPlayFinalDialogue)
        {
            // If shouldPlayFinalDialogue is true, play the final dialogue
            StartCoroutine(WaitForDialogueCompletionAndPlayFinal());
            shouldPlayFinalDialogue = false; // Reset the flag
        }
        if (hasPlayedFinalDialogue == true)
        {
            SceneManager.LoadScene(0);
        }

        //transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, LERP);
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
        yield return new WaitForSeconds(1);
        astronautAnimator.SetBool("Wave", false);
    }
    public void PlayWelcomeDialogue()
    {
        StartCoroutine(GotToTarget());
        astronautAnimator.SetBool("Wave", true);

        // Play the welcome audio clip
        audioSource.clip = welcomeClip;
        audioSource.Play();

    }

    public void PlayFinalDialogue()
    {
        StartCoroutine(GotToTarget());
        PlaySound(finalClip);

        Debug.Log("PlayFinalDialogue called.");


    }
    private IEnumerator WaitForDialogueCompletionAndPlayFinal()
    {
        if (isPlayingDialogue)
        {
            yield return null;
        }

        // When the current dialogue is finished, play the final dialogue
        yield return new WaitForSeconds(60);
        holographicPanel2.SetActive(true);
        //StartCoroutine(WaitSecond());
        PlayFinalDialogue();
        yield return new WaitForSeconds(92);
        
        hasPlayedFinalDialogue = true;
        //Destroy(gameObject);
    }
    IEnumerator WaitSecond()
    {
        PlayFinalDialogue();
        yield return new WaitForSeconds(25);
        
        
            // Transition to the next scene
            //SceneManager.LoadScene(1);
        
        hasPlayedFinalDialogue = true;
        //Destroy(gameObject);
    }
    public void PlaySound(AudioClip clip)
    {
        StartCoroutine(GotToTarget());

        audioSource.clip = clip;
        audioSource.Play();

        isPlayingDialogue = true;

    }

    public void StopDialogue()
    {
        isPlayingDialogue = false;
    }

}
