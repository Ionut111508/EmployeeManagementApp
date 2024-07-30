select * from perioadaProiect;
select * from perioada;
select * from pontaj;
select * from cont;
select * from norma;
select * from skill;
select * from angajat;
select * from Apartine t where t.Id_Angajat='A3';
select * from Departament
select * from Proiect order by Id_Proiect;
select * from Manageriaza;
select * from task t where t.id_proiect ='P3';
select * from comentariutask;
select * from descriere
select * from perioada where Id_Perioada in ('PER55','PER56');
select * from perioadaProiect where Id_Proiect='P12';
update Descriere set descriereTask='Sprijinirea agriculturii regionale și a politicilor FNS' where Id_Descriere='DES23';
update perioada set luna=11 where Id_Perioada='PER61';
update perioada set zi=14 where Id_Perioada='PER62';
update perioada set an=2025 where Id_Perioada='PER62';

select * from angajat a join cont c on a.Id_Cont=c.Id_Cont where c.UserCont='manager';
delete from task where Id_Task='P15-T2';

delete from cont where id_cont='C14';

select * from task;

SELECT t.denumireTask, p.zi, p.luna, p.an, p.tipPerioada
FROM Task t
JOIN perioadaTask pt ON t.Id_Task = pt.Id_Task
JOIN Perioada p ON pt.Id_Perioada = p.Id_Perioada
WHERE t.Id_Proiect = 'P3';

SELECT TOP 2 *
            FROM perioada
            WHERE Id_Perioada IN (
                SELECT Id_Perioada
                FROM perioadaTask
                WHERE Id_Proiect = 'P3'
            )
            ORDER BY CAST(SUBSTRING(Id_Perioada, 4, LEN(Id_Perioada) - 3) AS INT) DESC

select * from perioadaTask p where p.Id_Task='P3-T4';
select * from participa p where p.Id_Task='P3-T4';
update participa set dataParticipareTask='2024-07-01' where Id_Angajat='A7' and Id_Task='P3-T4';
select * from task where Id_Task='P3-T2';
select * from perioadaTask t where t.Id_Task='P13-T1';
select * from participa p order by Id_Task;
select * from participa order by Id_Task;
select * from participa p where p.Id_Angajat='A1' and p.dataParticipareTask<GETDATE() and p.dataParasireTask>GETDATE();
select * from Participa where Id_Angajat='A7' order by dataParticipareTask;
select * from task t inner join Participa p on p.Id_Task=t.Id_Task;
select * from Descriere d join task t on d.Id_Descriere=t.Id_Descriere where t.Id_Task='t1';
update Descriere set descriereTask=@descriereTask where Id_Descriere=(select d.Id_Descriere from Descriere d join task t on d.Id_Descriere=t.Id_Descriere where t.Id_Task=@task);
select * from perioadaTask where Id_Task='T1' and Id_Proiect='P1';

SELECT TOP 2 *
FROM perioada
WHERE Id_Perioada IN (
    SELECT Id_Perioada
    FROM perioadaProiect
    WHERE Id_Proiect = 'P12'
)
ORDER BY CAST(SUBSTRING(Id_Perioada, 4, LEN(Id_Perioada) - 3) AS INT) DESC;

SELECT TOP 2 Id_Perioada
            FROM perioada
            WHERE Id_Perioada IN (
                SELECT Id_Perioada
                FROM perioadaProiect
                WHERE Id_Proiect = 'P12'
            )
            ORDER BY CAST(SUBSTRING(Id_Perioada, 4, LEN(Id_Perioada) - 3) AS INT) DESC;

UPDATE perioada
            SET an = '2024', luna = '11', zi = '22'
            WHERE Id_Perioada = 'PER44';

 SELECT TOP 2 Id_Perioada
            FROM perioada
            WHERE Id_Perioada IN (
                SELECT Id_Perioada
                FROM perioadaTask
                WHERE Id_Task = 'P3-T2' AND Id_Proiect = 'P3'
            )
            ORDER BY CAST(SUBSTRING(Id_Perioada, 4, LEN(Id_Perioada) - 3) AS INT) DESC;

update perioada set an=@an, luna=@luna, zi=@zi where id_perioada=@idperioada;



SELECT TOP 2 *
FROM perioada
ORDER BY Id_Perioada DESC;

select a.numeAngajat, n.normaOre from angajat a join norma n on a.Id_Norma=n.Id_Norma order by a.numeAngajat;
select * from participa p where p.Id_Angajat in (select a.* from angajat a join norma n on a.Id_Norma=n.Id_Norma);

SELECT a.*
FROM Angajat a
JOIN Norma n ON a.Id_Norma = n.Id_Norma
LEFT JOIN (
    SELECT p.Id_Angajat, SUM(p.nrOre) AS totalOre
    FROM Participa p
    WHERE p.dataParticipareTask = CAST(GETDATE() AS DATE)
    GROUP BY p.Id_Angajat
) AS p ON a.Id_Angajat = p.Id_Angajat
WHERE COALESCE(p.totalOre, 0) < n.normaOre;


SELECT TOP 2 *
                FROM Perioada p
                INNER JOIN PerioadaTask pt ON p.Id_Perioada = pt.Id_Perioada
                WHERE pt.Id_Task = 'P15-T1'
                ORDER BY p.an, p.luna, p.zi


delete from detine where Id_Skill='Secretar-Junior';
delete from Descriere where Id_Descriere='DES7';
delete from perioada where Id_Perioada='PER40';
delete from perioada where Id_Perioada in ('PER7','PER78');
delete from proiect where Id_Proiect ='P4';
delete from Manageriaza where Id_Proiect='P5';
delete from task where Id_Task='P15-T2';
delete from participa where Id_Task='P7-T3';
delete from pontaj where Id_Task='P4T1';
delete from cont where Id_Cont in ('C1112','C1113','C111');
delete from angajat where id_cont in ('C1112','C1113','C111');

delete from task where Id_Proiect='P5';

delete from skill where Id_Skill='Jurist-Mediu';

 SELECT a.*, n.normaOre
                    FROM Angajat a
                    JOIN Norma n ON a.Id_Norma = n.Id_Norma;

                    SELECT p.Id_Angajat, SUM(p.nrOre) AS OreLucrate
                    FROM Participa p
                    WHERE CAST(GETDATE() AS DATE) BETWEEN p.dataParticipareTask AND ISNULL(p.dataParasireTask, '9999-12-31')
                    GROUP BY p.Id_Angajat

select distinct a.numeAngajat from angajat a join participa p on a.Id_Angajat=p.Id_Angajat
where p.dataParticipareTask<=GETDATE() and p.dataParasireTask>=GETDATE();
SELECT * 
FROM pontaj p 
WHERE CONVERT(date, p.DataPontare) = CONVERT(date, GETDATE())
AND Id_Angajat=@idangajat
and Id_Task =@idtask;

select p.nrOre from participa p where Id_Angajat='A1' and Id_Task='P7P7T3';

SELECT pr.* 
            FROM participa p 
            LEFT JOIN proiect pr ON pr.Id_Proiect = p.Id_Proiect 
            WHERE p.Id_Angajat = 'A3';

SELECT a.*
FROM Angajat a
LEFT JOIN Participa p ON a.Id_Angajat = p.Id_Angajat 
    AND CAST(GETDATE() AS DATE) BETWEEN p.dataParticipareTask AND ISNULL(p.dataParasireTask, CAST(GETDATE() AS DATE))
WHERE p.Id_Angajat IS NULL;

SELECT COUNT(*) 
            FROM Pontaj 
            WHERE Id_Angajat = 'A1' 
            AND DataPontare BETWEEN '2024-07-1' AND '2024-07-31';

            SELECT DISTINCT Id_Angajat, Id_Proiect, Id_Task, dataParticipareTask, dataParasireTask, nrOre
                    FROM Participa
                    WHERE Id_Angajat = 'A1'
                    and dataParticipareTask <= '2024-07-16'
                    and dataParasireTask >='2024-07-16';


SELECT 
                P.*
            FROM 
                Participa P
            LEFT JOIN 
                Proiect P ON P.Id_Proiect = T.Id_Proiect
            WHERE 
                Pr.Id_Angajat = 'A2';

                select pr.* from participa p left join proiect pr on pr.Id_Proiect = p.Id_Proiect where p.Id_Angajat='A2';
                select pr.* from participa p left join proiect pr on pr.Id_Proiect = p.Id_Proiect where p.Id_Angajat='@idAngajat'


SELECT 
                    t.*
                FROM 
                    Participa P
                LEFT JOIN 
                    Task T ON  P.Id_Task = T.Id_Task
                WHERE 
                    P.Id_Angajat = 'A1';

select t.denumireTask from task t where t.Id_Task='T2';

SELECT dataParticipareTask AS DataInceput, dataParasireTask AS DataSfarsit, nrOre AS NrOre 
            FROM Participa 
            WHERE Id_Angajat = 'A1' AND Id_Task = 'P8-T1';

SELECT 
    COUNT(DISTINCT P.Id_Proiect) AS NrProiecte,
    COUNT(DISTINCT T.Id_Task) AS NrTaskuri
FROM 
    Participa P
LEFT JOIN 
    Task T ON P.Id_Proiect = T.Id_Proiect AND P.Id_Task = T.Id_Task
WHERE 
    P.Id_Angajat = 'A6';



SELECT * 
FROM Angajat
            WHERE Id_Angajat NOT IN (
                SELECT Id_Angajat 
                FROM Participa 
                WHERE Id_Task = 'T1');

 SELECT DISTINCT A.*
                    FROM Angajat A
                    INNER JOIN Participa P ON A.Id_Angajat = P.Id_Angajat
                    INNER JOIN Norma N ON A.Id_Norma = N.Id_Norma
                    WHERE ((P.dataParticipareTask___PK BETWEEN @DataInceputTask AND @DataSfarsitTask)
                        OR (P.dataParasireTask BETWEEN @DataInceputTask AND @DataSfarsitTask)
                        OR (@DataInceputTask BETWEEN P.dataParticipareTask AND P.dataParasireTask)
                        OR (@DataSfarsitTask BETWEEN P.dataParticipareTask AND P.dataParasireTask))
                        AND P.nrOre < N.normaOre

delete from participa where Id_Angajat='A6' and dataParasireTask='2024-07-13';
SELECT t.* FROM Task t
            INNER JOIN Participa p ON t.Id_Task = p.Id_Task
            WHERE t.Id_Proiect = 'P1' AND p.Id_Angajat = 'A2';

SELECT a.*   FROM Angajat a
                INNER JOIN Participa p ON a.Id_Angajat = p.Id_Angajat
                WHERE p.Id_Task = 'P8-T1';

select p.dataParticipareTask, p.dataParasireTask, p.nrOre from participa p where Id_Task ='P8-T1';

delete from participa where Id_Task='T2';

SELECT a.* FROM Angajat a
                INNER JOIN Participa p ON a.Id_Angajat = p.Id_Angajat
                WHERE p.Id_Task = 'T2';

update task set numarOre=200 where Id_Task ='P4T1';
update participa set nrOre=2 where Id_Angajat='A2' and Id_Proiect='P1';
delete from participa where Id_Angajat='A1';

select * from participa p where p.Id_Task='P8-T1';
SELECT numeAngajat, prenumeAngajat FROM Angajat

ALTER TABLE participa
ALTER COLUMN dataParasireTask Date NOT NULL;


INSERT INTO Participa (Id_Angajat, Id_Proiect, Id_Task, dataParticipareTask, dataParasireTask, nrOre) 
VALUES ('A2', 'P5', 'P5 - T1', '2024-04-01', '2024-05-01', 1.0);

select p.nrOre from participa p where p.Id_Angajat = @idAngajat and p.Id_Task = @idTask and p.Id_Proiect = @idProiect;
select * from participa p;
ALTER TABLE Participa
ALTER COLUMN dataParasireTask DATE NULL;

update task set numarOre = 100 where id_task ='T2';

select t.numarOre from task t where t.Id_Task ='T1' and t.Id_Proiect ='P1';
select * from perioadaTask pt where pt.Id_Task='T1';
select  p.zi , p.luna, p.an from Perioada p where p.Id_Perioada IN (select pt.Id_Perioada from perioadaTask pt where pt.Id_Task='T2');
SELECT TOP 2 p.zi, p.luna, p.an
                FROM Perioada p
                INNER JOIN PerioadaTask pt ON p.Id_Perioada = pt.Id_Perioada
                WHERE pt.Id_Task = 'T1'
                AND pt.Id_Proiect ='P2'
                ORDER BY p.an, p.luna, p.zi;

select t.numarOre from task t where t.Id_Task='T1';

select * from norma n  ;
select n.normaOre from norma n inner join angajat a on a.Id_Norma = n.Id_Norma and a.Id_Angajat='A1';




select * from perioadaTask;
select * from perioadaProiect;
select * from descriere;
select * from participa p where p.Id_Angajat='A1';
update task set denumireTask='Generare de panouri fotovoltaice' where id_proiect='P2';
delete from descriere where Id_Descriere = 'DES2';
SELECT *
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
WHERE CONSTRAINT_NAME LIKE 'FK__Participa__5EBF139D%';

delete from cont where id_cont='C4';
select * from manageriaza;

ALTER TABLE descriere
ALTER COLUMN descriereTask VARCHAR(500);

ALTER TABLE [dbo].[perioadaProiect]
DROP CONSTRAINT PK__perioada__C3CCD8D22168B9FD;

delete from proiect;
delete from perioada;

delete from Apartine;
delete from participa;

SELECT CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME = 'Pontaj' AND CONSTRAINT_TYPE = 'PRIMARY KEY';


ALTER TABLE [dbo].[perioadaProiect]
ADD CONSTRAINT PK_perioadaProiect PRIMARY KEY CLUSTERED ([Id_Proiect] ASC, [Id_Perioada] ASC);


ALTER TABLE [dbo].[perioadaProiect]
DROP COLUMN dataIncepere;

SELECT numeAngajat, prenumeAngajat 
FROM angajat a 
join Cont c 
on a.Id_Cont=c.Id_Cont
WHERE a.Id_Cont = (select c.Id_Cont from cont c where c.UserCont='1' and c.ParolaCont='1');

select c.Id_Cont from cont c where c.UserCont='1' and c.ParolaCont='1';

delete from cont where id_cont in ('C2','C3','C4');
delete from departament;
delete from norma;
delete from skill;
delete from detine;
delete from apartine;
delete from angajat;
delete from pontaj;
delete from perioadaProiect;
delete from Perioada;
delete from Proiect;



select sysdate from dual;
ALTER TABLE [dbo].[Pontaj]
ADD CONSTRAINT PK_Pontaj PRIMARY KEY CLUSTERED ([Id_Proiect] ASC, [Id_Task] ASC, [Id_Angajat] ASC, [DataPontare] ASC);

ALTER TABLE [dbo].[Perioada]
ADD CONSTRAINT FK_Perioada_Angajat FOREIGN KEY ([Id_Angajat]) REFERENCES [dbo].[Angajat] ([Id_Angajat]);

ALTER TABLE Participa
ADD nrOre DECIMAL(2,1);

ALTER TABLE [dbo].[Pontaj]
ALTER COLUMN DataPontare SMALLDATETIME;

CREATE TABLE perioadaTask(
   Id_Proiect VARCHAR(50),
   Id_Task VARCHAR(50),
   Id_Perioada VARCHAR(50),
   PRIMARY KEY(Id_Proiect, Id_Task, Id_Perioada),
   FOREIGN KEY(Id_Proiect, Id_Task) REFERENCES Task(Id_Proiect, Id_Task),
   FOREIGN KEY(Id_Perioada) REFERENCES Perioada(Id_Perioada)
);




insert into cont (Id_Cont, UserCont, ParolaCont) values ('C1', 'admin', 'admin');
insert into norma (Id_Norma, denumireNorma, normaOre) values ('N1', 'Full Time', 8);
insert into angajat (Id_Angajat,numeAngajat,prenumeAngajat,emailAngajat,numarTelefonAngajat,Id_Cont,Id_Norma)
	values ('A1', 'Popescu', 'Marian', 'popescu.marian@yahoo.com', '0756529362', 'C1','N1');

select d.Id_Angajat, d.Id_Skill, s.denumireSkill,s.nivelSkill from Detine d , Skill s
where d.Id_Skill = s.Id_Skill;

select * from skill;

select * from skill;
delete from skill where id_skill= 'Mediu-';
select * from detine;

SELECT d.Id_Skill FROM Detine d WHERE Id_Angajat = 'A2';


SELECT dataParticipareTask, dataParasireTask, nrOre 
            FROM Participa 
            WHERE Id_Angajat = 'A1' 
            AND Id_Proiect = 'P1' 
            AND Id_Task = 'T1';