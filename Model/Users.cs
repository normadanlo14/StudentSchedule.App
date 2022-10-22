
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentSchedule.App;
using Firebase.Database;


namespace StudentSchedule.Model
{
    internal class Users
    {
        public string Subjectandtime { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public async Task<bool> AddUser(string subjectandtime, string fname, string lname, string email, string pword)
        {
            try
            {
                var evaluateEmail = (await client.Child("Users")
                    .OnceAsync<Users>())
                    .FirstOrDefault(a => a.Object.Email == email);

                if (evaluateEmail == null)
                {
                    var user = new Users()
                    {
                      Subjectandtime = subjectandtime,
                      Firstname = fname,
                      Lastname = lname,
                      Email = email,
                      Password = pword
                    };
                    await client
                        .Child("Users")
                        .PostAsync(user);
                    client.Dispose();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> UserLogin(string email, string Pass)
        {
            try
            {
                var evaluateEmail = (await client.Child("Users")
                                  .OnceAsync<Users>())
                                  .FirstOrDefault
                                  (a => a.Object.Email == email &&
                                   a.Object.Password == Pass);
                return evaluateEmail != null;
            }
            catch
            {
                return false;
            }

        }
        public ObservableCollection<Users> GetUserList()
        {
            var userlist = client
                 .Child("Users")
                .AsObservable<Users>()
                .AsObservableCollection();
            return userlist;

        }
        public async Task<string> GetUserKey(string mail)
        {
            try
            {
                var getuserkey = (await client.Child("Users").OnceAsync<Users>()).
                    FirstOrDefault(a => a.Object.Email == mail);
                if (getuserkey == null) return null;

                firstname = getuserkey.Object.Firstname;
                lastname = getuserkey.Object.Lastname;
                pass = getuserkey.Object.Password;

                return getuserkey?.Key;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task<string> Deletedata()
        {
            try
            {
                await client
                    .Child($"Users/{key}")
                    .DeleteAsync();
                return "removed";
            }
            catch (Exception ex)
            {
                return " error";
            }
        }
        public async Task<bool> editdata(string SaT, string lname, string fname)
        {
            try
            {
                var evaluteuser = (await client
                    .Child("Users")
                    .OnceAsync<Users>())
                    .FirstOrDefault
                    (a => a.Object.Email == email);
                if (evaluteuser != null)
                {
                    Users user = new Users
                    {   Subjectandtime = SaT,
                        Email = email,
                        Firstname = fname,
                        Lastname = lname,
                        Password = pass
                    };
                    await client.Child("Users").Child(key).PatchAsync(user);
                    client.Dispose();
                }
                client.Dispose();
                return false;
            }
            catch (Exception ex)
            {
                client.Dispose();
                return false;
            }
        }
    }
}

