namespace Blib.UnitTest.Data;

public static class CreateNewReaderDataModel
{
    public static DataFormInputModel GetFormCreateNewReaderDataModel()
    {
        return new DataFormInputModel()
        {
            DataInputModels =
            [
                new (){Key="txt_name", Value = "Le Khac Ninh"},
                new (){Key = "txt_birth_date", Value = "18/05/2003"},
                new(){Key = "pwd_password", Value = "Ucvn@2024"},
                new (){Key = "sel_sex", Value = "Nam"},
                new(){Key = "txt_ic_no", Value = "123456789"},
                new(){Key = "sel2_reader_type_id", Value = "Sinh viên"},
                new (){Key = "txt_email", Value = "khacninh@gmail.com"},
                new (){Key = "sel_reader_digital_type_ids", Value = "Bạn đọc OPAC"},
                new (){Key = "txt_course_name", Value = "K63"},
                new(){Key = "txt_class_code", Value = "CNTT"},
                new(){Key = "txt_address", Value = "Thanh Hoa"},
                new(){Key = "sel2_degree_id", Value = "Đại học"},
                new(){Key = "sel2_prof_id", Value = "Sinh viên"},
                new (){Key = "txt_org_name", Value = "Ucvn"},
                new(){Key = "sel2_ethnic_id", Value = "Kinh"},
                new(){Key = "txt_nationality", Value = "Việt Nam"},
                new(){Key = "txt_note", Value = "không có note"},
                new (){Key = "avatar-input", Value = "ReaderImage/cach-chup-hinh-the-dep.jpeg"}
            ]
        };
    }
}