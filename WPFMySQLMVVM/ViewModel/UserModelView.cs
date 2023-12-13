using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using WPFJSONMVVM.JSON;
using WPFJSONMVVM.Models;

namespace WPFJSONMVVM.ViewModel
{
    public class UserModelView : INotifyPropertyChanged
    {
        #region VARIABLES
        public event PropertyChangedEventHandler? PropertyChanged;

        //Modelo de la lista de registros a mostrar
        private ObservableCollection<User> _users;
        private String _user = "";
        private String _mail = "";
        private String _age = "";
        #endregion

        #region OBJETOS
        public ObservableCollection<User> users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChange("users");
            }
        }
        public String userName
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChange("userName");
            }
        }
        public String mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
                OnPropertyChange("mail");
            }
        }

        public String age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChange("age");
            }
        }
        #endregion

        //Método que se encarga de actualizar las propiedades en cada cambio
        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NewUser()
        {
            UserDataComponent.insertPeople(new User
            {
                userName = userName,
                mail = mail,
                age = age
            });
        }

        

        public void LoadUsers()
        {
            users = new ObservableCollection<User>(UserDataComponent.readUsers());
        }
    }
}
