using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Linq;
using Dapper;
using ManagementulProiectelor.Java;
using ManagementulProiectelor.Forms;

namespace ManagementulProiectelor
{
    class DBHelper
    {
        const String CONNECTIONSTRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ionut\Desktop\Licenta\Cod\ManagementulProiectelor\ManagementulProiectelor\DB\ManagementulProiectelor.mdf;Integrated Security = True";
        #region Skill
        public static void AddSkill(Skill skill)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Execute("Insert into Skill (Id_Skill, denumireSkill, nivelSkill) VALUES " +
                    "(N'" + skill.Id_Skill + "',N'" + skill.denumireSkill + "' ,N'" + skill.nivelSkill + "')");
            }
        }
        public static List<Skill> ExtrageSkilluriWithDapper()
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var listaSkilluriDapper = con.Query<Skill>("Select * from Skill").ToList();
                return listaSkilluriDapper;
            }
        }
        public static List<SkilluriAngajat> ReturneazaSkilluriAngajat(string idAngajat)
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                connection.Open();
                string query = @"
        WITH RankedSkills AS (
            SELECT 
                S.denumireSkill,
                S.nivelSkill,
                ROW_NUMBER() OVER (PARTITION BY S.denumireSkill ORDER BY 
                    CASE 
                        WHEN S.nivelSkill = 'Junior' THEN 1
                        WHEN S.nivelSkill = 'Mediu' THEN 2
                        WHEN S.nivelSkill = 'Senior' THEN 3
                        ELSE 4
                    END DESC) AS rn
            FROM 
                Detine D
            JOIN 
                Skill S ON D.Id_Skill = S.Id_Skill
            WHERE 
                D.Id_Angajat = @IdAngajat
        )
        SELECT 
            denumireSkill,
            nivelSkill
        FROM 
            RankedSkills
        WHERE 
            rn = 1";

                return connection.Query<SkilluriAngajat>(query, new { IdAngajat = idAngajat }).AsList();
            }
        }
        public static bool VerificaExistentaAsociere(string denumire)
        {
            string denumireSkill = denumire;

            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                connection.Open();
                string query = "SELECT COUNT(1) FROM Skill WHERE DenumireSkill = @DenumireSkill";
                var count = connection.ExecuteScalar<int>(query, new { DenumireSkill = denumireSkill });

                return count > 0;
            }
        }
        public static void StergeSkillAngajat(string idAngajat, string denumireSkill, string nivelSkill)
        {
            string idSkill = denumireSkill + "-" + nivelSkill;
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                string query = "DELETE FROM Detine WHERE Id_Angajat = @IdAngajat AND id_Skill = @IdSkill";
                connection.Execute(query, new { IdAngajat = idAngajat, IdSkill = idSkill });
            }
        }



        #endregion
        #region Task
        public static DateTime ExtrageDataInceputTask(String idTask)
        {
            string query = "SELECT DataInceput FROM Tasks WHERE Id_Task = @Id_Task";
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                DateTime dataInceput = con.QueryFirstOrDefault<DateTime>(query, new { Id_Task = idTask });
                return dataInceput;
            }
        }
        public static void AddTask(Task task)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Execute("INSERT INTO Task (Id_Proiect, Id_Task, denumireTask, numarOre, Id_Descriere) VALUES (@Id_Proiect, @Id_Task, @denumireTask, @numarOre, @Id_Descriere)",
                    new { Id_Proiect = task.Id_Proiect, Id_Task = task.Id_Task, denumireTask = task.denumireTask, numarOre = task.numarOre, Id_Descriere = task.Id_Descriere });
            }
        }
        public static List<Task> ExtrageTaskuriWithDapper()
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var listaTaskuri = con.Query<Task>("Select * from Task").ToList();
                return listaTaskuri;
            }
        }
        public static (DateTime dataIncepereTask, DateTime dataFinalizareTask, decimal nrOre) ExtrageDetaliiTask(string idTask)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string queryPerioada = @"
            SELECT TOP 2 p.zi, p.luna, p.an, p.tipPerioada
            FROM Perioada p
            INNER JOIN PerioadaTask pt ON p.Id_Perioada = pt.Id_Perioada
            WHERE pt.Id_Task = @TaskId
            ORDER BY p.tipPerioada";

                var rezultate = con.Query<(int zi, int luna, int an, string tipPerioada)>(queryPerioada, new { TaskId = idTask }).ToList();

                string queryNrOre = @"
            SELECT t.numarOre FROM Task t WHERE t.Id_Task = @TaskId";

                decimal nrOre = con.Query<decimal>(queryNrOre, new { TaskId = idTask }).FirstOrDefault();

                if (rezultate.Count >= 2)
                {
                    (int InceputZi, int InceputLuna, int InceputAn, string tipPerioadaInceput) = rezultate[0];
                    (int SfarsitZi, int SfarsitLuna, int SfarsitAn, string tipPerioadaSfarsit) = rezultate[1];

                    DateTime dataIncepereTask, dataFinalizareTask;
                    if (tipPerioadaInceput.Equals("Inceput", StringComparison.OrdinalIgnoreCase))
                    {
                        dataIncepereTask = new DateTime(InceputAn, InceputLuna, InceputZi);
                    }
                    else
                    {
                        dataIncepereTask = new DateTime(SfarsitAn, SfarsitLuna, SfarsitZi);
                    }

                    if (tipPerioadaSfarsit.Equals("Sfarsit", StringComparison.OrdinalIgnoreCase))
                    {
                        dataFinalizareTask = new DateTime(SfarsitAn, SfarsitLuna, SfarsitZi);
                    }
                    else
                    {
                        dataFinalizareTask = new DateTime(InceputAn, InceputLuna, InceputZi);
                    }

                    return (dataIncepereTask, dataFinalizareTask, nrOre);
                }

                return (DateTime.MinValue, DateTime.MinValue, 0);
            }
        }
        public static PerioadeTaskGantt ExtrageDetaliiTaskGantt(string idTask)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Open();

                string queryPerioada = @"
                SELECT TOP 2 p.zi, p.luna, p.an, p.tipPerioada
            FROM Perioada p
            INNER JOIN PerioadaTask pt ON p.Id_Perioada = pt.Id_Perioada
            WHERE pt.Id_Task = @TaskId
            ORDER BY p.tipPerioada";

                var rezultate = con.Query<(int zi, int luna, int an, string tipPerioada)>(queryPerioada, new { TaskId = idTask }).ToList();

                decimal nrOreAlocateDb = 0;
                if (rezultate.Count >= 2)
                {

                    (int InceputZi, int InceputLuna, int InceputAn, string tipPerioadaInceput) = rezultate[0];
                    (int SfarsitZi, int SfarsitLuna, int SfarsitAn, string tipPerioadaSfarsit) = rezultate[1];

                    DateTime dataIncepereTask, dataFinalizareTask;
                    if (tipPerioadaInceput.Equals("Inceput", StringComparison.OrdinalIgnoreCase))
                    {
                        dataIncepereTask = new DateTime(InceputAn, InceputLuna, InceputZi);
                    }
                    else
                    {
                        dataIncepereTask = new DateTime(SfarsitAn, SfarsitLuna, SfarsitZi);
                    }

                    if (tipPerioadaSfarsit.Equals("Sfarsit", StringComparison.OrdinalIgnoreCase))
                    {
                        dataFinalizareTask = new DateTime(SfarsitAn, SfarsitLuna, SfarsitZi);
                    }
                    else
                    {
                        dataFinalizareTask = new DateTime(InceputAn, InceputLuna, InceputZi);
                    }

                    string queryNrOre = "SELECT t.numarOre FROM task t WHERE t.Id_Task = @TaskId";
                    decimal nrOre = con.QueryFirstOrDefault<decimal>(queryNrOre, new { TaskId = idTask });

                    List<IntervalLucru> detaliiParticipariTask = DetaliiPerioadaDeLucru(idTask);
                    foreach (var detalii in detaliiParticipariTask)
                    {
                        nrOreAlocateDb += detalii.NrOre * FormAlocareAngajat.CalculeazaZileLucratoare(detalii.DataInceput, detalii.DataSfarsit);
                    }
                    string queryDenumireTask = "SELECT t.denumireTask FROM task t WHERE t.Id_Task = @TaskId";
                    string denumireTask = con.QueryFirstOrDefault<string>(queryDenumireTask, new { TaskId = idTask });

                    return new PerioadeTaskGantt(denumireTask, dataIncepereTask, dataFinalizareTask, nrOreAlocateDb, nrOre);
                }

                return new PerioadeTaskGantt(string.Empty, DateTime.MinValue, DateTime.MinValue, 0, 0);
            }
        }
        public static List<Task> ReturneazaTaskuriAngajat(string angajatId)
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                connection.Open();

                string query = @"
                    SELECT Task.*
                    FROM Task
                    INNER JOIN Participa ON Task.Id_Proiect = Participa.Id_Proiect AND Task.Id_Task = Participa.Id_Task
                    WHERE Participa.Id_Angajat = @AngajatId
                    AND Participa.DataParasireTask > GETDATE()";
                ;

                return connection.Query<Task>(query, new { AngajatId = angajatId }).AsList();
            }
        }
        public static List<Task> ExtrageTaskuriByProiect(string idProiect)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"
            SELECT *
            FROM Task
            WHERE Id_Proiect = @IdProiect";

                return con.Query<Task>(query, new { IdProiect = idProiect }).ToList();
            }
        }
        public static string ExtrageDenumireTask(string IdTask)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"SELECT denumireTask FROM task WHERE Id_Task = @IdTask";

                return con.Query<string>(query, new { IdTask = IdTask }).FirstOrDefault();
            }
        }
        public static void ActualizeazaTask(Task task)
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                connection.Open();

                string queryTask = @"
            UPDATE Task 
            SET denumireTask = @DenumireTask, 
                numarOre = @NumarOre
            WHERE Id_Task = @IdTask";

                connection.Execute(queryTask, new
                {
                    DenumireTask = task.denumireTask,
                    NumarOre = task.numarOre,
                    IdTask = task.Id_Task
                });
            }
        }
        public static Task ExtrageTaskById(string taskId)
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                connection.Open();
                string query = "SELECT * FROM Task WHERE Id_Task = @Id_Task";
                return connection.QuerySingleOrDefault<Task>(query, new { Id_Task = taskId });
            }
        }

        #endregion
        #region Angajat
        public static int ExtrageNrAngajatiCuAceeasiDenumire(String UserName)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = "SELECT COUNT(*) FROM Cont WHERE UserCont = @Nume";
                int numarUtilizatori = con.QueryFirstOrDefault<int>(query, new { Nume = UserName });

                return numarUtilizatori;
            }
        }
        public static void AddAngajat(Angajat angajat)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Execute("Insert into Angajat (Id_Angajat, numeAngajat, prenumeAngajat, emailAngajat, numarTelefonAngajat,Id_Cont, Id_Norma) VALUES" +
                    "(N'" + angajat.Id_Angajat + "',N'" + angajat.numeAngajat + "',N'" + angajat.prenumeAngajat + "',N'" + angajat.emailAngajat + "',N'" + angajat.numarTelefonAngajat
                    + "',N'" + angajat.Id_Cont + "',N'" + angajat.Id_Norma + "')");
            }
        }
        public static List<Angajat> ExtrageAngajatiWithDapper()
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var listaAngajatiDapper = con.Query<Angajat>("Select * from Angajat").ToList();
                return listaAngajatiDapper;
            }
        }
        public static String ReturneazaIdAngajat(string user, string parola)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query =
                @"select a.Id_Angajat 
                    from angajat a
                    join cont c
                    on a.Id_Cont = c.Id_Cont
                    where c.UserCont = @UserCont 
                    and c.ParolaCont = @ParolaCont";

                var result = con.QueryFirstOrDefault(query, new { UserCont = user, ParolaCont = parola });

                if (result != null)
                {
                    string idAngajat = result.Id_Angajat;
                    return idAngajat;
                }

                return "Nume sau parola incorecta";
            }
        }
        public static (string numeAngajat, string prenumeAngajat) DetaliiAngajatDupaCont(string user, string parola)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                String idCont = con.QueryFirstOrDefault<String>
                    ("SELECT Id_Cont FROM Cont WHERE UserCont = @UserCont AND ParolaCont = @ParolaCont",
                    new { UserCont = user, ParolaCont = parola });

                var result = con.QueryFirstOrDefault<(string numeAngajat, string prenumeAngajat)>(
                    @"SELECT a.NumeAngajat, a.PrenumeAngajat
              FROM Angajat a
              JOIN Cont c ON a.Id_Cont = c.Id_Cont
              WHERE a.Id_Cont = @IdCont", new { IdCont = idCont });
                return result;
            }
        }
        public static Angajat ReturneazaDetaliiAngajatDupaId(string idAngajat)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = "SELECT numeAngajat, prenumeAngajat FROM Angajat WHERE Id_Angajat = @Id_Angajat";
                return con.QueryFirstOrDefault<Angajat>(query, new { Id_Angajat = idAngajat });
            }
        }
        public static void ActualizeazaAngajat(Angajat angajat)
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                connection.Open();
                string query = @"
                UPDATE Angajat 
                SET numeAngajat = @Nume, 
                    prenumeAngajat = @Prenume, 
                    emailAngajat = @Email, 
                    numarTelefonAngajat = @NumarTelefon,
                    Id_Norma = @Id_Norma
                WHERE Id_Angajat = @IdAngajat";

                connection.Execute(query, new
                {
                    Nume = angajat.numeAngajat,
                    Prenume = angajat.prenumeAngajat,
                    Email = angajat.emailAngajat,
                    NumarTelefon = angajat.numarTelefonAngajat,
                    IdAngajat = angajat.Id_Angajat,
                    Id_Norma = angajat.Id_Norma
                });
            }
        }
        public static void ActualizeazaCont(Cont cont)
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                connection.Open();

                string query = @"
            UPDATE Cont 
            SET UserCont = @User, 
                ParolaCont = @Parola
            WHERE Id_Cont = @IdCont";

                connection.Execute(query, new
                {
                    User = cont.UserCont,
                    Parola = cont.ParolaCont,
                    IdCont = cont.Id_Cont
                });
            }
        }


        public static Cont ReturnareContAngajat(string idAngajat)
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                connection.Open();
                string query = @"
            SELECT C.*
            FROM Angajat A
            JOIN Cont C ON A.Id_Cont = C.Id_Cont
            WHERE A.Id_Angajat = @IdAngajat";

                return connection.QuerySingleOrDefault<Cont>(query, new { IdAngajat = idAngajat });
            }
        }

        public static List<AfisareAdministrareAngajati> ReturnareAfisareAdministrareAngajati(bool activ)
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                connection.Open();

                string query = @"
            SELECT
                A.Id_Angajat AS idAngajat,
                CONCAT(A.numeAngajat, ' ', A.prenumeAngajat) AS fullName,
                A.emailAngajat AS email,
                COALESCE(COUNT(DISTINCT P.Id_Proiect), 0) AS numarProiecteAlocate,
                COALESCE(COUNT(DISTINCT T.Id_Task), 0) AS numarTaskuriAlocate
            FROM 
                Angajat A
            LEFT JOIN 
                Detine D ON A.Id_Angajat = D.Id_Angajat
            LEFT JOIN 
                Participa P ON A.Id_Angajat = P.Id_Angajat
            LEFT JOIN 
                Task T ON P.Id_Task = T.Id_Task 
                WHERE
            P.dataparasiretask > SYSDATETIME() OR P.dataparasiretask IS NULL";
                query += @"
            GROUP BY
                A.Id_Angajat, A.numeAngajat, A.prenumeAngajat, A.emailAngajat";

                if (activ)
                {
                    query += @"
            HAVING
                COALESCE(COUNT(DISTINCT P.Id_Proiect), 0) <> 0 OR COALESCE(COUNT(DISTINCT T.Id_Task), 0) <> 0";
                }

                return connection.Query<AfisareAdministrareAngajati>(query).AsList();
            }
        }
        public static List<AfisareAdministrareAngajati> ReturnareAfisareAdministrareAngajatiCuFiltru(string searchValue)
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                connection.Open();

                string query = @"
            SELECT
                A.Id_Angajat AS idAngajat,
                CONCAT(A.numeAngajat, ' ', A.prenumeAngajat) AS fullName,
                A.emailAngajat AS email,
                COUNT(DISTINCT P.Id_Proiect) AS numarProiecteAlocate,
                COUNT(DISTINCT T.Id_Task) AS numarTaskuriAlocate
            FROM 
                Angajat A
            LEFT JOIN 
                Detine D ON A.Id_Angajat = D.Id_Angajat
            LEFT JOIN 
                Participa P ON A.Id_Angajat = P.Id_Angajat
            LEFT JOIN 
                Task T ON P.Id_Task = T.Id_Task
            WHERE
                CONCAT(A.numeAngajat, ' ', A.prenumeAngajat) LIKE @SearchValue
            AND
                P.dataparasiretask > SYSDATETIME()
            GROUP BY
                A.Id_Angajat, A.numeAngajat, A.prenumeAngajat, A.emailAngajat";

                return connection.Query<AfisareAdministrareAngajati>(query, new { SearchValue = $"%{searchValue}%" }).AsList();
            }
        }
        public static void DeleteAngajat(string idAngajat)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                string sql = "DELETE FROM Angajat WHERE Id_Angajat = @Id_Angajat";
                var parameters = new { Id_Angajat = idAngajat };
                connection.Open();
                connection.Execute(sql, parameters);
            }
        }
        public static List<AngajatAlocat> GetAngajatiAlocatiAstazi()
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                connection.Open();

                string angajatiQuery = @"
                    SELECT a.*, n.normaOre
                    FROM Angajat a
                    JOIN Norma n ON a.Id_Norma = n.Id_Norma;
                ";

                string oreLucrateQuery = @"
                    SELECT p.Id_Angajat, SUM(p.nrOre) AS OreLucrate
                    FROM Participa p
                    WHERE CAST(GETDATE() AS DATE) BETWEEN p.dataParticipareTask AND ISNULL(p.dataParasireTask, '9999-12-31')
                    GROUP BY p.Id_Angajat;
                ";

                List<Angajat> angajati = connection.Query<Angajat>(angajatiQuery).ToList();

                var oreLucrate = connection.Query(oreLucrateQuery).ToDictionary(row => (string)row.Id_Angajat, row => (decimal)row.OreLucrate);

                List<AngajatAlocat> angajatiAlocati = angajati.Select(a =>
                {
                    decimal normaOre = ExtrageNrOreAngajat(a.Id_Angajat);
                    decimal oreLucrateAstazi = oreLucrate.ContainsKey(a.Id_Angajat) ? oreLucrate[a.Id_Angajat] : 0;
                    decimal oreRamasDeLucrat = normaOre - oreLucrateAstazi;
                    return new AngajatAlocat
                    {
                        angajat = a,
                        nrOreRamasDeLucrat = oreRamasDeLucrat,
                        esteOcupat = oreRamasDeLucrat <= 0
                    };
                }).ToList();

                return angajatiAlocati;
            }
        }
        #endregion
        #region Pontaj
        public static void AddPontaj(Pontaj pontaj)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Execute("INSERT INTO Pontaj (Id_Angajat, nrOre, dataPontare, Id_Proiect, Id_Task) VALUES (@Id_Angajat, @nrOre, @dataPontare, @Id_Proiect, @Id_Task)",
                    new { Id_Angajat = pontaj.Id_Angajat, nrOre = pontaj.nrOre, dataPontare = pontaj.dataPontare, Id_Proiect = pontaj.Id_Proiect, Id_Task = pontaj.Id_Task });
            }
        }
        public static List<Pontaj> ExtragePontajeWithDapper()
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var listaPontaje = con.Query<Pontaj>("Select * from Pontaj").ToList();
                return listaPontaje;
            }
        }
        public static Pontaj ExtragePontajZiCurentaPeTask(string idAngajat, string idTask)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"
            SELECT * 
            FROM pontaj p 
            WHERE CONVERT(date, p.DataPontare) = CONVERT(date, GETDATE())
            AND Id_Angajat = @IdAngajat
            AND Id_Task = @IdTask";

                Pontaj pontaj = con.QueryFirstOrDefault<Pontaj>(query, new { IdAngajat = idAngajat, IdTask = idTask });
                return pontaj;
            }
        }
        public static List<Pontaj> ExtragePontajZiCurentaTotal(string idAngajat)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"
            SELECT * 
            FROM pontaj p 
            WHERE CONVERT(date, p.DataPontare) = CONVERT(date, GETDATE())
            AND Id_Angajat = @IdAngajat";

                List<Pontaj> listaPontaje = con.Query<Pontaj>(query, new { IdAngajat = idAngajat }).ToList();
                return listaPontaje;
            }
        }
        public static void UpdatePontaj(Pontaj pontaj)
        {


            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"UPDATE Pontaj 
                     SET nrOre = @NrOre
                     WHERE Id_Proiect = @IdProiect 
                       AND Id_Task = @IdTask 
                       AND Id_Angajat = @IdAngajat 
                       AND dataPontare = @DataPontare";
                connection.Open();
                connection.Execute(query, new
                {
                    NrOre = pontaj.nrOre,
                    IdProiect = pontaj.Id_Proiect,
                    IdTask = pontaj.Id_Task,
                    IdAngajat = pontaj.Id_Angajat,
                    DataPontare = pontaj.dataPontare
                });
            }
        }
        public static void DeletePontaj(Pontaj pontaj)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                string sql = @"
                DELETE FROM Pontaj
                WHERE Id_Angajat = @Id_Angajat
                AND Id_Proiect = @Id_Proiect
                AND Id_Task = @Id_Task
                AND dataPontare = @dataPontare";

                var parameters = new
                {
                    Id_Angajat = pontaj.Id_Angajat,
                    Id_Proiect = pontaj.Id_Proiect,
                    Id_Task = pontaj.Id_Task,
                    dataPontare = pontaj.dataPontare
                };

                connection.Open();
                connection.Execute(sql, parameters);
            }
        }
        public static int NumarPontariLunaCurenta(string idAngajat)
        {
            DateTime primaZiLunaCurenta = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ultimaZiLunaCurenta = primaZiLunaCurenta.AddMonths(1).AddDays(-1);

            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"
            SELECT COUNT(*) 
            FROM Pontaj 
            WHERE Id_Angajat = @IdAngajat 
            AND DataPontare BETWEEN @PrimaZi AND @UltimaZi";

                con.Open();
                int numarPontari = con.ExecuteScalar<int>(query, new
                {
                    IdAngajat = idAngajat,
                    PrimaZi = primaZiLunaCurenta,
                    UltimaZi = ultimaZiLunaCurenta
                });

                return numarPontari;
            }
        }


        #endregion
        #region DetineAngajatSkill
        public static List<DetineAngajatSkill> ExtrageSkilluriAngajatiWithDapper()
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var listaSkilluriAngajati = con.Query<DetineAngajatSkill>("Select * from Detine").ToList();
                return listaSkilluriAngajati;
            }
        }
        public static void AlocareSkillAngajat(DetineAngajatSkill angajatSkill)
        {
            string query = "INSERT INTO detine (Id_Angajat, Id_Skill, dataObtinere) VALUES (@IdAngajat, @IdSkill, @DataObtinere)";

            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Open();
                con.Execute(query, new
                {
                    IdAngajat = angajatSkill.Id_Angajat,
                    IdSkill = angajatSkill.Id_Skill,
                    DataObtinere = angajatSkill.dataObtinere
                });
            }
        }
        public static bool VerificareExistentaAngajatSkill(string idAngajat, string denumireSkill, string nivelSkill)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"
            SELECT COUNT(*)
            FROM Detine d
            JOIN Skill s ON d.Id_Skill = s.Id_Skill
            WHERE d.Id_Angajat = @IdAngajat
            AND s.denumireSkill = @DenumireSkill
            AND s.nivelSkill = @NivelSkill";

                int numarAngajatiCuSkillSiNivel = con.QueryFirstOrDefault<int>(query, new { IdAngajat = idAngajat, DenumireSkill = denumireSkill, NivelSkill = nivelSkill });

                return numarAngajatiCuSkillSiNivel > 0;
            }

        }
        public static bool VerificareExistentaNivelAngajatSkill(String idAngajat, String idSkill)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = "SELECT COUNT(*) FROM Detine WHERE Id_Angajat = @Id_Angajat AND Id_Skill = @Id_Skill";

                int numarAngajatiCuSkill = con.QueryFirstOrDefault<int>(query, new { Id_Angajat = idAngajat, Id_Skill = idSkill });

                return numarAngajatiCuSkill > 0;
            }
        }
        #endregion
        #region Validari
        public static bool VerificareCredentialeLogare(String user, String parola)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                string query = "SELECT COUNT(*) FROM Cont WHERE UserCont = @UserContParam AND ParolaCont = @ParolaContParam";
                int numarUtilizatori = connection.ExecuteScalar<int>(query, new { UserContParam = user, ParolaContParam = parola });

                return numarUtilizatori > 0;
            }
        }
        #endregion
        #region Cont
        public static void AddCont(Cont cont)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Execute("Insert into Cont (Id_Cont, UserCont, ParolaCont) VALUES " +
                    "('" + cont.Id_Cont + "','" + cont.UserCont + "','" + cont.ParolaCont + "')");
            }
        }
        public static List<Cont> ExtrageConturiWithDapper()
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var listaConturiDapper = con.Query<Cont>("Select * from Cont").ToList();
                return listaConturiDapper;
            }
        }
        #endregion
        #region Norma
        public static void AddNorma(Norma norma)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Execute("Insert into Norma (Id_Norma, denumireNorma, normaOre) VALUES " +
                    "('" + norma.Id_Norma + "',N'" + norma.denumireNorma + "','" + norma.normaOre + "')");
            }
        }
        public static List<Norma> ExtrageNormeWithDapper()
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var listaNormeDapper = con.Query<Norma>("Select * from Norma").ToList();
                return listaNormeDapper;
            }
        }

        public static decimal ExtrageNrOreAngajat(string idAngajat)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string querryNrOreNorma = @"
            select n.normaOre from norma n inner join angajat a on a.Id_Norma = n.Id_Norma and a.Id_Angajat= @IdAngajat";
                decimal nrOreNorma = con.QueryFirstOrDefault<decimal>(querryNrOreNorma, new { IdAngajat = idAngajat });
                return nrOreNorma;
            }

        }
        #endregion
        #region Departament
        public static void AddDepartament(Departament departament)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Execute("Insert into Departament (Id_Departament, denumireDepartament) VALUES " +
                    "('" + departament.Id_Departament + "',N'" + departament.denumireDepartament + "')");
            }
        }
        public static List<Departament> ExtrageDepartamenteWithDapper()
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var listaDepartamenteDapper = con.Query<Departament>("Select * from Departament").ToList();
                return listaDepartamenteDapper;
            }
        }
        #endregion
        #region ApartineAngajatDepartament
        public static void AddAngajatDepartament(ApartineAngajatDepartament apartineAngajatDepartament)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = "INSERT INTO Apartine (Id_Angajat, Id_Departament, dataIntrare, dataIesire) " +
                               "VALUES (@Id_Angajat, @Id_Departament, @DataIntrare, @DataIesire)";

                var parameters = new DynamicParameters();
                parameters.Add("@Id_Angajat", apartineAngajatDepartament.Id_Angajat);
                parameters.Add("@Id_Departament", apartineAngajatDepartament.Id_Departament);
                parameters.Add("@DataIntrare", apartineAngajatDepartament.DataIntrare);
                parameters.Add("@DataIesire", apartineAngajatDepartament.DataIesire);

                con.Execute(query, parameters);
            }
        }
        public static List<ApartineAngajatDepartament> ExtrageAngajatiDepartamenteWithDapper()
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var listaAngajatiDepartamenteDapper = con.Query<ApartineAngajatDepartament>("Select * from Apartine").ToList();
                return listaAngajatiDepartamenteDapper;
            }
        }
        public static List<ApartineAngajatDepartament> ExtrageAngajatiDepartamenteByIdAngajat(string idAngajat)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var parameters = new { Id_Angajat = idAngajat };
                string query = @"
            SELECT * 
            FROM Apartine
            WHERE Id_Angajat = @Id_Angajat AND DataIesire > GETDATE();";

                var result = con.Query<ApartineAngajatDepartament>(query, parameters);
                return result.ToList();
            }
        }
        public static string ExtrageDenumireDepartamentById(string idDepartament)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = "SELECT DenumireDepartament FROM Departament WHERE Id_departament = @IdDepartament";
                var parametri = new { IdDepartament = idDepartament };
                return con.QueryFirstOrDefault<string>(query, parametri);
            }
        }


        public static void EliminaAngajatDepartament(String idAngajat, String idDepartament, DateTime dataIesire)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = "UPDATE Apartine SET DataIesire = @DataIesire WHERE Id_Angajat = @Id_Angajat AND Id_Departament = @Id_Departament";
                con.Execute(query, new { Id_Angajat = idAngajat, Id_Departament = idDepartament, DataIesire = dataIesire });
            }
        }
        #endregion
        #region Proiect
        public static void AddProiect(Proiect proiect)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Execute("Insert into Proiect (Id_Proiect, denumireProiect) VALUES " +
                    "('" + proiect.Id_Proiect + "',N'" + proiect.denumireProiect + "')");
            }
        }
        public static List<Proiect> ExtrageProiecteWithDapper()
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var listaProiecte = con.Query<Proiect>("Select * from Proiect").ToList();
                return listaProiecte;
            }
        }
        public static List<Proiect> ExtrageProiecteAngajat(string idAngajat)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"
        SELECT p.* 
        FROM Proiect p
        JOIN Participa pa ON p.Id_Proiect = pa.Id_Proiect
        WHERE pa.Id_Angajat = @IdAngajat
        AND pa.DataParasireTask > GETDATE()";

                var proiecte = con.Query<Proiect>(query, new { IdAngajat = idAngajat }).ToList();
                return proiecte;
            }
        }

        public static decimal ExtrageNrOreParticipare(string idAngajat, string idTask)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"
            select p.nrOre 
            from participa p 
            where Id_Angajat = @IdAngajat and Id_Task = @IdTask";

                var nrOreAlocate = con.Query<decimal>(query, new { IdAngajat = idAngajat, IdTask = idTask }).FirstOrDefault();
                return nrOreAlocate;
            }
        }
        public static string ExtrageDenumireProiect(string IdProiect)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"SELECT denumireProiect FROM Proiect WHERE Id_Proiect = @IdProiect";

                return con.Query<string>(query, new { IdProiect = IdProiect }).FirstOrDefault();
            }
        }
        public static void UpdateProiect(Proiect proiect)
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                string queryProiect = "UPDATE Proiect SET denumireProiect = @denumireProiect WHERE Id_Proiect = @Id_Proiect";
                connection.Execute(queryProiect, new
                {
                    denumireProiect = proiect.denumireProiect, // corectare nume variabilă
                    Id_Proiect = proiect.Id_Proiect // corectare nume variabilă
                });
            }
        }

        #endregion
        #region Perioada Proiect
        public static void AddPerioadaProiect(PerioadaProiect perioadaProiect)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Execute("Insert into PerioadaProiect (Id_Proiect, Id_Perioada) VALUES " +
                    "('" + perioadaProiect.Id_Proiect + "','" + perioadaProiect.Id_Perioada + "')");
            }
        }
        public static List<PerioadaProiect> ExtragePerioadeProiectWithDapper()
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var listaPerioadeProiect = con.Query<PerioadaProiect>("Select * from PerioadaProiect").ToList();
                return listaPerioadeProiect;
            }
        }
        public static (DateTime dataIncepereProiect, DateTime dataFinalizareProiect) ExtrageDetaliiProiect(string idProiect)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string queryPerioada = @"
            SELECT MIN(CONVERT(datetime, p.an + '-' + p.luna + '-' + p.zi)) AS DataInceput, 
                   MAX(CONVERT(datetime, p.an + '-' + p.luna + '-' + p.zi)) AS DataFinalizare
            FROM Perioada p
            INNER JOIN perioadaProiect pp ON p.Id_Perioada = pp.Id_Perioada
            WHERE pp.Id_Proiect = @IdProiect";

                var result = con.QueryFirstOrDefault<(DateTime dataInceputProiect, DateTime dataFinalizareProiect)>(queryPerioada, new { IdProiect = idProiect });

                return result;
            }
        }

        #endregion
        #region Perioada Task
        public static void AddPerioadaTask(PerioadaTask perioadaTask)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {

                con.Execute("INSERT INTO PerioadaTask (Id_Proiect, Id_Task, Id_Perioada) VALUES (@Id_Proiect, @Id_Task, @Id_Perioada)",
                    new { Id_Proiect = perioadaTask.Id_Proiect, Id_Task = perioadaTask.Id_Task, Id_Perioada = perioadaTask.Id_Perioada });
            }
        }
        public static List<PerioadaTask> ExtragePerioadeTaskWithDapper()
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var listaPerioadeTask = con.Query<PerioadaTask>("Select * from PerioadaTask").ToList();
                return listaPerioadeTask;
            }
        }

        #endregion
        #region Perioada
        public static void AddPerioada(Perioada perioada)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Execute("Insert into Perioada (Id_Perioada, an, luna, zi, tipPerioada, Id_Angajat) VALUES " +
                    "('" + perioada.Id_Perioada + "','" + perioada.an + "','" + perioada.luna + "'" +
                    ",'" + perioada.zi + "','" + perioada.tipPerioada + "','" + perioada.Id_Angajat + "')");
            }
        }
        public static List<Perioada> ExtragePerioadeWithDapper()
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var listaPerioade = con.Query<Perioada>("Select * from Perioada").ToList();
                return listaPerioade;
            }
        }
        public static List<string> ReturnareIdPerioada(string Id_Task, string Id_Proiect)
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                connection.Open();
                string queryPerioada = @"
            SELECT TOP 2 Id_Perioada
            FROM perioada
            WHERE Id_Perioada IN (
                SELECT Id_Perioada
                FROM perioadaTask
                WHERE Id_Task = @idTask AND Id_Proiect = @idProiect
            )
            ORDER BY CAST(SUBSTRING(Id_Perioada, 4, LEN(Id_Perioada) - 3) AS INT) DESC;";

                var idPerioade = connection.Query<string>(queryPerioada, new { idTask = Id_Task, idProiect = Id_Proiect }).ToList();

                return idPerioade;
            }
        }
        public static List<string> ReturnareIdPerioadaProiect(string Id_Proiect)
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                connection.Open();
                string queryPerioada = @"
            SELECT TOP 2 Id_Perioada
            FROM perioada
            WHERE Id_Perioada IN (
                SELECT Id_Perioada
                FROM perioadaProiect
                WHERE Id_Proiect = @idProiect
            )
            ORDER BY CAST(SUBSTRING(Id_Perioada, 4, LEN(Id_Perioada) - 3) AS INT) DESC;";

                var idPerioade = connection.Query<string>(queryPerioada, new {idProiect = Id_Proiect }).ToList();

                return idPerioade;
            }
        }
        public static void ActualizeazaPerioada(Perioada perioadaInceput, Perioada perioadaSfarsit, string idTask, string idProiect)
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                List<string> listaPerioade = ReturnareIdPerioada(idTask, idProiect);

                string idPerioadaSfarsit = listaPerioade[0];
                string idPerioadaInceput = listaPerioade[1];

                // Query pentru actualizarea perioadei de sfârșit
                string queryPerioadaSfarsit = @"
            UPDATE perioada
            SET an = @AnSfarsit, luna = @LunaSfarsit, zi = @ZiSfarsit
            WHERE Id_Perioada = @IdPerioadaSfarsit;";

                // Executăm actualizarea perioadei de sfârșit
                connection.Execute(queryPerioadaSfarsit, new
                {
                    AnSfarsit = perioadaSfarsit.an,
                    LunaSfarsit = perioadaSfarsit.luna,
                    ZiSfarsit = perioadaSfarsit.zi,
                    IdPerioadaSfarsit = idPerioadaSfarsit
                });

                // Query pentru actualizarea perioadei de început
                string queryPerioadaInceput = @"
            UPDATE perioada
            SET an = @AnInceput, luna = @LunaInceput, zi = @ZiInceput
            WHERE Id_Perioada = @IdPerioadaInceput;";

                // Executăm actualizarea perioadei de început
                connection.Execute(queryPerioadaInceput, new
                {
                    AnInceput = perioadaInceput.an,
                    LunaInceput = perioadaInceput.luna,
                    ZiInceput = perioadaInceput.zi,
                    IdPerioadaInceput = idPerioadaInceput
                });
            }
        }
        public static void ActualizeazaPerioadaProiect(Perioada perioadaInceput, Perioada perioadaSfarsit, string idProiect)
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                List<string> listaPerioade = ReturnareIdPerioadaProiect(idProiect);

                string idPerioadaSfarsit = listaPerioade[0];
                string idPerioadaInceput = listaPerioade[1];

                // Query pentru actualizarea perioadei de sfârșit
                string queryPerioadaSfarsit = @"
            UPDATE perioada
            SET an = @AnSfarsit, luna = @LunaSfarsit, zi = @ZiSfarsit
            WHERE Id_Perioada = @IdPerioadaSfarsit;";

                // Executăm actualizarea perioadei de sfârșit
                connection.Execute(queryPerioadaSfarsit, new
                {
                    AnSfarsit = perioadaSfarsit.an,
                    LunaSfarsit = perioadaSfarsit.luna,
                    ZiSfarsit = perioadaSfarsit.zi,
                    IdPerioadaSfarsit = idPerioadaSfarsit
                });

                // Query pentru actualizarea perioadei de început
                string queryPerioadaInceput = @"
            UPDATE perioada
            SET an = @AnInceput, luna = @LunaInceput, zi = @ZiInceput
            WHERE Id_Perioada = @IdPerioadaInceput;";

                // Executăm actualizarea perioadei de început
                connection.Execute(queryPerioadaInceput, new
                {
                    AnInceput = perioadaInceput.an,
                    LunaInceput = perioadaInceput.luna,
                    ZiInceput = perioadaInceput.zi,
                    IdPerioadaInceput = idPerioadaInceput
                });
            }
        }

        #endregion
        #region Participa
        public static void AddParticipa(Participa participa)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Execute("INSERT INTO Participa (Id_Angajat, Id_Proiect, Id_Task, dataParticipareTask, dataParasireTask, nrOre) VALUES (@Id_Angajat, @Id_Proiect, @Id_Task, @dataParticipareTask, @dataParasireTask, @nrOre)",
                    new { Id_Angajat = participa.Id_Angajat, Id_Proiect = participa.Id_Proiect, Id_Task = participa.Id_Task, dataParticipareTask = participa.dataParticipareTask, dataParasireTask = participa.dataParasireTask, nrOre = participa.nrOre });
            }
        }
        public static List<Participa> ExtrageParticipariWithDapper()
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var listaParticipari = con.Query<Participa>("Select * from Participa").ToList();
                return listaParticipari;
            }
        }
        public static List<IntervalLucru> DetaliiPerioadaDeLucru(string idTask)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"
            SELECT Id_Angajat, dataParticipareTask, dataParasireTask, nrOre 
            FROM Participa 
            WHERE Id_Task = @IdTask";

                var results = con.Query<(string, DateTime, DateTime, decimal)>(query, new { IdTask = idTask }).ToList();

                List<IntervalLucru> detaliiPerioade = new List<IntervalLucru>();

                foreach (var result in results)
                {
                    string idAngajatResult = result.Item1;
                    DateTime dataParticipare = result.Item2;
                    DateTime dataParasire = result.Item3;
                    decimal nrOre = result.Item4;

                    IntervalLucru interval = new IntervalLucru
                    {
                        Id_Angajat = idAngajatResult,
                        DataInceput = dataParticipare,
                        DataSfarsit = dataParasire,
                        NrOre = nrOre,
                        NrZile = FormAlocareAngajat.CalculeazaZileLucratoare(dataParticipare, dataParasire)
                    };

                    detaliiPerioade.Add(interval);
                }

                return detaliiPerioade;
            }
        }
        public static IntervalLucru DetaliiPerioadaDeLucruAngajat(string idAngajat, string idTask)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"
            SELECT dataParticipareTask AS DataInceput, dataParasireTask AS DataSfarsit, nrOre AS NrOre 
            FROM Participa 
            WHERE Id_Angajat = @IdAngajat AND Id_Task = @IdTask";

                IntervalLucru result = con.QueryFirstOrDefault<IntervalLucru>(query, new { IdAngajat = idAngajat, IdTask = idTask });
                if (result != null)
                {
                    result.NrZile = FormAlocareAngajat.CalculeazaZileLucratoare(result.DataInceput, result.DataSfarsit);

                    return result;
                }
                return null;
            }
        }
        public static int ReturnareNrOreZiCurenta(string idAngajat, string idTask)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query =
            @"SELECT p.nrOre FROM participa p WHERE " +
            "p.Id_Angajat = @idAngajat AND " +
            "p.Id_Task = @idTask";

                int nrOre = con.QueryFirstOrDefault<int>(query, new { idAngajat, idTask });

                return nrOre;
            }
        }
        public static int ReturnareNrAngajatiTask(string idTask)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = "SELECT COUNT(Id_Angajat) FROM Participa WHERE Id_Task = @IdTask";
                int nrAngajati = con.ExecuteScalar<int>(query, new { IdTask = idTask });
                return nrAngajati;
            }
        }
        public static List<Angajat> AngajatiPeTask(string idTask)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"
                SELECT a.* 
                FROM Angajat a
                INNER JOIN Participa p ON a.Id_Angajat = p.Id_Angajat
                WHERE p.Id_Task = @IdTask";

                return con.Query<Angajat>(query, new { IdTask = idTask }).ToList();
            }
        }
        public static List<Angajat> AngajatiDisponibiliPentruTask(string idTask)//selecteaza toti angajatii care nu participa la taskul selectat
        {
            using (IDbConnection db = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"
            SELECT * 
            FROM Angajat
            WHERE Id_Angajat NOT IN (
                SELECT Id_Angajat 
                FROM Participa 
                WHERE Id_Task = @IdTask
            )";
                var angajatiDisponibili = db.Query<Angajat>(query, new { IdTask = idTask });
                return angajatiDisponibili.ToList();
            }
        }
        public static List<Task> ReturnareListaTaskuriAngajatAlocat(string idAngajat, string idProiect)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"
            SELECT 
                T.*
            FROM 
                Participa P
            LEFT JOIN 
                Task T ON P.Id_Proiect = T.Id_Proiect AND P.Id_Task = T.Id_Task
            WHERE 
                P.Id_Angajat = @IdAngajat AND P.Id_Proiect = @IdProiect";

                List<Task> listaTaskuriAngajat = connection.Query<Task>(query, new { IdAngajat = idAngajat, IdProiect = idProiect }).ToList();

                return listaTaskuriAngajat;
            }
        }
        public static List<Proiect> ReturnareListaProiecteAngajatAlocat(string idAngajat)
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"
        SELECT pr.* 
        FROM participa p 
        LEFT JOIN proiect pr ON pr.Id_Proiect = p.Id_Proiect 
        WHERE p.Id_Angajat = @IdAngajat";

                List<Proiect> listaProiecteAngajat = connection.Query<Proiect>(query, new { IdAngajat = idAngajat }).ToList();

                List<Proiect> listaProiecteUnice = listaProiecteAngajat
                    .GroupBy(p => p.Id_Proiect)
                    .Select(g => g.First())
                    .ToList();

                return listaProiecteUnice;
            }
        }
        public static void EliminaAngajatDeLaTask(string idTask, string idAngajat)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                // Verificăm dacă există o înregistrare pentru această asociere
                Participa participare = connection.QueryFirstOrDefault<Participa>(
                    "SELECT * FROM Participa WHERE Id_Task = @Id_Task AND Id_Angajat = @Id_Angajat",
                    new { Id_Task = idTask, Id_Angajat = idAngajat });

                if (participare != null)
                {
                    string queryUpdateParticipare = "UPDATE Participa SET dataParasireTask = GETDATE() WHERE Id_Task = @Id_Task AND Id_Angajat = @Id_Angajat";
                    connection.Execute(queryUpdateParticipare, new { Id_Task = idTask, Id_Angajat = idAngajat });
                }
            }
        }
        public static List<Participa> ExtrageParticipariAngajatZi(string idAngajat, DateTime data)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"
            SELECT Id_Angajat, Id_Proiect, Id_Task, dataParticipareTask, dataParasireTask, nrOre
            FROM Participa
            WHERE Id_Angajat = @IdAngajat
            AND CONVERT(date, dataParticipareTask) <= @Data
            AND CONVERT(date, dataParasireTask) >= @Data";

                var participari = con.Query<Participa>(query, new { IdAngajat = idAngajat, Data = data.Date }).ToList();
                return participari;
            }
        }

        #endregion
        #region Descriere
        public static void AddDescriere(Descriere descriere)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Execute("INSERT INTO Descriere (Id_Descriere, descriereTask) VALUES (@Id_Descriere, @descriereTask)",
                    new { Id_Descriere = descriere.Id_Descriere, descriereTask = descriere.descriereTask });
            }
        }

        public static List<Descriere> ExtrageDescrieriWithDapper()
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var listaDescrieri = con.Query<Descriere>("Select * from Descriere").ToList();
                return listaDescrieri;
            }
        }
        public static string ExtrageDescriereById(string idDescriere)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Open();
                string query = "SELECT descriereTask FROM Descriere WHERE Id_Descriere = @Id_Descriere";
                string descriere = con.QueryFirstOrDefault<string>(query, new { Id_Descriere = idDescriere });
                return descriere;
            }
        }
        public static void ActualizareDescriere(string descriere, string idTask)
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                string query = @"
            UPDATE Descriere
            SET descriereTask = @DescriereTask
            WHERE Id_Descriere = (
                SELECT d.Id_Descriere
                FROM Descriere d
                JOIN Task t ON d.Id_Descriere = t.Id_Descriere
                WHERE t.Id_Task = @IdTask
            )";
                connection.Execute(query, new
                {
                    DescriereTask = descriere,
                    IdTask = idTask
                });
            }
        }

        #endregion
        #region Manageriaza
        public static void AddManageriaza(Manageriaza manageriaza)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Execute("INSERT INTO Manageriaza (Id_Angajat, Id_Proiect, dataInceput, dataSfarsit) VALUES (@Id_Angajat, @Id_Proiect, @dataInceput, @dataSfarsit)",
                    new { Id_Angajat = manageriaza.Id_Angajat, Id_Proiect = manageriaza.Id_Proiect, dataInceput = manageriaza.dataInceput, dataSfarsit = manageriaza.dataSfarsit });
            }
        }
        #endregion
        #region ComentariuTask
        public static void AddComentariuTask(ComentariuTask comentariu)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Execute("INSERT INTO ComentariuTask (Id_ComentariuTask, textComentariuTask, dataComentariu, Id_Proiect, Id_Task, Id_Angajat) VALUES " +
                    "(@Id_ComentariuTask, @textComentariuTask, @dataComentariu, @Id_Proiect, @Id_Task, @Id_Angajat)", comentariu);
            }
        }

        public static List<ComentariuTask> ExtrageComentariiTaskWithDapper()
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var listaComentariiDapper = con.Query<ComentariuTask>("SELECT * FROM ComentariuTask").ToList();
                return listaComentariiDapper;
            }
        }
        public static List<ComentariuTask> ExtrageComentariiTaskByTaskId(string taskId)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var listaComentariiDapper = con.Query<ComentariuTask>(
                    "SELECT * FROM ComentariuTask WHERE Id_Task = @Id_Task",
                    new { Id_Task = taskId }
                ).ToList();
                return listaComentariiDapper;
            }
        }
        public static void StergeComentariuTask(string idComentariu)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                con.Execute("DELETE FROM ComentariuTask WHERE Id_ComentariuTask = @Id", new { Id = idComentariu });
            }
        }

        #endregion
    }
}
