using UnityEngine;
using System.Collections;

public class ArmaBasicaScript : MonoBehaviour
{
    private bool seleccionada;
    [SerializeField] GameObject balaPrefab;
    public ParticleSystem particulas;

    [SerializeField] Transform puntoDisparo;
    [SerializeField] float velocidadProyectil;
    [SerializeField] AudioClip shotSound;
    private AudioSource audioSource;

    [SerializeField] int tipoMunicio;
    [SerializeField] int tamanyCarregador = 10;
    private int carregador;
    [SerializeField] float cooldown = 1;
    private float cooldownTimer;
    [SerializeField] float reloadTime;
    [SerializeField] AudioClip reloadSound;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        cooldownTimer = cooldown;

        carregador = tamanyCarregador;

        particulas = gameObject.GetComponentInChildren<ParticleSystem>();
        if (particulas == null)
        {
            Debug.Log("Particle system no found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (seleccionada && cooldownTimer >= cooldown && carregador > 0)
        {
            audioSource.PlayOneShot(shotSound);

            GameObject balaTemp = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
            
            Rigidbody rbBala = balaTemp.GetComponent<Rigidbody>();

            // Darle velocidad hacia adelante
            rbBala.linearVelocity = puntoDisparo.forward * velocidadProyectil;

            cooldownTimer = 0;
            carregador -= 1;
            particulas.Play();

            seleccionada = false;
        }
        else if (carregador == 0)
        {
            carregador = -1;

            StartCoroutine(Reload());
        }

        if (cooldownTimer < cooldown)
        {
            cooldownTimer += Time.deltaTime;
        }
    }

    public void Shot() {
        seleccionada = true;
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        audioSource.PlayOneShot(reloadSound);
        
        carregador = tamanyCarregador; 
    }

}
