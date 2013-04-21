using UnityEngine;
using System.Collections;

public class RegoulitDeposit : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "miner" && collider.gameObject.GetComponent<AIPath>().target == transform)
        {
            StartCoroutine(BeginRegulitGatheringProcess(collider.gameObject.transform));
        }
    }

    IEnumerator BeginRegulitGatheringProcess(Transform collector)
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(3);
            collector.GetComponent<Miner>().carriedGoods[ResourcesColony.Regolith] += 100;
        }
        collector.GetComponent<AIPath>().target = collector.GetComponent<Miner>().Sender;
        Destroy(gameObject);
    }
}
