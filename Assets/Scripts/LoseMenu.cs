using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMenu : MonoBehaviour
{
    [SerializeField] private AudioObject loseSound;

    private IEnumerator Start()
    {
        BackgroundMusicManager.Instance.SetBackgroundMusic(null);
        yield return new WaitUntil(() => BackgroundMusicManager.Instance.Volume() <= 0);
        Instantiate(loseSound);
    }
}
