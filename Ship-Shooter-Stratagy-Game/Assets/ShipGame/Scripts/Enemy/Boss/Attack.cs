using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject ProjectilePrefab;
    public void onAttack()
    {
        Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
    }
}
