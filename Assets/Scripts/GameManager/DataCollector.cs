using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DataCollector : MonoBehaviour {

    public bool Debugging = true;
    public ScoreKeeper scoreKeeper;
    public string FileName = "DataCollected.csv";
    public string Delimiter = ";";

    private string fullPath;

    private DateTime timeStampStart;
    private DateTime timeStampEnd;
    private int score;
    private double duration;
    private int shotsFired;
    private int movesMade;
    private int segmentsCleared;

    private void Start()
    {
        fullPath = Directory.GetCurrentDirectory() + "/" + FileName;
        if (Debugging)
        {
            Debug.Log("Datacollector: Saving at " + fullPath);
        }
        CheckFile();
    }

    private void CheckFile()
    {
        try
        {
            if (File.Exists(fullPath))
            {
                File.OpenWrite(fullPath).Close();
            }
            else
            {
                File.Create(fullPath).Close();

                StreamWriter writer = new StreamWriter(fullPath, true);
                writer.WriteLine(ConstructHeader());
                writer.Close();
            }
        }
        catch (FileNotFoundException)
        {
            if (Debugging)
            {
                Debug.Log("DataCollector: File not found, Would create at :" + fullPath);
            }
            else
            {
                File.Create(fullPath).Close();

                StreamWriter writer = new StreamWriter(fullPath, true);
                writer.WriteLine(ConstructHeader());
                writer.Close();
            }
        }
    }

    private string ConstructHeader()
    {
        return "StartTimestamp" + Delimiter + "EndTimestamp" + Delimiter + "Score" + Delimiter + "Duration" + Delimiter + "Shots" + Delimiter + "Moves" + Delimiter + "Segments";
    }

    public void Begin()
    {
        timeStampStart = DateTime.Now;
        shotsFired = 0;
        movesMade = 0;
        segmentsCleared = 0;
    }

    public void End()
    {
        timeStampEnd = DateTime.Now;
        score = scoreKeeper.Score;
        duration = Mathf.RoundToInt((float)(timeStampEnd - timeStampStart).TotalSeconds);
        if (Debugging)
        {
            Debug.Log("DataCollector: Data written = " + FormatData());
        }
        else
        {
            AppendToFile();
        }
    }

    public void ShotFired()
    {
        shotsFired++;
    }

    public void ShipMoved()
    {
        movesMade++;
    }

    public void SegmentCleared()
    {
        segmentsCleared++;
    }

    private void AppendToFile()
    {
        StreamWriter writer = new StreamWriter(fullPath, true);
        writer.WriteLine(FormatData());
        writer.Close();
    }

    private string FormatData()
    {
        return timeStampStart.ToLocalTime() + Delimiter + timeStampEnd.ToLocalTime() + Delimiter + score + Delimiter + duration + Delimiter + shotsFired + Delimiter + movesMade + Delimiter + segmentsCleared;
    }  
}
