using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine.UI;

public class DbMana : MonoBehaviour
{
     [SerializeField] InputField userName;
    DatabaseReference reference;
   
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    public void saveData(){
        SceneMana.GoToMenu();
        User user = new User();
        user.UserName = userName.text;
        string json = JsonUtility.ToJson(user);
        reference.Child("User").Child(user.UserName).SetRawJsonValueAsync(json).ContinueWith(task =>{
            if(task.IsCompleted){
                Debug.Log("Successfully added data");
            }
            else{
                Debug.Log("Not Successfully added");
            }
        });
    }
    public void ReadData(){
         reference = FirebaseDatabase.DefaultInstance.RootReference;

        // Assuming you have a node called "Users" in your Firebase Realtime Database
        string userId = "YOUR_USER_ID"; // Replace this with the actual user ID

        // Attach a listener to read the data at the specified user's node
        reference.Child("Users").Child(userId).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Error reading data: " + task.Exception);
                return;
            }

            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                // Deserialize the data into a User object
                User user = JsonUtility.FromJson<User>(snapshot.GetRawJsonValue());

                // Now you have the User object with the UserName property
                Debug.Log("User Name: " + user.UserName);
            }
        });
    }
}
