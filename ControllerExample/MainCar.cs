using UnityEngine;

public class MainCar : MonoBehaviour
{
    //Car Sensitivity Horizontal
    protected float sensitivity = 0.5f;

    //Car Movement
    protected float frontSpeed;
    protected float maxTurnSpeed;
    protected float breakForce;

    [SerializeField] protected GameManager gameManager;

    //Take Materials From This Class
    [SerializeField] protected Materials materialsClass;

    //Car Properties
    [SerializeField] protected TrailRenderer[] trailRenderers = new TrailRenderer[2];
    [SerializeField] protected MeshRenderer myMesh;

    //Particle When Pick Score
    [Header("0 For Pick Score")]
    [Header("1 For Lose Score")]
    [Header("2 For Nitro")]
    [Header("3 For End Game Run")]
    [SerializeField] protected ParticleSystem[] particleEffects;

    protected virtual void Start()
    {
        frontSpeed = gameManager.frontSpeed;
        maxTurnSpeed = gameManager.maxTurnSpeed;
        breakForce = gameManager.breakForce;

        sensitivity = gameManager.sensitivityHorizontal;
    }
}
