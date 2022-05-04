using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.IO;
using TMPro;

#if ENABLE_WINMD_SUPPORT
using Microsoft.ClearScript.V8;
using Microsoft.ClearScript.JavaScript;
using Windows.Storage;
#endif

public class ClearScriptEngine : MonoBehaviour
{
    public TextMeshProUGUI Text;

    void Start()
    {
        try
        {
            Text.text = "ClearScriptEngine>Start \n";

#if ENABLE_WINMD_SUPPORT
            Text.text += "ClearScriptEngine>Start>ENABLE_WINMD_SUPPORT \n";
            var engine = new V8ScriptEngine();

            Text.text += "Created engine object \n";
            var newPath = Path.Combine(Application.persistentDataPath, "ClearScript.js");

            Text.text += "Generated Path: " + newPath + "\n";
            engine.Execute(File.ReadAllText(newPath));

            var values = (ITypedArray<int>)engine.Script.values;
            Text.text += string.Join(", ", values.ToArray()) + "\n";
#endif
        }
        catch (Exception ex)
        {
            Text.text += "EXCEPTION MSG: " + ex.Message + "\n";
            Text.text += "EXCEPTION STACK: " + ex.StackTrace + "\n";
        }
    }
}