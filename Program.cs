using System;
using System.Data;
using System.Linq;
using System.Text;
using bt_tao_FE;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        using (var db = new EntityDBEntities())
        {
            var nhanViens = from nv in db.NhanVien
                            join pb in db.PhongBan on nv.PhongBanId equals pb.Id
                            join ct in db.Congty on pb.CongtyId equals ct.Id
                            where nv.GioiTinh == "Nam" && pb.Ten == "Marketing" && nv.Tuoi >= 30 && nv.Tuoi <= 40
                            select nv;

            Console.WriteLine("Danh sách nhân viên nam thuộc phòng Marketing và có tuổi từ 30 đến 40:");
            foreach (var nv in nhanViens)
            {
                Console.WriteLine($"Tên: {nv.Ten}, Tuổi: {nv.Tuoi}, Phòng ban: {nv.PhongBan.Ten}");
            }
        }

        Console.ReadLine();
    }
}
