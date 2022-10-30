import java.io.*;
import java.util.Scanner;

class Main {
  
    static boolean isPrime(int n)
    {
        if (n <= 1)
            return false;

        if (n <= 3)
            return true;

        if (n % 2 == 0 || n % 3 == 0)
            return false;
  
        for (int i = 5; i * i <= n; i = i + 6)
            if (n % i == 0 || n % (i + 2) == 0)
                return false;
  
        return true;
    }

    public static void main(String args[])
    {
	Scanner in = new Scanner(System.in);
        int n = in.nextInt();
        if (isPrime(n))
            System.out.println("TRUE");
        else
            System.out.println("FALSE"); 
    }
}