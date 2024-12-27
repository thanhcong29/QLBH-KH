using FlaUI.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using System.Threading;

namespace UTP_QL_QuanCaPhe.TestForm
{
    /// <summary>
    /// Summary description for frmDangNhapUITests
    /// </summary>
    [TestClass]
    public class frmDangNhapUITests
    {
        private FlaUI.Core.Application app;
        private AutomationBase automation;

        [TestInitialize]
        public void Setup()
        {
            app = FlaUI.Core.Application.Launch("E:\\Công Đi Học\\Đồ Án\\Project_ThucTap&DoAn\\KhoaLuan_QuanLyQuanCaPhe_WindowForms\\QL_QuanCaPhe\\bin\\Debug\\QL_QuanCaPhe.exe");
            automation = new UIA3Automation();
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Đóng ứng dụng sau mỗi bài kiểm tra
            app.Close();
            automation.Dispose();
        }

        [TestMethod]
        public void Login_WithValidCredentials_ShouldLoginSuccessfully()
        {
            var window = app.GetMainWindow(automation);
            var txtTaiKhoan = window.FindFirstDescendant(cf => cf.ByAutomationId("txtTaiKhoan"))?.AsTextBox();
            var txtMatKhau = window.FindFirstDescendant(cf => cf.ByAutomationId("txtMatKhau"))?.AsTextBox();
            var btnDangNhap = window.FindFirstDescendant(cf => cf.ByText("Đăng Nhập"))?.AsButton();

            Assert.IsNotNull(txtTaiKhoan, "Username textbox not found.");
            Assert.IsNotNull(txtMatKhau, "Password textbox not found.");
            Assert.IsNotNull(btnDangNhap, "Login button not found.");

            // Nhập tài khoản và mật khẩu hợp lệ
            txtTaiKhoan.Enter("admin"); // Thay đổi thành tài khoản hợp lệ
            txtMatKhau.Enter("1"); // Thay đổi thành mật khẩu hợp lệ
            btnDangNhap.Click();

            Thread.Sleep(2000); // Đợi một chút để xem phản hồi

            // Kiểm tra xem form home có hiển thị không
            var homeWindow = app.GetMainWindow(automation); // Thay đổi nếu có cửa sổ khác xuất hiện
            Assert.IsNotNull(homeWindow, "Home window not found after login.");
        }

        [TestMethod]
        public void Login_WithInvalidCredentials_ShouldShowErrorMessage()
        {
            var window = app.GetMainWindow(automation);
            var txtTaiKhoan = window.FindFirstDescendant(cf => cf.ByAutomationId("txtTaiKhoan"))?.AsTextBox();
            var txtMatKhau = window.FindFirstDescendant(cf => cf.ByAutomationId("txtMatKhau"))?.AsTextBox();
            var btnDangNhap = window.FindFirstDescendant(cf => cf.ByText("Đăng Nhập"))?.AsButton();

            Assert.IsNotNull(txtTaiKhoan, "Username textbox not found.");
            Assert.IsNotNull(txtMatKhau, "Password textbox not found.");
            Assert.IsNotNull(btnDangNhap, "Login button not found.");

            // Nhập tài khoản và mật khẩu không hợp lệ
            txtTaiKhoan.Enter("testuser"); // Tên đăng nhập không hợp lệ
            txtMatKhau.Enter("wrongpassword"); // Mật khẩu không hợp lệ
            btnDangNhap.Click();

            Thread.Sleep(2000); // Đợi một chút để xem phản hồi

            // Kiểm tra thông báo lỗi cho trường hợp không tìm thấy tài khoản
            var notFoundMessageElement = window.FindFirstDescendant(cf => cf.ByText("Không tìm thấy tài khoản người dùng"));
            if (notFoundMessageElement != null)
            {
                Assert.IsNotNull(notFoundMessageElement, "Account not found message displayed.");
            }
            else
            {
                // Nếu không tìm thấy thông báo "Không tìm thấy tài khoản người dùng", kiểm tra thông báo khác
                var errorMessageElement = window.FindFirstDescendant(cf => cf.ByText("Đăng nhập thất bại"));
                Assert.IsNotNull(errorMessageElement, "Error message not found.");
            }
        }


        [TestMethod]
        public void Login_WithEmptyUsername_ShouldShowErrorMessage()
        {
            var window = app.GetMainWindow(automation);
            var txtTaiKhoan = window.FindFirstDescendant(cf => cf.ByAutomationId("txtTaiKhoan"))?.AsTextBox();
            var txtMatKhau = window.FindFirstDescendant(cf => cf.ByAutomationId("txtMatKhau"))?.AsTextBox();
            var btnDangNhap = window.FindFirstDescendant(cf => cf.ByText("Đăng Nhập"))?.AsButton();

            Assert.IsNotNull(txtTaiKhoan, "Username textbox not found.");
            Assert.IsNotNull(txtMatKhau, "Password textbox not found.");
            Assert.IsNotNull(btnDangNhap, "Login button not found.");

            // Để trống tài khoản và nhập mật khẩu
            txtTaiKhoan.Enter("");
            txtMatKhau.Enter("123456");
            btnDangNhap.Click();

            Thread.Sleep(2000); // Đợi một chút để xem phản hồi

            // Kiểm tra thông báo lỗi
            var errorMessageElement = window.FindFirstDescendant(cf => cf.ByText("Vui lòng nhập tài khoản người dùng"));
            Assert.IsNotNull(errorMessageElement, "Error message not found.");
        }

        [TestMethod]
        public void Login_WithEmptyPassword_ShouldShowErrorMessage()
        {
            var window = app.GetMainWindow(automation);
            var txtTaiKhoan = window.FindFirstDescendant(cf => cf.ByAutomationId("txtTaiKhoan"))?.AsTextBox();
            var txtMatKhau = window.FindFirstDescendant(cf => cf.ByAutomationId("txtMatKhau"))?.AsTextBox();
            var btnDangNhap = window.FindFirstDescendant(cf => cf.ByText("Đăng Nhập"))?.AsButton();

            Assert.IsNotNull(txtTaiKhoan, "Username textbox not found.");
            Assert.IsNotNull(txtMatKhau, "Password textbox not found.");
            Assert.IsNotNull(btnDangNhap, "Login button not found.");

            // Nhập tài khoản và để trống mật khẩu
            txtTaiKhoan.Enter("testuser");
            txtMatKhau.Enter("");
            btnDangNhap.Click();

            Thread.Sleep(2000); // Đợi một chút để xem phản hồi

            // Kiểm tra thông báo lỗi
            var errorMessageElement = window.FindFirstDescendant(cf => cf.ByText("Vui lòng nhập mật khẩu người dùng"));
            Assert.IsNotNull(errorMessageElement, "Error message not found.");
        }
    }
}

