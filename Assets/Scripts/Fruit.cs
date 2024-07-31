using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private GameObject fruitWhole;
    [SerializeField] private GameObject fruitSliced;
    private const string BLADE_TAG = "Player";

    private Rigidbody fruitRigidBody;
    private Collider fruitCollider;

    private void Awake()
    {
        fruitRigidBody = GetComponent<Rigidbody>();
        fruitCollider = GetComponent<Collider>();
    }

    private void Slice(Vector3 direction, Vector3 position, float force)
    {
        fruitWhole.SetActive(false);
        fruitSliced.SetActive(true);

        fruitCollider.enabled = false;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        fruitSliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] fruitSlices = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody slice in fruitSlices)
        {
            slice.velocity = fruitRigidBody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(BLADE_TAG))
        {
            Blade blade = other.GetComponent<Blade>();
            Slice(blade.Direction, blade.transform.position, blade.SliceForce);
        }
    }

}
