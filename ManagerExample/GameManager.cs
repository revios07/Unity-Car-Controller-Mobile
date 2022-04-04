using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Car Variables")]
    public float frontSpeed = 170;
    public float maxTurnSpeed = 28;
    public float breakForce = 10000;

    [Header("Player Controll")]
    public float sensitivityHorizontal = 0.8f;
}
