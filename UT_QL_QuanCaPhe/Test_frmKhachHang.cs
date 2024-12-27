using FlaUI.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace UT_QL_QuanCaPhe.TestForm
{
    [TestClass]
    public class Test_frmKhachHang
    {
        private FlaUI.Core.Application app;
        private UIA3Automation automation;

        [TestInitialize]
        public void Setup()
        {
            // Khởi chạy ứng dụng
            app = FlaUI.Core.Application.Launch("E:\\Công Đi Học\\Đồ Án\\Project_ThucTap&DoAn\\KhoaLuan_QuanLyQuanCaPhe_WindowForms\\QL_QuanCaPhe\\bin\\Debug\\QL_QuanCaPhe.exe");
            automation = new UIA3Automation();

            LoginAndNavigateToCustomerManagement();
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Đóng ứng dụng sau mỗi bài kiểm tra
            app.Close();
            automation.Dispose();
        }

        private void LoginAndNavigateToCustomerManagement()
        {
            var window = app.GetMainWindow(automation);
            var txtTaiKhoan = window.FindFirstDescendant(cf => cf.ByAutomationId("txtTaiKhoan"))?.AsTextBox();
            var txtMatKhau = window.FindFirstDescendant(cf => cf.ByAutomationId("txtMatKhau"))?.AsTextBox();
            var btnDangNhap = window.FindFirstDescendant(cf => cf.ByText("Đăng Nhập"))?.AsButton();

            Assert.IsNotNull(txtTaiKhoan, "Textbox tài khoản không tìm thấy.");
            Assert.IsNotNull(txtMatKhau, "Textbox mật khẩu không tìm thấy.");
            Assert.IsNotNull(btnDangNhap, "Nút đăng nhập không tìm thấy.");

            // Nhập tài khoản và mật khẩu hợp lệ
            txtTaiKhoan.Enter("admin"); // Thay đổi thành tài khoản hợp lệ
            txtMatKhau.Enter("1"); // Thay đổi thành mật khẩu hợp lệ
            btnDangNhap.Click();

            Thread.Sleep(3000); // Đợi một chút để form chuyển tới trang chính sau khi đăng nhập

            // Kiểm tra xem form home có hiển thị không
            var homeWindow = app.GetMainWindow(automation);
            Assert.IsNotNull(homeWindow, "Cửa sổ chính không tìm thấy sau khi đăng nhập.");

            // Tìm và nhấn vào nút "Quản Lý"
            var ribbonPage = homeWindow.FindFirstDescendant(cf => cf.ByText("Quản Lý"))?.AsButton();
            Assert.IsNotNull(ribbonPage, "Nút 'Quản Lý' không tìm thấy.");

            // Nhấn vào nút "Quản Lý"
            ribbonPage.Click();
            Thread.Sleep(1000); // Đợi cửa sổ mở ra sau khi click

            // Tìm và nhấn vào nút "Quản lý khách hàng"
            var customerManagementButton = homeWindow.FindFirstDescendant(cf => cf.ByText("Quản lý khách hàng"))?.AsButton();
            Assert.IsNotNull(customerManagementButton, "Nút 'Quản lý khách hàng' không tìm thấy.");

            // Nhấn vào nút "Quản lý khách hàng"
            customerManagementButton.Click();
            Thread.Sleep(1000); // Đợi cửa sổ quản lý khách hàng mở ra
        }

        [TestMethod]
        public void AddCustomer_WithValidInformation_ShouldAddSuccessfully()
        {
            // Tìm cửa sổ quản lý khách hàng
            var window = app.GetMainWindow(automation).FindFirstDescendant(cf => cf.ByAutomationId("frmKhachHang"))?.AsWindow();
            Assert.IsNotNull(window, "Cửa sổ quản lý khách hàng không tìm thấy.");

            // Tìm các thành phần trên cửa sổ
            var btnAddCustomer = window.FindFirstDescendant(cf => cf.ByAutomationId("btnThem"))?.AsButton();
            var txtCustomerName = window.FindFirstDescendant(cf => cf.ByAutomationId("txtTenKH"))?.AsTextBox();
            var txtPhoneNumber = window.FindFirstDescendant(cf => cf.ByAutomationId("txtSDT"))?.AsTextBox();
            var txtPassword = window.FindFirstDescendant(cf => cf.ByAutomationId("txtMatKhau"))?.AsTextBox();
            var txtEmail = window.FindFirstDescendant(cf => cf.ByAutomationId("txtEmail"))?.AsTextBox();
            var btnSave = window.FindFirstDescendant(cf => cf.ByAutomationId("btnLuu"))?.AsButton();

            // Kiểm tra sự hiện diện của các thành phần
            Assert.IsNotNull(btnAddCustomer, "Nút thêm khách hàng không tìm thấy.");
            Assert.IsNotNull(txtCustomerName, "Textbox tên khách hàng không tìm thấy.");
            Assert.IsNotNull(txtPhoneNumber, "Textbox số điện thoại không tìm thấy.");
            Assert.IsNotNull(txtPassword, "Textbox mật khẩu không tìm thấy.");
            Assert.IsNotNull(txtEmail, "Textbox email không tìm thấy.");
            Assert.IsNotNull(btnSave, "Nút lưu không tìm thấy.");

            // Nhấn nút Thêm Khách Hàng
            btnAddCustomer.Click();
            Thread.Sleep(1000); // Đợi để đảm bảo cửa sổ thêm khách hàng được hiển thị

            // Nhập thông tin khách hàng
            txtCustomerName.Enter("Nguyen Van B");
            txtPhoneNumber.Enter("0988363618");
            txtPassword.Enter("1");
            txtEmail.Enter("nguyenvanb@gmail.com");
            btnSave.Click();

            Thread.Sleep(2000); // Đợi một chút để xem phản hồi

            // Kiểm tra thông báo thành công
            var successMessage = window.FindFirstDescendant(cf => cf.ByText("Thêm thông tin khách hàng thành công"));
            Assert.IsNotNull(successMessage, "Thông báo thành công không tìm thấy.");

            // Nhấn nút OK để đóng thông báo
            var okButton = successMessage.FindFirstDescendant(cf => cf.ByText("OK"))?.AsButton();
            Assert.IsNotNull(okButton, "Nút OK không tìm thấy.");
            okButton.Click();

            // Đợi một chút để đảm bảo rằng thông báo đã được đóng
            Thread.Sleep(1000);
        }
    }
}
