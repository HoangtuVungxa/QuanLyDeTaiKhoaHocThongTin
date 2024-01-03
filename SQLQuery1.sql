use QuanLyDeTaiWEB;

SELECT DT.MaDeTai, TenDeTai, TenLoai, TenTacGia, TenVaiTro, TenDonVi, NamBatDau, NamNghiemThu, KinhPhi, TenMucDo

FROM DeTaiNghienCuu AS DT, DonViThucHien AS DV, LoaiDeTai AS LDT, MucDoHoanThanh AS MD, CapBac AS CB, ChucVu AS CV, HocVi AS HV, TacGia_DeTai AS TGDT, VaiTro AS VT, TacGia AS TG 

WHERE DT.MaDeTai = TGDT.MaDeTai AND TG.MaTacGia = TGDT.MaTacGia AND VT.MaVaiTro = TGDT.MaVaiTro AND DT.MaLoai = LDT.MaLoai AND DT.MaDonVi = DV.MaDonVi AND DT.MaMucDo = MD.MaMucDo AND TG.MaCapBac = CB.MaCapBac AND TG.MaChucVu = CV.MaChucVu AND TG.MaHocVi = HV.MaHocVi

ORDER BY DT.MaDeTai

SELECT TG.MaTacGia, TenTacGia, TenDeTai, TenVaiTro, TenCapBac, TenChucVu, TenHocVi, NamSinh, SoDienThoai, Email, TG.GhiChu

FROM DeTaiNghienCuu AS DT, CapBac AS CB, ChucVu AS CV, HocVi AS HV, TacGia_DeTai AS TGDT, VaiTro AS VT, TacGia AS TG 

WHERE DT.MaDeTai = TGDT.MaDeTai AND TG.MaTacGia = TGDT.MaTacGia AND VT.MaVaiTro = TGDT.MaVaiTro  AND TG.MaCapBac = CB.MaCapBac AND TG.MaChucVu = CV.MaChucVu AND TG.MaHocVi = HV.MaHocVi

ORDER BY TG.MaTacGia