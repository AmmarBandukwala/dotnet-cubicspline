
# dotnet-cubicspline

A C# library for cubic spline interpolation, with a focus on simplicity and clarity. This project provides a robust implementation of cubic spline fitting and evaluation, as well as a tridiagonal matrix solver, suitable for scientific and engineering applications.

## Features

- **Cubic Spline Interpolation**: Fit and evaluate cubic splines for smooth curve fitting through a set of points.
- **Parametric Spline Fitting**: Fit splines to parametric data (e.g., x(t), y(t)), supporting open and closed curves.
- **Slope Constraints**: Optionally specify start and end slopes for more control over the curve.
- **Tridiagonal Matrix Solver**: Efficient Thomas algorithm implementation for solving tridiagonal systems.

## Project Structure

- `dotnet-cubicspline/`
  - `CubicSpline.cs`: Main cubic spline interpolation logic.
  - `TriDiagnolMatrix.cs`: Tridiagonal matrix and solver used by the spline algorithm.
  - `dotnet-cubicspline.csproj`: Library project file.
- `dotnet-cubicspline-test/`
  - `CubicSplineTest.cs`: Unit tests using xUnit.
  - `dotnet-cubicspline-test.csproj`: Test project file.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (Core or 5+ recommended)

### Build and Test

1. **Clone the repository:**
	```sh
	git clone https://github.com/AmmarBandukwala/dotnet-cubicspline.git
	cd dotnet-cubicspline
	```

2. **Build the library and tests:**
	```sh
	dotnet build
	```

3. **Run the tests:**
	```sh
	dotnet test
	```

## Usage Example

```csharp
// Example: Fit and evaluate a cubic spline
float[] x = { 0f, 1f, 2f, 3f };
float[] y = { 0f, 1f, 0f, 1f };
float[] xs = Enumerable.Range(0, 100).Select(i => i * 3f / 99).ToArray();

float[] ys = CubicSpline.Compute(x, y, xs);
```

For parametric fitting (e.g., for curves in 2D):

```csharp
float[] x = { ... };
float[] y = { ... };
CubicSpline.FitParametric(x, y, 100, out float[] xs, out float[] ys);
```

## API Overview

- `CubicSpline.Fit(...)`: Fit a spline to data.
- `CubicSpline.Eval(...)`: Evaluate the spline at given points.
- `CubicSpline.FitParametric(...)`: Fit a parametric spline (for x(t), y(t)).
- `TriDiagonalMatrixF.Solve(...)`: Solve a tridiagonal system (used internally).

## References

- [Wikipedia: Spline Interpolation](https://en.wikipedia.org/wiki/Spline_interpolation)
- [Wikipedia: Tridiagonal Matrix Algorithm](https://en.wikipedia.org/wiki/Tridiagonal_matrix_algorithm)

## License

MIT License. See [LICENSE](LICENSE) for details.
