using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PulsarMando : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public Interactable interactable;
    float lastGrip;

    public SteamVR_Action_Single gripSqueeze = SteamVR_Input.GetAction<SteamVR_Action_Single>("Squeeze");
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        if (rigidbody == null)
            rigidbody = GetComponent<Rigidbody>();

        if (interactable == null)
            interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        float grip = 0;

        if (interactable.attachedToHand)
        {
            grip = gripSqueeze.GetAxis(interactable.attachedToHand.handType);
        }
        if(grip == 1f && grip != lastGrip)
        {
            StartCoroutine(EncenderTele());
        }
        lastGrip = grip;
    }

    IEnumerator EncenderTele()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
        }
        else
        {
            videoPlayer.Play();
        }
        yield return 0;
    }
}
