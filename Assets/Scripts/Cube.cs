using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _separationChance;
    [SerializeField] private int _minNewCubesNumber;
    [SerializeField] private int _maxNewCubesNimber;
    [SerializeField] private float _explosionForce;

    public void OnClicked()
    {
        if(Random.Range(0f, 1f) <= _separationChance)
        {
            Separate();
        }

        Destroy(gameObject);
    }

    public void ReduceSeparationChanceByHalf()
    {
        _separationChance /= 2;
    }

    private void Separate()
    {
        Vector3 currentPosition = transform.position;
        Vector3 currentScale = transform.localScale;
        int newCubesNumber = Random.Range(_minNewCubesNumber, _maxNewCubesNimber + 1);

        for (int i = 0; i < newCubesNumber; i++)
        {
            GameObject newCube = Instantiate(gameObject, currentPosition, Quaternion.identity);
            newCube.transform.localScale = currentScale / 2;
            newCube.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            newCube.GetComponent<Cube>().ReduceSeparationChanceByHalf();
            newCube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, currentPosition, 1f);
        }
    }
}
