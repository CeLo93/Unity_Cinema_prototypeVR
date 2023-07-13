using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip video1;
    public VideoClip video2;
    public VideoClip video3;

    private bool isPlaying = false;
    private bool paused = false;
    private double currentFrame = 0;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoLoopPointReached;
    }

    void Update()
    {
        HandleInputs();
    }

    void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayVideo(video1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayVideo(video2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayVideo(video3);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPlaying && !paused)
            {
                PauseVideo();
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isPlaying && paused)
            {
                ResumeVideo();
            }
        }
    }

    void PlayVideo(VideoClip clip)
    {
        videoPlayer.clip = clip;
        videoPlayer.Prepare();

        isPlaying = true;
        paused = false;

        videoPlayer.Play();
    }

    void PauseVideo()
    {
        paused = true;
        isPlaying = false;

        currentFrame = videoPlayer.time;

        videoPlayer.Pause();
    }

    void ResumeVideo()
    {
        paused = false;
        isPlaying = true;

        videoPlayer.Play();
        videoPlayer.time = currentFrame;
    }

    void OnVideoLoopPointReached(VideoPlayer player)
    {
        isPlaying = false;
    }
}
