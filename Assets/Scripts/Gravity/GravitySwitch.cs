using DG.Tweening;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GravitySwitch : MonoBehaviour
{
    /*
        TO DO : supprimer script
        quand mouvement officiel defini
     */

    //Temporary Movement
    private void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Time.deltaTime * 5);
        if(Input.GetKey(KeyCode.DownArrow))this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Time.deltaTime * 5);
    }
}
