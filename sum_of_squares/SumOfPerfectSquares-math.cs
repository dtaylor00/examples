using System;
public class SumOfSquares {
    public static void Main(string[] args) {
        int max = 1000001;
        TimeSpan start = DateTime.Now.TimeOfDay;
        TimeSpan lastDuration = TimeSpan.Zero;
        TimeSpan lastElapsed = TimeSpan.Zero;

        for (int i = 1; i < max; ++i) {
            TimeSpan t1 = DateTime.Now.TimeOfDay;
            int s = NSquaresFor(i);
            TimeSpan t2 = DateTime.Now.TimeOfDay;
            if (t2 - t1 > TimeSpan.FromTicks(lastDuration.Ticks * 2) || t2 - start > TimeSpan.FromTicks(lastElapsed.Ticks * 2)) {
                lastDuration = t2 - t1;
                lastElapsed = t2 - start;
                Console.WriteLine($"{i}: sum of {s} perfect squares: computed in {lastDuration}. Elapsed time: {lastElapsed}.");
            }
        }
        TimeSpan end = DateTime.Now.TimeOfDay;
        Console.WriteLine($"Total elapsed time to computer sum of squares up to {max}: {end - start}.");
    }

    // Uses Legendre's three-square theorem and Lagrange's four-square theorem
    public static int NSquaresFor(int n) {
        int x = (int)Math.Sqrt(n);
        if (x * x == n) return 1; // n is already a perfect square
        if (x * x == n + 1) return 2; // n is a perfect square plus 1

        // Checking if n is in the form of 4^a(8b+7). If it is, then it must be expressed in four squares
        while (n % 4 == 0) n /= 4;
        if (n % 8 == 7) return 4;

        // Finding a point between from 1 to n where both sides are perfect squares
        for (int i = 1; i * i <= n; i++) {
            x = (int)Math.Sqrt(n - i * i);
            if (x * x == (n - i * i))
                return 2; // n = x^2 + i^2
        }

        // If we couldn't find a point, then the only option left is n is expressed in three squares
        return 3;
    }
}
