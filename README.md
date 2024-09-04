# Bus Ticket Booking

## Giới thiệu
Phần mềm đặt vé xe bus giúp người dùng dễ dàng đăng ký, đăng nhập, chọn ngày đi, điểm đi - điểm đến, tạo vé, xem lịch sử đặt vé, và chỉnh sửa thông tin cá nhân. Phần mềm được phát triển bằng ngôn ngữ C# theo mô hình MVVC.
## Chỉnh sửa Database
- Chỉnh sửa trong file appsetting.json , project sử dụng hệ quản trị cơ sở dữ liệu Microsoft SQL Server
```bash
 "DefaultConnection": "Data Source=DESKTOP-8AVMLSL;Initial Catalog=TicketBus;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
```

## Tính năng chính
- **Đăng ký tài khoản**: Người dùng có thể tạo tài khoản mới để sử dụng dịch vụ.
- **Đăng nhập**: Truy cập vào tài khoản đã đăng ký.
- **Chọn ngày đi**: Người dùng có thể chọn ngày đi mong muốn.
- **Chọn điểm đi - điểm đến**: Lựa chọn điểm xuất phát và điểm đến của chuyến đi.
- **Tạo vé**: Người dùng có thể tạo vé cho chuyến đi đã chọn.
- **Xem lịch sử đặt vé**: Người dùng có thể xem lại các vé đã đặt trước đây.
- **Chỉnh sửa thông tin cá nhân**: Người dùng có thể cập nhật thông tin cá nhân.

## Hướng dẫn cài đặt

1. **Clone dự án**:
   ```bash
   git clone https://github.com/NichePro21/BusTicket.git
