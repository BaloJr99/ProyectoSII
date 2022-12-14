using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using ProyectoSII.Models;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel;
using ProyectoSII.ViewModel;

namespace ProyectoSII.Data
{
    public class SQLIteHelper
    {
        SQLiteAsyncConnection _connection;

        public SQLIteHelper(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<Alumno>().Wait();
            _connection.CreateTableAsync<Usuarios>().Wait();
            _connection.CreateTableAsync<Especialidad>().Wait();
            _connection.CreateTableAsync<Carrera>().Wait();
            _connection.CreateTableAsync<Asignatura>().Wait();
            _connection.CreateTableAsync<Reticula>().Wait();
            _connection.CreateTableAsync<ReticulaMateria>().Wait();
            _connection.CreateTableAsync<AlumnoReticula>().Wait();
            _connection.CreateTableAsync<Boleta>().Wait();
            _connection.CreateTableAsync<Horario>().Wait();
            _connection.CreateTableAsync<InformacionEscolar>().Wait();
        }

        public async Task<int> SaveAlumnoAsync(Alumno alum)
        {
            if (alum.IdAlumno == 0)
            {   
                await _connection.InsertAsync(alum);
                await FillData(alum.IdAlumno);
                return alum.IdAlumno;
            }
            else
            {
                return 0;
            }
        }


        public async Task<int> SaveUsuarioAsync(Usuarios user)
        {
            if (user.IdUsuario == 0)
            {
                user.IdUsuario = await _connection.InsertAsync(user);
                return user.IdUsuario;
            }
            else
            {
                return 0;
            }
        }
        public async Task<int> CheckUserPassword(Usuarios user)
        {
            if(_connection.Table<Usuarios>().ToListAsync().Result.Count > 0)
            {
                Usuarios u = await _connection.Table<Usuarios>().Take(1).FirstOrDefaultAsync();
                u.Password = "4175";
                await _connection.UpdateAsync(u);

                Usuarios checkUser = await _connection.Table<Usuarios>().Where(usuario => usuario.Password == user.Password && usuario.User == user.User).FirstOrDefaultAsync();
                if (checkUser != null)
                {
                    Alumno loggedUser = await _connection.Table<Alumno>().Where(alumno => alumno.IdAlumno == checkUser.AlumnoId).FirstOrDefaultAsync();
                    StaticUsuario.Id = loggedUser.IdAlumno;
                    StaticUsuario.Nombre = loggedUser.Nombre;
                    StaticUsuario.ApellidoPaterno = loggedUser.ApellidoPaterno;
                    StaticUsuario.ApellidoMaterno = loggedUser.ApellidoMaterno;
                    StaticUsuario.NumControl = loggedUser.NumControl;
                    StaticUsuario.FechaNacimiento = loggedUser.FechaNacimiento;
                    StaticUsuario.FotoPerfil = loggedUser.FotoPerfil;
                    StaticUsuario.Semestre = loggedUser.Semestre;
                    return loggedUser.IdAlumno;
                }
            }
            return 0;
        }
        public async Task FillData(int idAlumno)
        {
            IEnumerable<Asignatura> asignatura = await _connection.Table<Asignatura>().ToListAsync();
            if(asignatura.Count() == 0)
            {
                List<Asignatura> asignaturas = new List<Asignatura>(){
                    new Asignatura()
                    {
                        ClaveAsignatura = "ACF-0901",
                        NombreAsignatura = "Cálculo Diferencial",
                        Ht = 3,
                        Hp = 2,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCD-1008",
                        NombreAsignatura = "Fundamentos de Programación",
                        Ht = 2,
                        Hp = 3,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "ACA-0907",
                        NombreAsignatura = "Taller de Ética",
                        Ht = 0,
                        Hp = 4,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "AEF-1041",
                        NombreAsignatura = "Matemáticas Discretas",
                        Ht = 3,
                        Hp = 2,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCH-1024",
                        NombreAsignatura = "Taller de Administración",
                        Ht = 1,
                        Hp = 3,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "ACC-0906",
                        NombreAsignatura = "Fundamentos de Investigación",
                        Ht = 2,
                        Hp = 2,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "ACF-0902",
                        NombreAsignatura = "Cálculo Integral",
                        Ht = 3,
                        Hp = 2,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCD-1020",
                        NombreAsignatura = "Programación Orientada a Objetos",
                        Ht = 2,
                        Hp = 3,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "AEC-1008",
                        NombreAsignatura = "Contabilidad Financiera",
                        Ht = 2,
                        Hp = 2,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "AEC-1058",
                        NombreAsignatura = "Química",
                        Ht = 2,
                        Hp = 2,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "ACF-0903",
                        NombreAsignatura = "Algebra Lineal",
                        Ht = 3,
                        Hp = 2,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "AEF-1052",
                        NombreAsignatura = "Probabilidad y Estadística",
                        Ht = 3,
                        Hp = 2,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "ACF-0904",
                        NombreAsignatura = "Cálculo Vectorial",
                        Ht = 3,
                        Hp = 2,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "AED-1026",
                        NombreAsignatura = "Estructura de Datos",
                        Ht = 2,
                        Hp = 3,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "ACD-0908",
                        NombreAsignatura = "Desarrollo Sustentable",
                        Ht = 2,
                        Hp = 3,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCC-1013",
                        NombreAsignatura = "Investigación de Operaciones",
                        Ht = 2,
                        Hp = 2,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "AEC-1061",
                        NombreAsignatura = "Sistemas Operativos",
                        Ht = 2,
                        Hp = 2,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCF-1006",
                        NombreAsignatura = "Física General",
                        Ht = 3,
                        Hp = 2,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "ACF-0905",
                        NombreAsignatura = "Ecuaciones Diferenciales",
                        Ht = 3,
                        Hp = 2,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCC-1017",
                        NombreAsignatura = "Métodos Numéricos",
                        Ht = 2,
                        Hp = 2,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCD-1027",
                        NombreAsignatura = "Tópicos Avanzados de Programación",
                        Ht = 2,
                        Hp = 3,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "AEC-1031",
                        NombreAsignatura = "Fundamentos de Bases de Datos",
                        Ht = 3,
                        Hp = 2,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCA-1026",
                        NombreAsignatura = "Taller de Sistemas Operativos",
                        Ht = 0,
                        Hp = 4,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCD-1018",
                        NombreAsignatura = "Principios Eléctricos y Aplicaciones Digitales",
                        Ht = 2,
                        Hp = 3,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCD-1015",
                        NombreAsignatura = "Lenguajes y Autómatas I",
                        Ht = 2,
                        Hp = 3,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "AEC-1034",
                        NombreAsignatura = "Fundamentos de Telecomunicaciones",
                        Ht = 2,
                        Hp = 2,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCA-1025",
                        NombreAsignatura = "Taller de Bases de Datos",
                        Ht = 0,
                        Hp = 4,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCD-1022",
                        NombreAsignatura = "Simulación",
                        Ht = 2,
                        Hp = 3,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCC-1007",
                        NombreAsignatura = "Fundamentos de Ingeniería de Software",
                        Ht = 2,
                        Hp = 2,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCD-1003",
                        NombreAsignatura = "Arquitectura de Computadoras",
                        Ht = 2,
                        Hp = 3,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCD-1016",
                        NombreAsignatura = "Lenguajes y Autómatas II",
                        Ht = 2,
                        Hp = 3,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCD-1021",
                        NombreAsignatura = "Redes de Computadora",
                        Ht = 2,
                        Hp = 3,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCB-1001",
                        NombreAsignatura = "Administración de Bases de Datos",
                        Ht = 1,
                        Hp = 4,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "AEB-1055",
                        NombreAsignatura = "Programación Web",
                        Ht = 1,
                        Hp = 4,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCD-1011",
                        NombreAsignatura = "Ingeniería de Software",
                        Ht = 2,
                        Hp = 3,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCC-1014",
                        NombreAsignatura = "Lenguaje de Interfaz",
                        Ht = 2,
                        Hp = 2,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCC-1005",
                        NombreAsignatura = "Cultura Empresarial",
                        Ht = 2,
                        Hp = 2,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCD-1004",
                        NombreAsignatura = "Conmutación y Enrutamiento de Redes de Datos",
                        Ht = 2,
                        Hp = 3,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "ACA-0909",
                        NombreAsignatura = "Taller de Investigación I",
                        Ht = 0,
                        Hp = 4,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "DAB-2101",
                        NombreAsignatura = "Programación WEB II",
                        Ht = 1,
                        Hp = 4,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCG-1009",
                        NombreAsignatura = "Gestión de Proyectos de Software",
                        Ht = 3,
                        Hp = 4,
                        Tc = 3
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "DAB-2102",
                        NombreAsignatura = "Interfaces Gráficas de Usuario",
                        Ht = 1,
                        Hp = 4,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCC-1019",
                        NombreAsignatura = "Programación Lógica y Funcional",
                        Ht = 2,
                        Hp = 2,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCA-1002",
                        NombreAsignatura = "Administración de Redes",
                        Ht = 0,
                        Hp = 4,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "ACA-0910",
                        NombreAsignatura = "Taller de Investigación II",
                        Ht = 0,
                        Hp = 4,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "DAB-2103",
                        NombreAsignatura = "Programación Móvil con Lenguaje Oficial",
                        Ht = 2,
                        Hp = 3,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCC-1023",
                        NombreAsignatura = "Sistemas Programables",
                        Ht = 2,
                        Hp = 2,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "DAB-2104",
                        NombreAsignatura = "Base de Datos con ORM",
                        Ht = 2,
                        Hp = 3,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCC-1010",
                        NombreAsignatura = "Graficación",
                        Ht = 2,
                        Hp = 2,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "SCC-1012",
                        NombreAsignatura = "Inteligencia Artificial",
                        Ht = 2,
                        Hp = 2,
                        Tc = 4
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "DAB-2105",
                        NombreAsignatura = "Programación Móvil con Lenguaje Oficial",
                        Ht = 2,
                        Hp = 3,
                        Tc = 5
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "AAA-1111",
                        NombreAsignatura = "Servicio Social"
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "BBB-2222",
                        NombreAsignatura = "Residencias Profesionales"
                    }, new Asignatura()
                    {
                        ClaveAsignatura = "CCC-333",
                        NombreAsignatura = "Actividades Complementarias"
                    }
                };

                Carrera carrera = new Carrera
                {
                    ClaveCarrera = "ISIC-2010-224",
                    NombreCarrera = "Ingeniería en Sistemas Computacionales"
                };

                Especialidad especialidad = new Especialidad
                {
                    ClaveEspecialidad = "INTE-DAP-2021-01",
                    NombreEspecialidad = "Especialidad en Desarrollo de Aplicaciones"
                };

                Reticula reticula = new Reticula
                {
                    IdCarrera = "ISIC-2010-224",
                    IdEspecialidad = "INTE-DAP-2021-01"
                };

                await _connection.InsertAllAsync(asignaturas);
                await _connection.InsertAsync(carrera);
                await _connection.InsertAsync(especialidad);
                await _connection.InsertAsync(reticula);
                

                List<Asignatura> u = await _connection.Table<Asignatura>().ToListAsync();

                List<Asignatura> s1 = u.GetRange(0, 6);
                List<Asignatura> s2 = u.GetRange(6, 6);
                List<Asignatura> s3 = u.GetRange(12, 6);
                List<Asignatura> s4 = u.GetRange(18, 6);
                List<Asignatura> s5 = u.GetRange(24, 6);
                List<Asignatura> s6 = u.GetRange(30, 6);
                List<Asignatura> s7 = u.GetRange(36, 6);
                List<Asignatura> s8 = u.GetRange(42, 7);
                List<Asignatura> s9 = u.GetRange(49, 5);
                foreach (var item in s1)
                {
                    ReticulaMateria reticulaMateria = new ReticulaMateria
                    {
                        IdAsignatura = item.ClaveAsignatura,
                        IdReticula = 1,
                        semestre = 1,
                    };
                    await _connection.InsertAsync(reticulaMateria);
                }
                foreach (var item in s2)
                {
                    ReticulaMateria reticulaMateria = new ReticulaMateria
                    {
                        IdAsignatura = item.ClaveAsignatura,
                        IdReticula = 1,
                        semestre = 2,
                    };
                    await _connection.InsertAsync(reticulaMateria);
                }
                foreach (var item in s3)
                {
                    ReticulaMateria reticulaMateria = new ReticulaMateria
                    {
                        IdAsignatura = item.ClaveAsignatura,
                        IdReticula = 1,
                        semestre = 3,
                    };
                    await _connection.InsertAsync(reticulaMateria);
                }
                foreach (var item in s4)
                {
                    ReticulaMateria reticulaMateria = new ReticulaMateria
                    {
                        IdAsignatura = item.ClaveAsignatura,
                        IdReticula = 1,
                        semestre = 4,
                    };
                    await _connection.InsertAsync(reticulaMateria);
                }
                foreach (var item in s5)
                {
                    ReticulaMateria reticulaMateria = new ReticulaMateria
                    {
                        IdAsignatura = item.ClaveAsignatura,
                        IdReticula = 1,
                        semestre = 5,
                    };
                    await _connection.InsertAsync(reticulaMateria);
                }
                foreach (var item in s6)
                {
                    ReticulaMateria reticulaMateria = new ReticulaMateria
                    {
                        IdAsignatura = item.ClaveAsignatura,
                        IdReticula = 1,
                        semestre = 6,
                    };
                    await _connection.InsertAsync(reticulaMateria);
                }
                foreach (var item in s7)
                {
                    ReticulaMateria reticulaMateria = new ReticulaMateria
                    {
                        IdAsignatura = item.ClaveAsignatura,
                        IdReticula = 1,
                        semestre = 7,
                    };
                    await _connection.InsertAsync(reticulaMateria);
                }
                foreach (var item in s8)
                {
                    ReticulaMateria reticulaMateria = new ReticulaMateria
                    {
                        IdAsignatura = item.ClaveAsignatura,
                        IdReticula = 1,
                        semestre = 8,
                    };
                    await _connection.InsertAsync(reticulaMateria);
                }
                foreach (var item in s9)
                {
                    ReticulaMateria reticulaMateria = new ReticulaMateria
                    {
                        IdAsignatura = item.ClaveAsignatura,
                        IdReticula = 1,
                        semestre = 9,
                    };
                    await _connection.InsertAsync(reticulaMateria);
                }

                List<Horario> horarios = new List<Horario>() {
                    new Horario
                    {
                        AsignaturaClave = "ACF-0901",
                        Enabled = true,
                        Horas = "07:00-08:00;07:00-08:00;07:00-08:00;07:00-08:00;07:00-08:00",
                        IdReticula = 1,
                        Maestro = "Cresencio Rito",
                        Dias = "Lunes, Martes, Miercoles, Jueves, Viernes",
                        Semestre = 1
                    },new Horario
                    {
                        AsignaturaClave = "SCD-1008",
                        Enabled = true,
                        Horas = "08:00-09:00;08:00-09:00;08:00-09:00;08:00-09:00;08:00-09:00",
                        IdReticula = 1,
                        Maestro = "Flora Elida",
                        Dias = "Lunes, Martes, Miercoles, Jueves, Viernes",
                        Semestre = 1
                    },new Horario
                    {
                        AsignaturaClave = "ACA-0907",
                        Enabled = true,
                        Horas = "09:00-10:00;09:00-10:00;09:00-10:00;09:00-10:00",
                        IdReticula = 1,
                        Maestro = "Blanca",
                        Dias = "Lunes, Martes, Jueves, Viernes",
                        Semestre = 1
                    },new Horario
                    {
                        AsignaturaClave = "SCH-1024",
                        Enabled = true,
                        Horas = "10:00-11:00;10:00-11:00;10:00-11:00;10:00-11:00",
                        IdReticula = 1,
                        Maestro = "Jose Rivera",
                        Dias = "Lunes, Martes, Miercoles, Jueves",
                        Semestre = 1
                    },new Horario
                    {
                        AsignaturaClave = "AEF-1041",
                        Enabled = true,
                        Horas = "11:00-13:00;11:00-12:00;11:00-13:00",
                        IdReticula = 1,
                        Maestro = "Hector Valadez",
                        Dias = "Lunes , Miercoles, Viernes",
                        Semestre = 1
                    },new Horario
                    {
                        AsignaturaClave = "ACC-0906",
                        Enabled = true,
                        Horas = "13:00-14:00;13:00-14:00;13:00-14:00;13:00-14:00",
                        IdReticula = 1,
                        Maestro = "Ruth Noemi",
                        Dias = "Martes, Miercoles, Jueves, Viernes",
                        Semestre = 1
                    }
                };

                foreach (var item in horarios)
                {
                    await _connection.InsertAsync(item);
                }
            }
            await _connection.InsertAsync(new AlumnoReticula
            {
                IdAlumno = idAlumno,
                IdReticula = 1
            });
        }

        public async Task CreaHorarioRegistraCalificaciones()
        {
            List<Boleta> boletas = await _connection.Table<Boleta>().Where(bol => bol.IdAlumno == StaticUsuario.Id && bol.Cursando == false).ToListAsync();
            foreach (var boleta in boletas)
            {
                Boleta boletaModificar = boleta;
                boletaModificar.Calificacion = new Random().Next(60, 100);
                if (boletaModificar.Calificacion < 70)
                {
                    boletaModificar.Aprobada = false;
                }
                else
                {
                    boletaModificar.Aprobada = true;
                }
                boletaModificar.Cursando = false;
                await _connection.UpdateAsync(boletaModificar);
            }

            Alumno alumno = await _connection.Table<Alumno>().Where(al => al.IdAlumno == StaticUsuario.Id).FirstOrDefaultAsync();
            alumno.Semestre = "Semestre 2";
            await _connection.UpdateAsync(alumno);

            List<Horario> horarios = new List<Horario>() {
                    new Horario
                    {
                        AsignaturaClave = "ACF-0902",
                        Enabled = true,
                        Horas = "07:00-08:00;07:00-08:00;07:00-08:00",
                        IdReticula = 1,
                        Maestro = "Roberto de Fraire",
                        Dias = "Lunes, Martes, Jueves",
                        Semestre = 2
                    },new Horario
                    {
                        AsignaturaClave = "SCD-1020",
                        Enabled = true,
                        Horas = "08:00-09:00;08:00-09:00;08:00-09:00;08:00-09:00",
                        IdReticula = 1,
                        Maestro = "Lourdes Arlin",
                        Dias = "Lunes, Martes, Jueves, Viernes",
                        Semestre = 2
                    },new Horario
                    {
                        AsignaturaClave = "AEC-1008",
                        Enabled = true,
                        Horas = "09:00-10:00;09:00-10:00;09:00-10:00",
                        IdReticula = 1,
                        Maestro = "Maricela Rangel",
                        Dias = "Lunes, Jueves, Viernes",
                        Semestre = 2
                    },new Horario
                    {
                        AsignaturaClave = "AEC-1058",
                        Enabled = true,
                        Horas = "10:00-11:00;10:00-11:00;10:00-11:00;10:00-11:00",
                        IdReticula = 1,
                        Maestro = "Genaro Cardenas",
                        Dias = "Lunes, Martes, Miercoles, Jueves",
                        Semestre = 2
                    },new Horario
                    {
                        AsignaturaClave = "ACF-0903",
                        Enabled = true,
                        Horas = "11:00-13:00;11:00-12:00;11:00-13:00",
                        IdReticula = 1,
                        Maestro = "Guadalupe Hernandez",
                        Dias = "Lunes , Miercoles, Viernes",
                        Semestre = 2
                    },new Horario
                    {
                        AsignaturaClave = "AEF-1052",
                        Enabled = true,
                        Horas = "13:00-14:00;13:00-14:00;13:00-14:00;13:00-14:00",
                        IdReticula = 1,
                        Maestro = "Martha Genoveva",
                        Dias = "Martes, Miercoles, Jueves, Viernes",
                        Semestre = 2
                    }
                };

            foreach (var item in horarios)
            {
                await _connection.InsertAsync(item);
            }

        }
        public async Task<IList<Asignatura>> GetReticula(int id, int semester)
        {
            int IdReticula = _connection.Table<AlumnoReticula>().Where(alumno => alumno.IdAlumno == id).FirstOrDefaultAsync().Result.IdReticula;
            IEnumerable<ReticulaMateria> retmat1 = await _connection.Table<ReticulaMateria>().ToListAsync();
            IEnumerable<ReticulaMateria> claveMaterias = await _connection.Table<ReticulaMateria>()
                .Where(retmat => retmat.IdReticula == IdReticula && retmat.semestre == semester).ToListAsync();
            List<Asignatura> asignaturas = new List<Asignatura>();
            foreach (var reticula in claveMaterias)
            {
                asignaturas.Add(await _connection.Table<Asignatura>().Where(asignatura => asignatura.ClaveAsignatura == reticula.IdAsignatura).FirstOrDefaultAsync());
            }
            return asignaturas;
        }
        public async Task<IEnumerable<Horario>> GetInscripciones(int id)
        {
            IEnumerable<Boleta> boleta = await _connection.Table<Boleta>().Where(b => b.Cursando == true && b.IdAlumno == StaticUsuario.Id).ToListAsync();
            if(boleta.Count() > 0)
            {
                return null;
            }
            else
            {
                int idReticula = (await _connection.Table<AlumnoReticula>().Where(alret => alret.IdAlumno == id).FirstOrDefaultAsync()).IdReticula;
                var semester = Int16.Parse(StaticUsuario.Semestre.Split(' ').ElementAt(1));
                List<string> calificaciones = (await _connection.Table<Boleta>().Where(bol => bol.Aprobada && bol.IdAlumno == StaticUsuario.Id).ToListAsync()).Select(x => x.IdAsignatura).ToList();
                var inscripciones = await _connection.Table<Horario>()
                   .Where(horario => horario.Enabled == true &&
                    horario.IdReticula == idReticula &&
                    horario.Semestre <= semester &&
                    !calificaciones.Contains(horario.AsignaturaClave)).OrderBy(insc => insc.Semestre).ToListAsync();
                if (inscripciones.Count() > 0)
                {
                    return inscripciones.AsEnumerable();
                }
                return null;
            }
        }

        public async Task<string> GetCarrera()
        {
            var reticula = (await _connection.Table<AlumnoReticula>().Where(alret => alret.IdAlumno == StaticUsuario.Id).FirstOrDefaultAsync()).IdReticula;
            var carrera = (await _connection.Table<Reticula>().Where(ret => ret.IdReticula == reticula).FirstOrDefaultAsync()).IdCarrera;
            var nombreCarrera = (await _connection.Table<Carrera>().Where(car => car.ClaveCarrera == carrera).FirstOrDefaultAsync()).NombreCarrera;
            return nombreCarrera;
        }
        public async Task<string> GetAsignatura(string clave)
        {
            return (await _connection.Table<Asignatura>().Where(asg => asg.ClaveAsignatura == clave).FirstOrDefaultAsync()).NombreAsignatura;
        }

        public async Task<bool> EditPerfil(PerfilModel perfil)
        {
            try
            {
                Alumno alumno = new Alumno
                {
                    IdAlumno = StaticUsuario.Id,
                    Nombre = perfil.Nombre,
                    ApellidoPaterno = perfil.ApellidoPaterno,
                    ApellidoMaterno = perfil.ApellidoMaterno,
                    NumControl = perfil.NumControl,
                    FechaNacimiento = perfil.FechaNacimiento,
                    FotoPerfil = perfil.FotoPerfil,
                    Semestre = perfil.Semestre
                };
                await _connection.UpdateAsync(alumno);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<PerfilModel> GetPerfil()
        {
            Alumno alumno = await _connection.Table<Alumno>().Where(al => al.IdAlumno == StaticUsuario.Id).FirstOrDefaultAsync();
            PerfilModel perfil = new PerfilModel
            {
                Nombre = alumno.Nombre,
                ApellidoPaterno = alumno.ApellidoPaterno,
                ApellidoMaterno = alumno.ApellidoMaterno,
                FechaNacimiento = alumno.FechaNacimiento,
                FotoPerfil = alumno.FotoPerfil,
                NumControl = alumno.NumControl,
                Semestre = alumno.Semestre
            };
            return perfil;
        }

        public async Task<InformacionEscolarModel> GetInformacionEscolar()
        {
            float Promedio = 0;
            AlumnoReticula alumnoReticula = await _connection.Table<AlumnoReticula>().Where(ret => ret.IdAlumno == StaticUsuario.Id).FirstOrDefaultAsync();
            Reticula reticula = await _connection.Table<Reticula>().Where(ret => ret.IdReticula == alumnoReticula.IdReticula).FirstOrDefaultAsync();
            Carrera carrera = await _connection.Table<Carrera>().Where(car => car.ClaveCarrera == reticula.IdCarrera).FirstOrDefaultAsync();
            Especialidad especialidad = await _connection.Table<Especialidad>().Where(esp => esp.ClaveEspecialidad == reticula.IdEspecialidad).FirstOrDefaultAsync();
            InformacionEscolar informacionEscolar = await _connection.Table<InformacionEscolar>().Where(info => info.NumControl == StaticUsuario.NumControl).FirstOrDefaultAsync();
            IEnumerable<Boleta> boletas = await _connection.Table<Boleta>().Where(bol => bol.Aprobada == true).ToListAsync();
            foreach (var boleta in boletas)
            {
                Promedio += boleta.Calificacion;
            }

            if(Promedio != 0)
            {
                Promedio /= boletas.Count();
            }

            InformacionEscolarModel informacionEscolarModel;
            if(informacionEscolar != null)
            {
                informacionEscolarModel = new InformacionEscolarModel
                {
                    IdInformacion = informacionEscolar.IdInformacionEscolar,
                    NumControl= StaticUsuario.NumControl,
                    NombreAlumno= StaticUsuario.Nombre + " " + StaticUsuario.ApellidoPaterno + " " + StaticUsuario.ApellidoMaterno,
                    Semestre = StaticUsuario.Semestre,
                    Entidad = informacionEscolar.Entidad,
                    Correo = informacionEscolar.Correo,
                    Colonia = informacionEscolar.Colonia,
                    Calle = informacionEscolar.Calle,
                    Telefono = informacionEscolar.NumTelefono,
                    Carrera = carrera.NombreCarrera,
                    Ciudad = informacionEscolar.Ciudad,
                    CodigoPostal = informacionEscolar.CodigoPostal,
                    Especialidad = especialidad.NombreEspecialidad,
                    NumExt = informacionEscolar.NumExt,
                    NumInt = informacionEscolar.NumInt,
                    Promedio = Promedio
                };
            }
            else
            {
                informacionEscolarModel = new InformacionEscolarModel
                {
                    NumControl = StaticUsuario.NumControl,
                    NombreAlumno = StaticUsuario.Nombre + " " + StaticUsuario.ApellidoPaterno + " " + StaticUsuario.ApellidoMaterno,
                    Semestre = StaticUsuario.Semestre,
                    Carrera = carrera.NombreCarrera,
                    Especialidad = especialidad.NombreEspecialidad,
                    Promedio = Promedio
                };
            }
            return informacionEscolarModel;
        }

        public async Task<bool> SaveInformacionEscolar(InformacionEscolarModel infoEscolar)
        {
            try
            {
                InformacionEscolar info = new InformacionEscolar
                {
                    Calle = infoEscolar.Calle,
                    Ciudad = infoEscolar.Ciudad,
                    CodigoPostal = infoEscolar.CodigoPostal,
                    Colonia = infoEscolar.Colonia,
                    Correo = infoEscolar.Correo,
                    Entidad = infoEscolar.Entidad,
                    NumControl = infoEscolar.NumControl,
                    NumExt = infoEscolar.NumExt,
                    NumInt = infoEscolar.NumInt,
                    NumTelefono = infoEscolar.Telefono
                };
                if (infoEscolar.IdInformacion == 0)
                {
                    await _connection.InsertAsync(info);
                }
                else
                {
                    info.IdInformacionEscolar = infoEscolar.IdInformacion;
                    await _connection.UpdateAsync(info);
                }
                return true;
            }catch(Exception ex) {
                return false;
            }
        }

        public async Task SaveInscripcion(List<InscripcionesModel> lista)
        {
            List<Boleta> boleta = new List<Boleta>();
            string periodo;
            if(DateTime.Now.Month >= 1 && DateTime.Now.Month <= 6)
            {
                periodo = $"ENE/JUN {DateTime.Now.Year}";
            }
            else
            {
                periodo = $"JUL/DIC {DateTime.Now.Year}";
            }
            foreach (var inscripcion in lista)
            {
                boleta.Add(new Boleta
                {
                    Aprobada = false,
                    Calificacion = 0,
                    IdAlumno = StaticUsuario.Id,
                    IdAsignatura = inscripcion.ClaveMateria,
                    Cursando = true,
                    Periodo= periodo,
                });
            }

            await _connection.InsertAllAsync(boleta);
        }

        public async Task<List<string>> GetSemesters()
        {
            List<Boleta> boletas = await _connection.Table<Boleta>().ToListAsync();
            List<string> listBoletasRep =boletas.Select(x => x.Periodo).ToList();
            List<string> listBoletas = listBoletasRep.Distinct().ToList();
            return listBoletas;
        }
        public async Task<List<string>> GetSemestersKardex()
        {
            List<Boleta> boletas = await _connection.Table<Boleta>().Where(bol => bol.Cursando == false).ToListAsync();
            List<string> listBoletasRep = boletas.Select(x => x.Periodo).ToList();
            List<string> listBoletas = listBoletasRep.Distinct().ToList();
            return listBoletas;
        }

        public async Task<List<BoletaModel>> GetBoleta(string periodo)
        {
            List<Boleta> boletas = await _connection.Table<Boleta>().Where(bol => bol.Periodo == periodo).ToListAsync();
            List<BoletaModel> listBoletas = new List<BoletaModel>();
            foreach (var boleta in boletas)
            {
                listBoletas.Add(new BoletaModel
                {
                    Calificacion = boleta.Calificacion,
                    Asignatura = await GetAsignatura(boleta.IdAsignatura)
                });
            }
            return listBoletas;
        }

        public async Task<List<BoletaModel>> GetBoletaKardex(string periodo)
        {
            List<BoletaModel> boletas = await GetBoleta(periodo);
            float promedio = 0f;

            foreach (var boleta in boletas)
            {
                promedio += boleta.Calificacion;
            }

            boletas.Add(new BoletaModel
            {
                Asignatura = "",
                Calificacion = (float)Decimal.Round((decimal)promedio / boletas.Count(), 0),
            });
            return boletas;
        }

        public async Task<string> CheckMateria(string claveAsignatura)
        {
            Boleta boleta = await _connection.Table<Boleta>().Where(bol => bol.IdAsignatura == claveAsignatura).FirstOrDefaultAsync();
            if (boleta != null)
            {
                if (boleta.Cursando == true)
                {
                    return "Cursando";
                }
                else if (boleta.Aprobada == true)
                {
                    return "Aprobada";
                }
                else if (boleta.Aprobada == false)
                {
                    return "Reprobada";
                }
            }
            return "";
        }
    }
}
