using UnityEngine;

namespace Purgatory
{
    public class FallingProjectiles : MonoBehaviour
    {
        public GameObject Pattern;
        [SerializeField]
        private GameObject stone;
        private RaycastHit hit;
        private float timesincespawn;
        int layermask = 1 << 7;
        private float offsetDistance;
        [SerializeField]
        private GameObject ground_indicator_prefab;
        private GameObject ground_indicator_instance;
        [SerializeField]
        private float groundindicatorgrowrate;

        private void Start()
        {
            if (Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity, layermask))
            {
                //offsetDistance = hit.distance;
                Debug.DrawLine(transform.position, hit.point, Color.cyan);
                ground_indicator_instance = Instantiate(ground_indicator_prefab, hit.point, Quaternion.identity);
            }
        }

        private void Update()
        {
            timesincespawn += Time.deltaTime;
            ground_indicator_instance.transform.localScale += new Vector3(timesincespawn * groundindicatorgrowrate, timesincespawn * groundindicatorgrowrate, timesincespawn * groundindicatorgrowrate); 
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(hit.point, 1);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                Pattern.SetActive(true);
                Destroy(stone);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                Destroy(this.gameObject);
                Destroy(ground_indicator_instance);
            }
           
        }
    }

}
