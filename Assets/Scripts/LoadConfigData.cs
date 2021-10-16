using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LoadConfigData : MonoBehaviour
{
    // Start is called before the first frame update
    public string path = "Assets/Resources/config.txt";
    public string[] configlines;
    public string input_path;
    public string camera_positions_file_path;
    public string keypoints_path;
    public string semantic_masks_path;
    public string output_path;
    public bool exclude_incomplete;
    public int exclude_smaller_than;
    public int output_width;
    public int output_height;
    public string camera_type;
    public int focal_length;
    public string output_format;



    void Start()
    {
        Debug.Log("Start of LoadConfigData");

        configlines = File.ReadAllLines(path);
        input_path = configlines[2];                        // line 3 is the input path
        camera_positions_file_path = configlines[4];        // line 5 is the camara positions file path
        keypoints_path  = configlines[5];                // line 7 is the keypoint path
        semantic_masks_path = configlines[8];               // line 9 is the semantic masks path
        output_path = configlines[11];                      // line 12 is the output path
        exclude_incomplete = configlines[15]=="True";
        exclude_smaller_than = int.Parse(configlines[17]);
        string[] vars = configlines[19].Split('\t');
        camera_type = vars[0];
        focal_length = int.Parse(vars[1]);
        string[] vars1 = configlines[21].Split('\t');
        output_width = int.Parse(vars1[0]);
        output_height = int.Parse(vars1[1]);
        output_format = configlines[23];
        Debug.Log("O/p format:" + configlines[23]);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Update of LoadConfigData");
    }
}
