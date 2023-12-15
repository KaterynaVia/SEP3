drop schema if exists "GradingSystem" cascade;

create schema if not exists "GradingSystem";

set schema 'GradingSystem';

-- Create the tables

CREATE TABLE users (
    id VARCHAR(255) PRIMARY KEY,
    password VARCHAR(255) NOT NULL,
    name VARCHAR(255) NOT NULL
);


INSERT INTO users (id, password, name) VALUES
('user11', 'password1', 'John Doe'),
('user22', 'password2', 'Jane Smith'),
('user33', 'password3', 'Bob Johnson'),
('teacher1', 'teacherpass1', 'Teacher 1'),
('teacher2', 'teacherpass2', 'Teacher 2'),
('student1', 'studentpass1', 'Student 1'),
('student2', 'studentpass2', 'Student 2'),
('student3', 'studentpass3', 'Student 3'),
('mym231','135790','Mohammad Yaser Moustafa');





CREATE TABLE teachers (
    id VARCHAR(255) PRIMARY KEY,
    password VARCHAR(255) NOT NULL,
    user_id INT
);

ALTER TABLE teachers ADD FOREIGN KEY (id) REFERENCES users(id);

INSERT INTO teachers (id, password, user_id) VALUES
('teacher1', 'teacherpass1', 1),
('teacher2', 'teacherpass2', 2);



CREATE TABLE supervisors (
    id VARCHAR(255) PRIMARY KEY,
    password VARCHAR(255) NOT NULL,
    user_id INT
);

ALTER TABLE supervisors ADD FOREIGN KEY (id) REFERENCES users(id);


INSERT INTO supervisors(id, password, user_id)
VALUES ('mym231','135790',2);






CREATE TABLE students (
    id VARCHAR(255) PRIMARY KEY,
    password VARCHAR(255) NOT NULL,
    user_id INT
);

ALTER TABLE students ADD FOREIGN KEY (id) REFERENCES users(id);


INSERT INTO students (id, password, user_id) VALUES
('student1', 'studentpass1', 1),
('student2', 'studentpass2', 2),
('student3', 'studentpass3', 3);




CREATE TABLE school_classes (
    id INT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    teacher_id VARCHAR(255),
    FOREIGN KEY (teacher_id) REFERENCES teachers(id)
);


INSERT INTO school_classes (id, name, teacher_id) VALUES
(1, 'Math Class', 'teacher1'),
(2, 'English Class', 'teacher2');




CREATE TABLE class_students (
    class_id INT,
    student_id VARCHAR(255),
    FOREIGN KEY (class_id) REFERENCES school_classes(id),
    FOREIGN KEY (student_id) REFERENCES students(id)
);


INSERT INTO class_students (class_id, student_id) VALUES
(1, 'student1'),
(1, 'student2'),
(2, 'student3');




CREATE TABLE exams (
    id_of_exam INT PRIMARY KEY,
    name_of_exam VARCHAR(255) NOT NULL,
    date_time VARCHAR(255),
    class_id INT,
    FOREIGN KEY (class_id) REFERENCES school_classes(id)
);


INSERT INTO exams (id_of_exam, name_of_exam, date_time, class_id) VALUES
(1, 'Math Midterm', '2023-01-15 10:00:00', 1),
(2, 'English Final', '2023-02-20 14:30:00', 2);




CREATE TABLE grades (
    id INT PRIMARY KEY,
    exam_id int not null,
    student_id VARCHAR(255),
    student_grade INT,
    FOREIGN KEY (exam_id) REFERENCES exams(id_of_exam),
    FOREIGN KEY (student_id) REFERENCES students(id)
);

INSERT INTO grades (id, exam_id, student_id, student_grade) VALUES
(1, 1, 'student1', 85),
(2, 1, 'student2', 78),
(3, 2, 'student3', 92);