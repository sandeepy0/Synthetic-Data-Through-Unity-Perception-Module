 using UnityEngine;
 using System.Collections;
 using System;
 using System.IO;
 public class CamRotation: MonoBehaviour {
    public AssambleScene AssambleScene;
    public string[] lines;
    public string[] arr;
    public int count=11;
    public string path;
    public string configpath;

    public float position_x;
    public float position_y;
    public float position_z;

    public float rotation_x;
    public float rotation_y;
    public float rotation_z;

    void Start()
    {
        configpath = "Assets/Resources/config.txt";             //Since the path of camera_positions.txt cannot
        lines = File.ReadAllLines(configpath);                        //be transferred from AssambleScene to this file
        string[] vars = lines[6].Split('\t');                   //Here we are seperately reading config.txt
        // path = "Assets/Resources/camera_positions.txt";      //to extract camera-positions.txt
        // path = AssambleScene.camera_positions_file_path;
        path = lines[4];
        Debug.Log("path:" + path);
        lines = File.ReadAllLines(path);

        var positionVector = transform.position;
        position_x = positionVector.x;
        position_y = positionVector.y;
        position_z = positionVector.z;

        var rotationVector = transform.rotation.eulerAngles;
        rotation_x = rotationVector.x;
        rotation_y = rotationVector.y;
        rotation_z = rotationVector.z;
    }
 
    void Update() 
    {   
        var rotationVector = transform.rotation.eulerAngles;
        var positionVector = transform.position;
        
        string[] vars = lines[count].Split('\t');
        count += 1;
        // Debug.Log("lines[count] : " + lines[count]);
        int index = int.Parse(vars[0]);
        float a = float.Parse(vars[1]);
        float b = float.Parse(vars[2]);
        float c = float.Parse(vars[3]);

        positionVector.x = position_x * a;
        positionVector.y = position_y * b;
        positionVector.z = position_z * c;
        
        transform.position = positionVector;

        if (vars.Length>6)
        {
            float x = float.Parse(vars[4]);
            float y = float.Parse(vars[5]);
            float z = float.Parse(vars[6]);

            rotationVector.x = rotation_x * x;  //this number is the degree of rotation around x Axis
            rotationVector.y = rotation_y * y;  //this number is the degree of rotation around y Axis
            rotationVector.z = rotation_z * z;  //this number is the degree of rotation around z Axis
            transform.rotation = Quaternion.Euler(rotationVector);
        }
    }
 }