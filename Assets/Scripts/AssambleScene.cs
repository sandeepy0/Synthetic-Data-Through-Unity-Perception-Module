using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dummiesman;


public class AssambleScene : MonoBehaviour
{
    // Start is called before the first frame update
    public string configpath = "Assets/Resources/config.txt";
    public string[] configlines;
    public string input_path;
    public string camera_positions_file_path;
    public string keypoints_path;
    public string semantic_masks_path;
    public string output_path;

    public bool rgb;
    public bool depth;
    public bool flow;
    public bool cls_id;
    public bool img;
    public bool layer;
    public bool normals;
    public bool keypts;
    public bool BBox_3D;

    public bool exclude_incomplete;
    public int exclude_smaller_than;
    public int output_width;
    public int output_height;
    public string camera_type;
    public int focal_length;
    public string output_format;

    public string[] fileEntries;
    void Start()
    {

        // Loading all config variables from config.txt
        configlines = File.ReadAllLines(configpath);
        input_path = configlines[2];                        // line 3 is the input path
        camera_positions_file_path = configlines[4];        // line 5 is the camara positions file path
        keypoints_path  = configlines[5];                   // line 7 is the keypoint path
        semantic_masks_path = configlines[8];               // line 9 is the semantic masks path
        output_path = configlines[11];                      // line 12 is the output path

        string[] vars0 = configlines[13].Split('\t');
        rgb = vars0[0]=="true";
        depth = vars0[1]=="true";
        flow = vars0[2]=="true";
        cls_id = vars0[3]=="true";
        img = vars0[4]=="true";
        layer = vars0[5]=="true";
        normals = vars0[6]=="true";
        keypts = vars0[7]=="true";
        BBox_3D = vars0[8]=="true";

        exclude_incomplete = configlines[15]=="True";
        exclude_smaller_than = int.Parse(configlines[17]);
        string[] vars = configlines[19].Split('\t');
        camera_type = vars[0];
        focal_length = int.Parse(vars[1]);
        string[] vars1 = configlines[21].Split('\t');
        output_width = int.Parse(vars1[0]);
        output_height = int.Parse(vars1[1]);
        output_format = configlines[23];


        // Assembling the scene from semantic masks
        Debug.Log("input_path:" + input_path);
        Debug.Log("semantic_masks_path:" + semantic_masks_path);
        string [] fileEntries = Directory.GetFiles(input_path+semantic_masks_path);
        
        foreach (string filename in fileEntries)
        {
            Debug.Log("filename" + filename); 
            GameObject obj = new OBJLoader().Load(filename);
            Labeling label = obj.AddComponent<Labeling>() as Labeling;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Update of LoadConfigData");
    }
}
