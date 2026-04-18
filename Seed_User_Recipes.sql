-- Chạy script này SAU khi đã chạy CKFS_Managements.sql (tạo các bảng)
-- Tạo database nếu chưa có (bỏ qua nếu đã tạo)
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'CKFS_Managements')
BEGIN
    CREATE DATABASE CKFS_Managements;
END
GO

USE CKFS_Managements;
GO

-- Thêm role mẫu nếu chưa có
IF NOT EXISTS (SELECT 1 FROM roles WHERE RoleID = 1)
INSERT INTO roles (role_name, description) VALUES (N'Admin', N'Quản trị viên');
GO

-- Thêm tài khoản đăng nhập: UserName = sa, Password = 12345
IF NOT EXISTS (SELECT 1 FROM UserAccounts WHERE UserName = 'sa')
INSERT INTO UserAccounts (UserName, Password, FullName, Email, Phone, EmployeeCode, RoleId, IsActive, CreatedDate)
VALUES ('sa', '12345', N'System Admin', 'sa@ckfs.local', '0000000000', 'SA001', 1, 1, GETDATE());
GO
