-- データベースを選択（適切なデータベース名に置き換えてください）
-- USE [YourDatabaseName];
-- GO

-- 既存のテーブルを一度削除 (開発中のみ)
 --DROP TABLE IF EXISTS Salaries;
 --DROP TABLE IF EXISTS Employees;
 --DROP TABLE IF EXISTS Departments;
 --GO

-- Departments テーブルの作成 (変更なし)
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName NVARCHAR(100) NOT NULL
);
GO

-- Employees テーブルの作成 (変更なし)
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    EmployeeName NVARCHAR(100) NOT NULL,
    HireDate DATE
);
GO

-- Salaries テーブルの作成 (EmployeeIDを単一の主キーとし、SalaryIDは不要)
CREATE TABLE Salaries (
    EmployeeID INT PRIMARY KEY, -- EmployeeIDを単一の主キーとする
    Amount DECIMAL(18, 2) NOT NULL,
    EffectiveDate DATE NOT NULL,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);
GO

-- サンプルデータの挿入

-- Departments テーブルにデータを挿入 (変更なし)
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, '営業部'),
(2, '開発部'),
(3, '総務部');
GO

-- Employees テーブルにデータを挿入 (変更なし)
INSERT INTO Employees (EmployeeID, DepartmentID, EmployeeName, HireDate) VALUES
(101, 1, '山田 太郎', '2020-04-01'),
(102, 1, '佐藤 花子', '2021-07-15'),
(103, 2, '田中 一郎', '2019-01-10'),
(104, 2, '鈴木 美咲', '2022-11-20'),
(105, 3, '高橋 健太', '2018-05-01'),
(106, 1, '山田 太郎', '2020-04-01'),
(107, 1, '佐藤 花子', '2021-07-15'),
(108, 2, '田中 一郎', '2019-01-10'),
(109, 2, '鈴木 美咲', '2022-11-20'),
(110, 3, '高橋 健太', '2018-05-01'),
(111, 1, '山田 太郎', '2020-04-01'),
(112, 1, '佐藤 花子', '2021-07-15'),
(113, 2, '田中 一郎', '2019-01-10'),
(114, 2, '鈴木 美咲', '2022-11-20'),
(115, 3, '高橋 健太', '2018-05-01'),
(116, 1, '山田 太郎', '2020-04-01'),
(117, 1, '佐藤 花子', '2021-07-15'),
(118, 2, '田中 一郎', '2019-01-10'),
(119, 2, '鈴木 美咲', '2022-11-20'),
(120, 3, '高橋 健太', '2018-05-01');
GO

-- Salaries テーブルにデータを挿入 (EmployeeIDが主キーなので、各EmployeeIDは1回しか登場できません)
INSERT INTO Salaries (EmployeeID, Amount, EffectiveDate) VALUES
(101, 300000.00, '2023-04-01'),
(102, 280000.00, '2024-01-01'),
(103, 450000.00, '2023-10-01'),
(104, 320000.00, '2023-11-20'),
(105, 350000.00, '2024-04-01');
GO

-- データが正しく挿入されたか確認（オプション）
-- SELECT * FROM Departments;
-- SELECT * FROM Employees;
-- SELECT * FROM Salaries;