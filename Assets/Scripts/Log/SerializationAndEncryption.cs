using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

[System.Serializable]

public class SerializationAndEncryption : MonoBehaviour
{
    [SerializeField] bool serialize;
    [SerializeField] bool usingXML;
    [SerializeField] bool encrypt;
    public static string Encrypt(string log)
    {
        log = Utils.EncryptAES(log);

        string encrypted = log;
        return encrypted;
    }
    public static string Decrypt(string log)
    {
        log = Utils.DecryptAES(log);
        return log;
    }
}

public static class Utils
{

    static byte[] ivBytes = new byte[16]; // Generate the iv randomly and send it along with the data, to later parse out
    static byte[] keyBytes = new byte[16]; // Generate the key using a deterministic algorithm rather than storing here as a variable

    static void GenerateIVBytes()
    {
        System.Random rnd = new System.Random();
        rnd.NextBytes(ivBytes);
    }

    const string nameOfGame = "The Game of Life";
    static void GenerateKeyBytes()
    {
        int sum = 0;
        foreach (char curChar in nameOfGame)
            sum += curChar;

        System.Random rnd = new System.Random(sum);
        rnd.NextBytes(keyBytes);
    }

    public static string EncryptAES(string data)
    {
        GenerateIVBytes();
        GenerateKeyBytes();

        SymmetricAlgorithm algorithm = Aes.Create();
        ICryptoTransform transform = algorithm.CreateEncryptor(keyBytes, ivBytes);
        byte[] inputBuffer = Encoding.Unicode.GetBytes(data);
        byte[] outputBuffer = transform.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);

        string ivString = Encoding.Unicode.GetString(ivBytes);
        string encryptedString = Convert.ToBase64String(outputBuffer);

        return ivString + encryptedString;
    }

    public static string DecryptAES(this string text)
    {
        GenerateIVBytes();
        GenerateKeyBytes();

        int endOfIVBytes = ivBytes.Length / 2;  // Half length because unicode characters are 64-bit width

        string ivString = text.Substring(0, endOfIVBytes);
        byte[] extractedivBytes = Encoding.Unicode.GetBytes(ivString);

        string encryptedString = text.Substring(endOfIVBytes);

        SymmetricAlgorithm algorithm = Aes.Create();
        ICryptoTransform transform = algorithm.CreateDecryptor(keyBytes, extractedivBytes);
        byte[] inputBuffer = Convert.FromBase64String(encryptedString);
        byte[] outputBuffer = transform.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);

        string decryptedString = Encoding.Unicode.GetString(outputBuffer);

        return decryptedString;
    }
}