using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections.Generic;


public class DbReader : MonoBehaviour
{
    public Text[] textComponents;
    DatabaseReference databaseReference;
    void Start(){
        FirebaseDatabase.DefaultInstance.SetPersistenceEnabled(false);
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        ReadDataAndDisplayUsernames();
    }

    void ReadDataAndDisplayUsernames(){
        databaseReference.Child("User").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Error reading user data: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                List<string> usernames = new List<string>();

                foreach (DataSnapshot userSnapshot in snapshot.Children)
                {
                    Dictionary<string, object> userData = (Dictionary<string, object>)userSnapshot.Value;
                    string username = userData["UserName"].ToString();
                    usernames.Add(username);
                }

                DisplayUsernames(usernames);
            }
        });
    }

    void DisplayUsernames(List<string> usernames){
        for (int i = 0; i < Mathf.Min(usernames.Count, textComponents.Length); i++)
        {
            textComponents[i].text = usernames[i];
        }
    }
}
