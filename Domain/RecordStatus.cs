namespace Domain
{
    public struct RecordStatus
    {
        private readonly struct Code
        {
            public static readonly string Initial = "INITIAL";
            public static readonly string InPrgress = "INPROGRESS";
            public static readonly string Complete = "COMPLETE";
            public static readonly string Abort = "ABORT";
        }

        private readonly struct Description
        {
            public static readonly string Initial = "Initial";
            public static readonly string InPrgress = "InPrgress";
            public static readonly string Complete = "Complete";
            public static readonly string Abort = "Abort";
        }

        public string Status { get; }

        public RecordStatus(string status)
        {
            Status = status;
        }

        public static RecordStatus Parse(string status)
        {
            return new RecordStatus(status);
        }

        public static RecordStatus Initial => new RecordStatus(Code.Initial);

        public static RecordStatus InProgress => new RecordStatus(Code.InPrgress);

        public static RecordStatus Complete => new RecordStatus(Code.Complete);

        public static RecordStatus Abort => new RecordStatus(Code.Abort);

        public override bool Equals(object? obj)
        {
            return obj != null
                ? Status.Equals(((RecordStatus)obj!).Status)
                : false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
