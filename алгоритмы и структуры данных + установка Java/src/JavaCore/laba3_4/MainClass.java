package JavaCore.laba3_4;

import java.io.IOException;


public class MainClass {

    public static void main(String[] args) throws IOException{


        System.out.println(Calculations.calculateSin(0, 5, 1, 15));
        System.out.println(new CalculateIntegralOfSin().evaluate(0,5,15));
    }
}
