namespace W21CertApp
{
    public class Statistics
    {
        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Sum { get; private set; }
        public int Count { get; private set; }
        public float Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Min = float.MaxValue;
            this.Max = float.MinValue;
        }

        public void UpdateStats(float result)
        {
            this.Count++;
            this.Sum += result;
            this.Min = Math.Min(this.Min, result);
            this.Max = Math.Max(this.Max, result);
        }
    }
}
