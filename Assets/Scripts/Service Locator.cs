using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public static class ServiceLocator
{
    private static AudioPlayer _audioPlayer;

    public static void RegisterAudioPlayer(AudioPlayer audioPlayer)
    {
        _audioPlayer = audioPlayer;
    }

    public static AudioPlayer GetAudioPlayer()
    {
        if (_audioPlayer == null)
        {
            Debug.LogError("AudioPlayer has not been registered in the Service Locator.");
        }
        return _audioPlayer;
    }
}
