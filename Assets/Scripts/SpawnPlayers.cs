using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(car.name, new Vector3(960, 22, 920), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
