using FlightsReservation.Classes.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservation.classes
{
    internal class LoginManager
    {
        private static LoginManager _instance;
        private FirestoreDb _firestoreDb;

        public User CurrentUser { get; set; }
        public bool IsLoggedIn => CurrentUser != null;
        private LoginManager()
        {
            _firestoreDb = DbConnect();
        }

        public static LoginManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LoginManager();
            }
            return _instance;
        }

        public async Task<bool> Login(string username, string password)
        {
            CollectionReference usersRef = _firestoreDb.Collection("users");
            Query query = usersRef.WhereEqualTo("username", username)
                                  .WhereEqualTo("password", password);
            QuerySnapshot result = await query.GetSnapshotAsync();

            if (result.Documents.Count > 0)
            {
                CurrentUser = new User(username);
                return true;
            }
            return false;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public FirestoreDb DbConnect()
        {
            string path = "../../serviceAccountKey.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path); // Ustawienie zmiennej środowiskowej
            _firestoreDb = FirestoreDb.Create("flightsdatabase-3cb1b");
            return _firestoreDb;
        }
    }
}
