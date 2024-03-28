using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private float playerHealth;
    public PostProcessVolume damageScreen;
    public GameObject player;
    public GameObject damagePP;
    public GameObject normalPP;
    public GameObject deathScreen;
    public Camera deathCam;
    public GameObject[] disableOnDeath;
    public Slider healthBar;

    void Start()
    {
        playerHealth = maxHealth;
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            Damage(25 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Damage(-25 * Time.deltaTime);
        }

        if (playerHealth >= maxHealth)
        {playerHealth = maxHealth;}
        healthBar.value = playerHealth;
    }

    public void Damage(float amount)
    {
        playerHealth -= amount;
        if (playerHealth <= 35)
        {
            damagePP.SetActive(true);
            normalPP.SetActive(false);

            Vignette vignette;
            if (damageScreen.profile.TryGetSettings(out vignette))
            {
                vignette.intensity.value = (35 - playerHealth) * 0.02f;
            }

            ChromaticAberration chromaticAberration;
            if (damageScreen.profile.TryGetSettings(out chromaticAberration))
            {
                chromaticAberration.intensity.value = (35 - playerHealth) * 0.04f;
            }

        }
        else
        {
            damagePP.SetActive(false);
            normalPP.SetActive(true);
        }

        if(playerHealth <= 0)
        {
            foreach (GameObject obj in disableOnDeath)
            {
                obj.SetActive(false);
            }
            deathCam.enabled = true;
            Destroy(player);
        }
    }
}