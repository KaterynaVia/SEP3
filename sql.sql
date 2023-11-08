drop schema if exists "GradingSystem" cascade;

create schema if not exists "GradingSystem";

set schema 'GradingSystem';

-- Create the tables

create table "user"(
    Id varchar(6) primary key,
    password varchar(20) not null,
    role text[] DEFAULT ARRAY['Student','Teacher','Supervisor']
);

ALTER TABLE "user"
ADD CONSTRAINT unique_user_id UNIQUE (Id);

ALTER TABLE "user"
ADD COLUMN name varchar(100) DEFAULT 'Unknown' NOT NULL;

INSERT INTO "user"(Id, password, role)
VALUES ('mym231','135790', ARRAY['Supervisor']);

INSERT INTO "user"(Id, name, password, role)
VALUES ('jpe444','Jan','123456', ARRAY['Teacher']),
       ('laua55','Lau','654321', ARRAY['Teacher']),
       ('lbs666','Lars','789012', ARRAY['Teacher']),
       ('jknr33','Jakob','210987', ARRAY['Teacher']);

INSERT INTO "user"(Id, password, role)
VALUES ('123456','123456', ARRAY['Student']),
       ('987654','654321', ARRAY['Student']),
       ('135790','13579', ARRAY['Student']),
       ('246802','24680', ARRAY['Student']);


create table Students(
    Id varchar(6) primary key,
    password varchar(20) not null,
    student_role text[] DEFAULT ARRAY['Student'],
    foreign key (Id) references "user"(Id)
);

INSERT INTO Students(Id, password, student_role)
VALUES ('123456','123456', ARRAY['Student']),
       ('987654','654321', ARRAY['Student']),
       ('135790','13579', ARRAY['Student']),
       ('246802','24680', ARRAY['Student']);


create table Teacher(
    Id varchar(6) primary key,
    teacherName varchar(100) not null,
    password varchar(20) not null,
    teacher_role text[] DEFAULT ARRAY['Teacher'],
    foreign key (Id) references "user"(Id)
);



ALTER TABLE teacher
ADD COLUMN name varchar(100);


INSERT INTO Teacher(Id,teacherName, password, teacher_role)
VALUES ('jpe444','Jan','123456', ARRAY['Teacher']),
       ('laua55','Lauritz','654321', ARRAY['Teacher']),
       ('jknr33','Jakob','210987', ARRAY['Teacher']);


create table Supervisor(
    Id varchar(6) primary key,
    password varchar(20) not null,
    supervisor_role text[] DEFAULT ARRAY['Supervisor'],
    --only one supervisor.
    foreign key (Id) references "user"(Id)
);

INSERT INTO Supervisor(Id,password, supervisor_role)
VALUES ('mym231','135790',ARRAY['Supervisor']);


create table Classes(
    classId serial primary key,         --Serial is auto incrementing and takes only integer values
    className varchar(100) not null,
    teacherId varchar(6) not null,
    --studentIds varchar[] DEFAULT ARRAY[]::varchar[],
    supervisorId varchar(20) not null,
    foreign key (teacherId) references Teacher(Id),
    --foreign key (studentIds) references Students(Id),
    foreign key (supervisorId) references Supervisor(Id)
);

INSERT INTO Classes(classId, className, teacherId, supervisorId)
VALUES  ('1','DNP1','jknr33','mym231'),
        ('2','SDJ3','jpe444','mym231'),
        ('3','CAO1','laua55','mym231');
        --('4','NES1','lbs666','mym231');

--why create table class_student? why not just add studentIds to the classes table?
--Because it is a many to many relationship. A student can be in many classes and a class can have many students.
--So we need a table to represent this relationship.
CREATE TABLE Class_Student (  --This is a many to many relationship table, which is why it has a composite primary key.
    classId serial REFERENCES Classes(classId),
    studentId varchar(20) REFERENCES Students(Id),
    PRIMARY KEY (classId, studentId)
);

INSERT INTO Class_Student(classId, studentId)
VALUES  ('1','123456'),
        ('2','123456'),
        ('3','123456'),
        ('1','987654'),
        ('2','987654'),
        ('3','987654'),
        ('1','135790'),
        ('2','135790'),
        ('3','135790'),
        ('1','246802'),
        ('2','246802'),
        ('3','246802');



create table Exam(
    examId varchar(20) primary key,
    examName varchar(100) not null,
    examTime timestamp not null,
    teacherId varchar(20) not null,
    classId serial not null,
    supervisorId varchar(20) not null,
    studentId varchar(20) not null,
    Grade varchar(20) not null,
    foreign key (studentId) references Students(Id),
    foreign key (supervisorId) references Supervisor(Id),
    foreign key (teacherId) references Teacher(Id),
    foreign key (classId) references Classes(classId)
);


INSERT INTO Exam(examId, examName, examTime, teacherId, classId, supervisorId, studentId, Grade)
VALUES
    ('E1', 'DNP1', '2024-01-04', 'jknr33', 1, 'mym231', '123456', '12'),
    ('E2', 'SDJ3', '2024-01-09', 'jpe444', 2, 'mym231', '123456', '10'),
    ('E3', 'CAO1', '2024-01-14', 'laua55', 3, 'mym231', '123456', '7'),
    ('E4', 'DNP1', '2024-01-04', 'jknr33', 1, 'mym231', '987654', '12'),
    ('E5', 'SDJ3', '2024-01-09', 'jpe444', 2, 'mym231', '987654', '10'),
    ('E6', 'CAO1', '2024-01-14', 'laua55', 3, 'mym231', '987654', '7'),
    ('E7', 'DNP1', '2024-01-04', 'jknr33', 1, 'mym231', '135790', '12'),
    ('E8', 'SDJ3', '2024-01-09', 'jpe444', 2, 'mym231', '135790', '10'),
    ('E9', 'CAO1', '2024-01-14', 'laua55', 3, 'mym231', '135790', '7'),
    ('E10', 'DNP1', '2024-01-04', 'jknr33', 1, 'mym231', '246802', '12'),
    ('E11', 'SDJ3', '2024-01-09', 'jpe444', 2, 'mym231', '246802', '10'),
    ('E12', 'CAO1', '2024-01-14', 'laua55', 3, 'mym231', '246802', '7');
