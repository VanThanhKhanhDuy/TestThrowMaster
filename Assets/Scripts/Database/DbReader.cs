using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections.Generic;

public class DbReader : MonoBehaviour
{
    public Text[] textComponents;
    private UserDataManager userDataManager;

    void Start(){
        userDataManager = new UserDataManager();
        userDataManager.Initialize();
        ReadDataAndDisplayUsernames();
    }

    void ReadDataAndDisplayUsernames(){
        userDataManager.GetUsers((usernames) =>
        {
            DisplayUsernames(usernames);
        });
    }

    void DisplayUsernames(List<string> usernames){
        for (int i = 0; i < Mathf.Min(usernames.Count, textComponents.Length); i++){
            textComponents[i].text = usernames[i];
        }
    }
}

public class UserDataManager
{
    DatabaseReference databaseReference;

    public void Initialize(){
        FirebaseDatabase.DefaultInstance.SetPersistenceEnabled(false);
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void GetUsers(System.Action<List<string>> callback){
        databaseReference.Child("User").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted){
                Debug.LogError("Error reading user data: " + task.Exception);
                callback(new List<string>());
            }
            else if (task.IsCompleted){
                DataSnapshot snapshot = task.Result;
                List<string> usernames = new List<string>();

                foreach (DataSnapshot userSnapshot in snapshot.Children){
                    Dictionary<string, object> userData = (Dictionary<string, object>)userSnapshot.Value;
                    if (userData.TryGetValue("UserName", out object usernameObj) && usernameObj is string username){
                        usernames.Add(username);
                    }
                }

                callback(usernames);
            }
        });
    }
}
