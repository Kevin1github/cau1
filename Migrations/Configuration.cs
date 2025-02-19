using System.Data.Entity.Migrations;

namespace ett1_win.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ett1_win.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; // Cho phép tự động cập nhật DB
        }

        protected override void Seed(ett1_win.StudentContext context)
        {
            // Đảm bảo database được khởi tạo
            context.Database.Initialize(true);

            // Thêm dữ liệu mẫu nếu cần
            context.Students.AddOrUpdate(
                s => s.Name,
                new Student { Name = "Nguyen Van A", Age = 20, Class = "12A1" },
                new Student { Name = "Le Thi B", Age = 19, Class = "12A2" }
            );
        }
    }
}
