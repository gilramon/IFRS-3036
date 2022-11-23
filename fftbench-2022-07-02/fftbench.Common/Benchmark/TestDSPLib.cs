
namespace fftbench.Benchmark
{
    using DSPLib;

    public class TestDSPLib : ITest
    {
        double[] copy;
        double[] data;

        FFT fft = new FFT();

        public string Name => ToString();

        public int Size { get; private set; }

        public bool Enabled { get; set; }

        public void Initialize(double[] data)
        {
            int length = Size = data.Length;

            this.copy = (double[])data.Clone();
            this.data = new double[length];

            fft.Initialize((uint)length);
        }

        public void FFT(bool forward)
        {
            data.CopyTo(copy, 0);

            fft.Execute(copy);
        }

        public double[] Spectrum(double[] input, bool scale)
        {
            var fft = new FFT();

            fft.Initialize((uint)input.Length);

            var result = fft.Execute(input);

            var spectrum = DSP.ConvertComplex.ToMagnitude(result);

            return spectrum;
        }

        public override string ToString()
        {
            return "DSPLib";
        }
    }
}
