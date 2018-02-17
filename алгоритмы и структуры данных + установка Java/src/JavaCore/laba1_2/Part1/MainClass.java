package JavaCore.laba1_2.Part1;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class MainClass {

    public static void main(String[] args) throws IOException{
        BufferedReader bf = new BufferedReader(new InputStreamReader(System.in));
        String reader;
        int[] array;
      //1-2  try {
        //    reader = bf.readLine();
      //  }
      //  catch(IOException e){
      //  }

     //3   for (String str:args) {
     //       reader += str;
      //  }



        reader = "  . 34        fd    ; ;;98  789 8 879 99 ....,7 ,7,7,7gtg.6fgggggd55.fg34dfg11.1dfg fgd";




        WorkWithArray workWithArray = new WorkWithArray();
        array = workWithArray.parseArray(reader);

      //5    array = workWithArray.generateArray(55);
        System.out.println("Average is: " + workWithArray.findAverage(array));
        System.out.println("Maximum is: " + workWithArray.findMaximum(array));
        System.out.println("Minimum is: " + workWithArray.findMinimum(array));
        System.out.println("Multiplication is: " + workWithArray.findMultiplication(array));
        System.out.println("CalculateIntegralOfSin is: " + workWithArray.findSum(array));
        System.out.println("Substraction is: " + workWithArray.findSubstraction(array));
        double[] arrayDouble = workWithArray.parseArrayDouble(reader);
        workWithArray.print(arrayDouble);



    }
}
