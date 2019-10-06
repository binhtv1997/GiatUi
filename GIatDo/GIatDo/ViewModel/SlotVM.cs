using System;


namespace GIatDo.ViewModel
{
    public class SlotVM
    {
        public Guid Id { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
    }
    public class SlotCM
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
    }
}
