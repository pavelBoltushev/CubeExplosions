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
            Separate();        

        Destroy(gameObject);
    }

    public void Init(Vector3 currentPosition)
    {
        _separationChance /= 2;
        transform.localScale /= 2;
        GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));        
        GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, currentPosition, 1f);
    }    

    private void Separate()
    {
        Vector3 currentPosition = transform.position;        
        int newCubesNumber = Random.Range(_minNewCubesNumber, _maxNewCubesNimber + 1);

        for (int i = 0; i < newCubesNumber; i++)
        {
            Cube newCube = Instantiate(this, currentPosition, Quaternion.identity);
            newCube.Init(currentPosition);
        }
    }
}
