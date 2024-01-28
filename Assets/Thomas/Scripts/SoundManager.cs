using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip[] bananaSlip;
    public AudioClip[] bonk;
    public AudioClip[] cannon;
    public AudioClip[] lazer;
    public AudioClip[] menuMove;
    public AudioClip[] punch;
    public AudioClip[] slap;
    public AudioClip[] squeakyHit;
    public AudioClip[] timeRunningOut;

    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBananaSlip()
    {
        if (bananaSlip.Length > 0)
        {
            int randomIndex = Random.Range(0, bananaSlip.Length);
            audioSource.PlayOneShot(bananaSlip[randomIndex], 1);
            Debug.Log("YES");
        }
    }

    public void PlayBonk()
    {
        if (bonk.Length > 0)
        {
            int randomIndex = Random.Range(0, bonk.Length);
            audioSource.PlayOneShot(bonk[randomIndex], 1);
            Debug.Log("YES");
        }
    }

    public void PlayCannon()
    {
        if (cannon.Length > 0)
        {
            int randomIndex = Random.Range(0, cannon.Length);
            audioSource.PlayOneShot(cannon[randomIndex], 1);
            Debug.Log("YES");
        }
    }

    public void PlayLazer()
    {
        if (lazer.Length > 0)
        {
            int randomIndex = Random.Range(0, lazer.Length);
            audioSource.PlayOneShot(lazer[randomIndex], 1);
            Debug.Log("YES");
        }
    }

    public void PlayMenuMove()
    {
        if (menuMove.Length > 0)
        {
            int randomIndex = Random.Range(0, menuMove.Length);
            audioSource.PlayOneShot(menuMove[randomIndex], 1);
            Debug.Log("YES");
        }
    }

    public void PlayPunch()
    {
        if (punch.Length > 0)
        {
            int randomIndex = Random.Range(0, punch.Length);
            audioSource.PlayOneShot(punch[randomIndex], 1);
        }
    }


    public void PlaySlap()
    {
        if (slap.Length > 0)
        {
            int randomIndex = Random.Range(0, slap.Length);
            audioSource.PlayOneShot(slap[randomIndex], 1);
        }
    }

    public void PlaySqueakyHit()
    {
        if (squeakyHit.Length > 0)
        {
            int randomIndex = Random.Range(0, squeakyHit.Length);
            audioSource.PlayOneShot(squeakyHit[randomIndex], 1);
        }
    }

    public void PlayTimeRunningOut()
    {
        if (timeRunningOut.Length > 0)
        {
            int randomIndex = Random.Range(0, timeRunningOut.Length);
            audioSource.PlayOneShot(timeRunningOut[randomIndex], 1);
        }
    }
}