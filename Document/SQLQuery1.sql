-- �f�[�^�x�[�X��I���i�K�؂ȃf�[�^�x�[�X���ɒu�������Ă��������j
-- USE [YourDatabaseName];
-- GO

-- �����̃e�[�u������x�폜 (�J�����̂�)
 --DROP TABLE IF EXISTS Salaries;
 --DROP TABLE IF EXISTS Employees;
 --DROP TABLE IF EXISTS Departments;
 --GO

-- Departments �e�[�u���̍쐬 (�ύX�Ȃ�)
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName NVARCHAR(100) NOT NULL
);
GO

-- Employees �e�[�u���̍쐬 (�ύX�Ȃ�)
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    EmployeeName NVARCHAR(100) NOT NULL,
    HireDate DATE
);
GO

-- Salaries �e�[�u���̍쐬 (EmployeeID��P��̎�L�[�Ƃ��ASalaryID�͕s�v)
CREATE TABLE Salaries (
    EmployeeID INT PRIMARY KEY, -- EmployeeID��P��̎�L�[�Ƃ���
    Amount DECIMAL(18, 2) NOT NULL,
    EffectiveDate DATE NOT NULL,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);
GO

-- �T���v���f�[�^�̑}��

-- Departments �e�[�u���Ƀf�[�^��}�� (�ύX�Ȃ�)
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, '�c�ƕ�'),
(2, '�J����'),
(3, '������');
GO

-- Employees �e�[�u���Ƀf�[�^��}�� (�ύX�Ȃ�)
INSERT INTO Employees (EmployeeID, DepartmentID, EmployeeName, HireDate) VALUES
(101, 1, '�R�c ���Y', '2020-04-01'),
(102, 1, '���� �Ԏq', '2021-07-15'),
(103, 2, '�c�� ��Y', '2019-01-10'),
(104, 2, '��� ����', '2022-11-20'),
(105, 3, '���� ����', '2018-05-01'),
(106, 1, '�R�c ���Y', '2020-04-01'),
(107, 1, '���� �Ԏq', '2021-07-15'),
(108, 2, '�c�� ��Y', '2019-01-10'),
(109, 2, '��� ����', '2022-11-20'),
(110, 3, '���� ����', '2018-05-01'),
(111, 1, '�R�c ���Y', '2020-04-01'),
(112, 1, '���� �Ԏq', '2021-07-15'),
(113, 2, '�c�� ��Y', '2019-01-10'),
(114, 2, '��� ����', '2022-11-20'),
(115, 3, '���� ����', '2018-05-01'),
(116, 1, '�R�c ���Y', '2020-04-01'),
(117, 1, '���� �Ԏq', '2021-07-15'),
(118, 2, '�c�� ��Y', '2019-01-10'),
(119, 2, '��� ����', '2022-11-20'),
(120, 3, '���� ����', '2018-05-01');
GO

-- Salaries �e�[�u���Ƀf�[�^��}�� (EmployeeID����L�[�Ȃ̂ŁA�eEmployeeID��1�񂵂��o��ł��܂���)
INSERT INTO Salaries (EmployeeID, Amount, EffectiveDate) VALUES
(101, 300000.00, '2023-04-01'),
(102, 280000.00, '2024-01-01'),
(103, 450000.00, '2023-10-01'),
(104, 320000.00, '2023-11-20'),
(105, 350000.00, '2024-04-01');
GO

-- �f�[�^���������}�����ꂽ���m�F�i�I�v�V�����j
-- SELECT * FROM Departments;
-- SELECT * FROM Employees;
-- SELECT * FROM Salaries;