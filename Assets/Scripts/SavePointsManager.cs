using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointsManager : MonoBehaviour
{
    //Variables ---------------------------------------------------------------------->

    [SerializeField] List<Transform> SavePointsList = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform SavePointInstanciated in transform)
        {
            SavePointsList.Add(SavePointInstanciated);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Methods ------------------------------------------------------------------------------>

    //Find Save Point
    public void FindSavePoint(string name){
        int indexPoint = SavePointsList.FindIndex(item => item.name == name);
        GameManager.instance.lastSavePoint = indexPoint;
    }
    
    // Get Save Point

    public Transform GetSavePoint(int Index){
        return SavePointsList[Index];
    }
}
