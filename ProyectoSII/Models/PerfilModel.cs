using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ProyectoSII.Models
{
    public class PerfilModel:INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string numControl;

        public string NumControl
        {
            get { return numControl; }
            set { numControl = value;
                OnPropertyChanged();
            }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;
                OnPropertyChanged();
            }
        }

        private string apellidoPaterno;

        public string ApellidoPaterno
        {
            get { return apellidoPaterno; }
            set { apellidoPaterno = value;
                OnPropertyChanged();
            }
        }

        private string apellidoMaterno;

        public string ApellidoMaterno
        {
            get { return apellidoMaterno; }
            set { apellidoMaterno = value;
                OnPropertyChanged();
            }
        }

        private DateTime fechaNacimiento;

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value;
                OnPropertyChanged();
            }
        }

        private byte[] fotoPerfil;

        public byte[] FotoPerfil
        {
            get { return fotoPerfil; }
            set { fotoPerfil = value;
                SourceFotoPerfil = ImageSource.FromStream(() => new MemoryStream(value));
                OnPropertyChanged();
            }
        }

        private ImageSource sourceFotoPerfil;

        public ImageSource SourceFotoPerfil
        {
            get { return sourceFotoPerfil; }
            set { sourceFotoPerfil = value;
                OnPropertyChanged();
            }
        }


        private string semestre;

        public string Semestre
        {
            get { return semestre; }
            set { semestre = value;
                OnPropertyChanged();
            }
        }

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; }
        }

    }
}
