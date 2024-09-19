namespace Chatx.Model
{
    public class HanghoaVM
    {
        public string TenHangHoa { get; set; }
        public double Dongia { get; set; }

    }
    public class HangHoa : HanghoaVM
    {
        public Guid MaHangHoa { get; set; }
    }

}
