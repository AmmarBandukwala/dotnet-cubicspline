using System;
using Xunit;

namespace dotnet_cubicspline_test
{
    public class CubicSplineTest
    {
        [Fact]
        public void FitParametric()
        {
            // Create the data to be fitted
            float[] x = { 0.5f, 2.0f, 3.0f, 4.5f, 3.0f, 2.0f };
            float[] y = { 4.0f, 2.0f, 6.0f, 4.0f, 3.0f, 5.0f };

            float[] xs, ys;

            CubicSpline.FitParametric(x, y, 100, out xs, out ys);

            // Specify start slope
            CubicSpline.FitParametric(x, y, 100, out xs, out ys, 1, 0);
            CubicSpline.FitParametric(x, y, 100, out xs, out ys, 0, 1);
            CubicSpline.FitParametric(x, y, 100, out xs, out ys, 1, -1);
            CubicSpline.FitParametric(x, y, 100, out xs, out ys, -1, -1);
            CubicSpline.FitParametric(x, y, 100, out xs, out ys, -1, 1);
            CubicSpline.FitParametric(x, y, 100, out xs, out ys, 1, -1, 1, 1);
            CubicSpline.FitParametric(x, y, 100, out xs, out ys, 1, -1, 1, -1);

            Assert.True(xs.Length == 100 && ys.Length == 100);
        }

        [Fact]
        public void Spline()
        {
            int n = 6;

            // Create the data to be fitted
            float[] x = new float[n];
            float[] y = new float[n];
            var rand = new Random(1);

            for (int i = 0; i < n; i++)
            {
                x[i] = i;
                y[i] = (float)rand.NextDouble() * 10;
            }

            // Compute the x values at which we will evaluate the spline.
            // Upsample the original data by a const factor.
            int upsampleFactor = 10;
            int nInterpolated = n * upsampleFactor;
            float[] xs = new float[nInterpolated];

            for (int i = 0; i < nInterpolated; i++)
            {
                xs[i] = (float)i * (n - 1) / (float)(nInterpolated - 1);
            }

            float[] ys = CubicSpline.Compute(x, y, xs, 0.0f, Single.NaN, true);

            Assert.True(xs.Length == 60 && ys.Length == 60);
        }
    }
}
