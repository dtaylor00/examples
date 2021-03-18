using System;
public class SumOfSquares {
    // Uses Legendre's three-square theorem and Lagrange's four-square theorem
    public static int NSquaresFor(int n) {
        int x = (int)Math.Sqrt(n);
        if (x * x == n) return 1; // n is already a perfect square
        if (x * x == n + 1) return 2; // n is one above a perfect square

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
